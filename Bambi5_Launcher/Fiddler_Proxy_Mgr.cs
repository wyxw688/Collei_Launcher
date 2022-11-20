using BCCertMaker;
using Fiddler;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collei_Launcher
{
    internal static class Fiddler_Proxy_Mgr
    {

        //初始化Fiddler
        public static X509Certificate2 oRootCert;
        public static BCCertMaker.BCCertMaker cm = new BCCertMaker.BCCertMaker();
        public static SessionStateHandler handler;
        public static string PfxPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Collei_Launcher\\FiddlerCert.pfx";

        public static async Task<bool> Run_Fiddler(Details_Form details)
        {
            FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.RootCN", "Collei_Launcher");
            if (CertMaker.oCertProvider == null)
            {
                CertMaker.oCertProvider = cm;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(PfxPath));
            handler = new SessionStateHandler(details.On_BeforeRequest);
            ushort proxy_port = Main_Form.lc.config.ProxyPort;
            try
            {
                Stop();
                FiddlerApplication.BeforeRequest += handler;
                if (File.Exists(PfxPath))
                {
                    cm.ReadRootCertificateAndPrivateKeyFromPkcs12File(PfxPath,"");

                    oRootCert = CertMaker.GetRootCertificate();
                    Debug.Print("读取证书");
                }
                else
                {
                    cm.CreateRootCertificate();
                    oRootCert = CertMaker.GetRootCertificate();
                    cm.WriteRootCertificateAndPrivateKeyToPkcs12File(PfxPath, "");
                    Debug.Print("创造证书");
                }

                var c = Methods.Add_Cert(CertMaker.GetRootCertificate(), StoreLocation.CurrentUser);
                if (!c)
                {
                    details.Print_log("证书安装失败，请重新启动代理并安装证书。");
                    return false;
                }
                //cm.TrustRootCertificate();
                //-----------------------------
                FiddlerApplication.oDefaultClientCertificate = oRootCert;
                CONFIG.IgnoreServerCertErrors = true;
                FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
                Fiddler.FiddlerCoreStartupSettingsBuilder settings =
                new Fiddler.FiddlerCoreStartupSettingsBuilder()
                .DecryptSSL()
                .ListenOnPort(proxy_port)
                .AllowRemoteClients();
                FiddlerApplication.Startup(settings.Build());
                int iport = proxy_port - 1;
                if (proxy_port == 1)
                {
                    iport = proxy_port + 1;
                }
                FiddlerApplication.CreateProxyEndpoint(iport, true, oRootCert);
                return true;
            }
            catch (Exception e)
            {
                Program.Application_Catched_Exception(e);
                return false;
            }
        }


        public static void Stop()
        {
            if (handler != null)
                FiddlerApplication.BeforeRequest -= handler;
            FiddlerApplication.Shutdown();
            //Methods.Remove_Cert(oRootCert);
        }

    }
}

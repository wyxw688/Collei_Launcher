using Fiddler;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;


namespace Collei_Launcher
{
    internal static class Titanium_Proxy_Mgr
    {
        public static ProxyServer ps = new ProxyServer("Collei_Launcher", "Titanium");
        public static AsyncEventHandler<SessionEventArgs> handler;
        public static ExplicitProxyEndPoint ep;
        public static string PfxPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Collei_Launcher\\TitaniumCert.pfx";

        public static Task OnCertificateValidation(object sender, CertificateValidationEventArgs e)
        {
            e.IsValid = true;
            return Task.CompletedTask;
        }
        public static Task OnBeforeTunnelConnectRequest(object sender, TunnelConnectSessionEventArgs se)
        {
            return Task.Run(() =>
            {
                se.DecryptSsl = true;
            });
        }
        public static async Task<bool> Run_Titanium(Details_Form details)
        {
            try
            {
                Stop();
                Directory.CreateDirectory(Path.GetDirectoryName(PfxPath));
                ps.CertificateManager.PfxFilePath = PfxPath;
                ps.CertificateManager.CreateRootCertificate(true);
                bool certok = Methods.Add_Cert(ps.CertificateManager.RootCertificate, System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser);

                if(!certok)
                {
                    details.Print_log("证书安装失败，请重新启动代理并安装证书。");
                    return false;
                }

                handler = details.BeforeRequest;
                ps.BeforeRequest += handler;
                ps.ServerCertificateValidationCallback += OnCertificateValidation;
                ep = new ExplicitProxyEndPoint(IPAddress.Any, Main_Form.lc.config.ProxyPort, true);
                ep.BeforeTunnelConnectRequest += OnBeforeTunnelConnectRequest;
                ps.AddEndPoint(ep);
                ps.Start();
                //ps.SetAsSystemProxy(ep, ProxyProtocolType.AllHttp);

                return true;
            }
            catch (Exception e)
            {
                details.Print_log("抛出异常:\n" + e.Message);
                details.Print_log("代理启动失败，请尝试更改代理模式");
                Program.Application_Catched_Exception(e);
                return false;
            }
        }
        public static void Stop()
        {
            try
            {
                if (ps != null)
                {
                    if (ps.ProxyRunning)
                    {
                        ps.Stop();
                    }
                    if (handler != null)
                    {
                        ps.BeforeRequest -= handler;
                    }
                    //ps.CertificateManager.RemoveTrustedRootCertificateAsAdmin(true);
                    ps.ServerCertificateValidationCallback -= OnCertificateValidation;
                    ps.DisableSystemProxy(ProxyProtocolType.AllHttp);
                    if (ep != null)
                    {
                        ep.BeforeTunnelConnectRequest -= OnBeforeTunnelConnectRequest;
                    }
                }
            }
            catch (Exception e)
            {
                Program.Application_Catched_Exception(e);
            }
        }
    }
}

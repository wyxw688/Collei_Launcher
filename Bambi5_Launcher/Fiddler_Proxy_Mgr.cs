using Fiddler;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Collei_Launcher
{
    internal static class Fiddler_Proxy_Mgr
    {
        //初始化Fiddler
        public static X509Certificate2 oRootCert;
        public static SessionStateHandler handler;
        public static Task Run_Fiddler(Details_Form details)
        {
            var tk = Task.Run(() =>
            {
                handler = new SessionStateHandler(details.On_BeforeRequest);
                ushort proxy_port = Main_Form.lc.config.ProxyPort;
                try
                {
                    Stop();
                    //绑定事件处理————当发起请求之前

                    FiddlerApplication.BeforeRequest += handler;
                    //-----------处理证书-----------
                    //伪造的证书
                    //如果没有伪造过证书并把伪造的证书加入本机证书库中
                    if (CertMaker.GetRootCertificate() == null)
                    {
                        Debug.Print("未找到证书");
                        //创建伪造证书
                        CertMaker.createRootCert();
                        //重新获取
                        oRootCert = CertMaker.GetRootCertificate();
                    }
                    else
                    {

                        Debug.Print("已找到证书");
                        //以前伪造过证书，并且本地证书库中保存过伪造的证书
                        oRootCert = CertMaker.GetRootCertificate();
                    }
                    Methods.Add_Cert(oRootCert);
                    //-----------------------------

                    //指定伪造证书
                    FiddlerApplication.oDefaultClientCertificate = oRootCert;
                    //忽略服务器证书错误
                    CONFIG.IgnoreServerCertErrors = true;
                    FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
                    Fiddler.FiddlerCoreStartupSettingsBuilder settings =
                    new Fiddler.FiddlerCoreStartupSettingsBuilder()
                    .DecryptSSL()
                    .ListenOnPort(proxy_port)
                    .AllowRemoteClients();
                    //启动代理服务
                    FiddlerApplication.Startup(settings.Build());
                    int iport = proxy_port - 1;
                    if (proxy_port == 1)
                    {
                        iport = proxy_port + 1;
                    }
                    //创建https代理
                    FiddlerApplication.CreateProxyEndpoint(iport, true, oRootCert);
                }
                catch (Exception e)
                {
                    Program.Application_Catched_Exception(e);
                }
            });
            return tk;
        }


        public static void Stop()
        {
            if (handler != null)
                FiddlerApplication.BeforeRequest -= handler;
            FiddlerApplication.Shutdown();
            Methods.Remove_Cert(oRootCert);
        }

    }
}

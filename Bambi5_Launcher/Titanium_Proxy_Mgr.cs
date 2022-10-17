using Fiddler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;


namespace Collei_Launcher
{
    internal static class Titanium_Proxy_Mgr
    {
        public static ProxyServer ps = new ProxyServer();
        public static AsyncEventHandler<SessionEventArgs> handler;
        public static ExplicitProxyEndPoint ep;

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
        public static Task Run_Titanium(Details_Form details)
        {
            return Task.Run(() =>
            {
                try
                {
                    Stop();
                    ps.CertificateManager.EnsureRootCertificate();
                    handler = details.BeforeRequest;
                    ps.BeforeRequest += handler;
                    ps.ServerCertificateValidationCallback += OnCertificateValidation;
                    ep = new ExplicitProxyEndPoint(IPAddress.Any, Main_Form.lc.config.ProxyPort, true);
                    ep.BeforeTunnelConnectRequest += OnBeforeTunnelConnectRequest;
                    ps.AddEndPoint(ep);
                    ps.Start();
                    ps.SetAsSystemProxy(ep,ProxyProtocolType.AllHttp);
                }
                catch (Exception e)
                {
                    Program.Application_Catched_Exception(e);
                }
            });
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
                    ps.CertificateManager.RemoveTrustedRootCertificateAsAdmin(true);
                    ps.ServerCertificateValidationCallback -= OnCertificateValidation;
                    if(ep!=null)
                    {
                        ep.BeforeTunnelConnectRequest -= OnBeforeTunnelConnectRequest;
                    }
                }
            }
            catch(Exception e)
            {
                Program.Application_Catched_Exception(e);
            }
        }
    }
}

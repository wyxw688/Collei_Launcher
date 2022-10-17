using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Org.BouncyCastle.Crypto.Tls;

namespace Collei_Launcher
{
    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理线程异常
            Application.ThreadException += Application_ThreadException;
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Run(new Main_Form());
        }
        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            MessageBox.Show(str, "Application_ThreadException", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Application_Catched_Exception(Exception e)
        {
            string str = GetExceptionMsg(e);
            MessageBox.Show(str, "Application_Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            MessageBox.Show(str, "CurrentDomain_UnhandledException", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool Is_Package(string str)
        {
            return str.Contains("Version=")&&str.Contains("Culture=")&&str.Contains("PublicKeyToken=");
        }
        public static string GetExceptionMsg(Exception ex, [CallerMemberName] string memberName = "", string backStr = "")
        {
            if(ex.GetType() == typeof(FileNotFoundException)&&Is_Package((ex as FileNotFoundException).FileName))
            {
                return "请完整解压Collei_Launcher，确保依赖项(.dll)已解压到程序启动目录";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine();
            sb.AppendLine("[出现时间]:" + DateTime.Now.ToString());
            sb.AppendLine();
            if(memberName !="" && memberName !=null)
            {
                sb.AppendLine("[异常事件]:" + memberName);
                sb.AppendLine();
            }    
            if (ex != null)
            {
                sb.AppendLine("[异常类型]:" + ex.GetType().Name);
                sb.AppendLine();
                sb.AppendLine("[异常信息]:" + ex.Message);
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine("[未处理异常]:" + backStr);
                sb.AppendLine();
            }
            
            try
            {
                string log = sb.ToString();
                log += "[堆栈调用]:" + ex.StackTrace + "\n";
                File.AppendAllText(Application.StartupPath + @"\Exception.log", log);
                sb.AppendLine("日志已保存到" + Application.StartupPath + @"\Exception.log");
            }
            catch
            {
                sb.AppendLine("日志保存失败:" + Application.StartupPath + @"\Exception.log");
            }
            finally
            {
                sb.AppendLine();
            }
            sb.AppendLine("您可以将日志文件(Exception.log)通过邮件发送给bambi@bambi5.top获取帮助！");
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
    }
}

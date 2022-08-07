using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Collei_Launcher
{
    public class Index_Get
    {
        public string Result { get; set; }
        public long Use_time { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
    public class Def_status
    {
        public class Status
        {
            public int playerCount { get; set; }
            public string version { get; set; }
        }

        public class Root
        {
            public int retcode { get; set; }
            public Status status { get; set; }
        }

    }
    public class Cloud_Config
    {
        public class Config
        {
            public string lastverstr { get; set; }
            public int lastvercode { get; set; }
            public List<string> blacklist { get; set; }
            public string Notice { get; set; }
        }
        public List<ServersItem> servers { get; set; }
        public Config config { get; set; }
    }
    public class ServersItem
    {
        public string title { get; set; }
        public string host { get; set; }
        public int dispatch { get; set; }
        public int game { get; set; }
        public string content { get; set; }
    }
    public class ServersItem_List
    {
        public string title { get; set; }
        public string host { get; set; }
        public int dispatch { get; set; }
        public int game { get; set; }
        public string content { get; set; }
        public bool is_cloud { get; set; }

    }
    public class Local_Config
    {
        public class Config
        {
            public string Game_Path = Classes.GameRegReader.GetGameExePath();

            public ushort ProxyPort = 8520;

            public bool Auto_Close_Proxy = true;

            public bool Show_Public_Server = true;

            public int lastvercode=0;
        }
        public List<ServersItem> servers;
        public Config config;
        public static void FixLC(ref Local_Config elc)
        {
            if(elc == null)
            {
                elc = new Local_Config();
            }
            if(elc.config==null)
            {
                elc.config = new Config();
            }
            if(elc.config.Game_Path == null)
            {
                elc.config.Game_Path = Classes.GameRegReader.GetGameExePath();
            }
            if (elc.servers == null)
            {
                elc.servers = new List<ServersItem>();
            }
        }
    }
    public class Proxy_Config
    {
        public bool ProxyEnable = false;
        public string ProxyServer { get; set; }
    }
}

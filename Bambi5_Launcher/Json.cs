using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Collei_Launcher
{
    public class Details_Get
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
        public string UpdateUrl { get; set; }
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
            public string Game_Path = Methods.GameRegReader.GetGameExePath();

            public ushort ProxyPort = 8520;

            public bool Auto_Close_Proxy = true;

            public bool Show_Public_Server = true;

            public int lastvercode = 0;
        }
        public List<ServersItem> servers;
        public Config config;
        public Patch_Config patch;
        public static void FixLC(ref Local_Config elc)
        {
            if (elc == null)
            {
                elc = new Local_Config();
            }
            if (elc.config == null)
            {
                elc.config = new Config();
            }
            if (elc.config.Game_Path == null)
            {
                elc.config.Game_Path = Methods.GameRegReader.GetGameExePath();
            }
            if (elc.servers == null)
            {
                elc.servers = new List<ServersItem>();
            }
            if(elc.patch == null)
            {
                elc.patch = new Patch_Config();
            }
        }
    }
    public class Proxy_Config
    {
        public bool ProxyEnable = false;
        public string ProxyServer { get; set; }
    }
    public class Patch_Config
    {
        public string Features_cn = strings.Features_cn;
        public string Features_os = strings.Features_os;
        public string Nopatch1 = strings.Nopatch1;
        public string Nopatch2_cn = strings.Nopatch2_cn;
        public string Nopatch2_os = strings.Nopatch2_os;
        public string Patched1 = strings.Patched1;
        public string Patched2_Meta = strings.Patched2_Meta;
        public string Patched2_UA = strings.Patched2_UA;
        public bool PatchP1 = true;
        public bool CheckChannel = true;
        public Channel SetChannel = Channel.CN;
    }
}

public enum Channel
{
    CN,OS
}

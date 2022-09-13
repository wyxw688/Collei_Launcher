using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Habits habits;
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
            if(elc.habits == null)
            {
                elc.habits = new Habits();
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
        public string Features_cn = Patch_Data.Features_cn;
        public string Features_os = Patch_Data.Features_os;
        public string Nopatch1 = Patch_Data.Nopatch1;
        public string Nopatch2_cn = Patch_Data.Nopatch2_cn;
        public string Nopatch2_os = Patch_Data.Nopatch2_os;
        public string Patched1 = Patch_Data.Patched1;
        public string Patched2_Meta = Patch_Data.Patched2_Meta;
        public string Patched2_UA = Patch_Data.Patched2_UA;
        public bool PatchP1 = true;
        public bool CheckChannel = true;
        public Channel SetChannel = Channel.CN;
    }
    public class Habits
    {
        public Size MainFormSize = Main_Form.form.Size;

        public string MetaFile_Input = Main_Form.form.MetaFile_Input_textBox.Text;
        public bool INOUT_Meta = Main_Form.form.INOUT_Meta_checkBox.Checked;
        public string MetaFile_Output = Main_Form.form.MetaFile_Output_textBox.Text;

        public string UAFile_Input = Main_Form.form.UAFile_Input_textBox.Text;
        public bool INOUT_UA = Main_Form.form.INOUT_UA_checkBox.Checked;
        public string UAFile_Output = Main_Form.form.UAFile_Output_textBox.Text;
    }
}

public enum Channel
{
    CN,OS
}
public enum Meta_Action
{
    Patch,UnPatch,Encrypt,Decrypt
}

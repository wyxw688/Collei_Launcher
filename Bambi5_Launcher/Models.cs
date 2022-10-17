using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collei_Launcher
{
    [Serializable]
    public class TPSet
    {
        public string CCV2Url = "http://launcher.bambi5.top/Main?action=Get_Config&data=&lang=<lang>&ver=<ver>";
        public string CPCUrl = null;
        public bool AllowAddServer = true;
        public bool MustShownCloudServers = false;
        public bool AllowPatchMeta = true;
        public bool AllowPatchUA = true;
        public bool AllowModify = true;
    }

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
        public class Update
        {
            public string Content { get; set; }
            public int LastVerCode { get; set; }
            public string Target { get; set; }
        }
        public class Notice
        {
            public string Content { get; set; }
            public string Target { get; set; }
            public NoticeType type = NoticeType.text;
            public PictureBoxSizeMode sizemode = PictureBoxSizeMode.Zoom;
            public bool ClickAble = false;
            public Color textcolor = Color.Black;
        }
        public class AuthorLabel
        {
            public string Content = "By Bambi5";
            public bool LeftClickAble = true;
            public string Target = "http://launcher.bambi5.top";
            public Color textcolor = System.Drawing.SystemColors.ControlLight;
        }
        public AuthorLabel author = new AuthorLabel();
        public List<ServersItem> servers = new List<ServersItem>();
        public Update update = new Update();
        public Notice notice =new Notice();
    }
    public class ServersItem
    {
        public string title { get; set; }
        public string host { get; set; }
        public int dispatch { get; set; }
        public string content { get; set; }
    }
    public class ServersItem_List
    {
        public string title { get; set; }
        public string host { get; set; }
        public int dispatch { get; set; }
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

            public bool Show_Cloud_Server = true;

            public bool StartupCheckProxy=true;

            public int lastvercode = 0;

            public bool UseHabit = true;

            public ProxyMode proxyMode = ProxyMode.Titanium;
        }
        public List<ServersItem> servers = new List<ServersItem>();
        public Config config = new Config();
        public Patch_Config patch = new Patch_Config();
        public Habits habits = new Habits();
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
        public FormWindowState MainFormState = Main_Form.form.WindowState;
        public Point MainFormLocation = Main_Form.form.Location;

        public string MetaFile_Input = Main_Form.form.MetaFile_Input_textBox.Text;
        public bool INOUT_Meta = Main_Form.form.INOUT_Meta_checkBox.Checked;
        public string MetaFile_Output = Main_Form.form.MetaFile_Output_textBox.Text;

        public string UAFile_Input = Main_Form.form.UAFile_Input_textBox.Text;
        public bool INOUT_UA = Main_Form.form.INOUT_UA_checkBox.Checked;
        public string UAFile_Output = Main_Form.form.UAFile_Output_textBox.Text;

        public int Title_columnHeader_Width = Main_Form.form.Title_columnHeader.Width;
        public int Host_columnHeader_Width = Main_Form.form.Host_columnHeader.Width;
        public int Dispatch_columnHeader_Width = Main_Form.form.Dispatch_columnHeader.Width;
        public int Count_columnHeader_Width = Main_Form.form.Count_columnHeader.Width;
        public int Ver_columnHeader_Width = Main_Form.form.Ver_columnHeader.Width;
        public int Ping_columnHeader_Width = Main_Form.form.Ping_columnHeader.Width;
        public int Content_columnHeader_Width = Main_Form.form.Content_columnHeader.Width;

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

public enum ProxyMode
{
     Titanium, Fiddler
}
public enum NoticeType
{
    text,img,IEWebpage,EdgeWebpage
}
public enum NoticeErrorType
{
    noticeerr, clouderr, imgerr
}

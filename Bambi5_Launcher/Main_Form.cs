using Collei_Launcher.Properties;
using Microsoft.Web.WebView2.Core;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collei_Launcher
{
    public partial class Main_Form : Form
    {

        public bool loaded = false;
        public static Main_Form form;
        public int VerCode;
        public static Cloud_Config cc;
        public static Local_Config lc;
        public bool is_first_check = true;
        public string config_path = Application.StartupPath + @"\config.json";
        public List<ServersItem_List> servers = new List<ServersItem_List>();
        public int ci;
        public string LastloadPic = null;
        public PictureBoxSizeMode LastSizeMode;
        public bool IsFirstLoadIE = true;
        public bool IsFirstLoadEdge = true;
        public static TPSet tps = new TPSet();

        public Main_Form()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            form = this;
            InitializeComponent();
            Show_Ver();
            Load_Local_Config();
            ThirdPartyMgr.LoadSettings();
            Check_Proxy();
            Methods.SetCertificatePolicy();
        }
        public void TpsApply()
        {
            Meta_tabPage.Parent = null;
            UA_tabPage.Parent = null;
            Patch_Settings_tabPage.Parent = null;
            Settings_tabPage.Parent = null;

            Meta_tabPage.Parent = tps.AllowPatchMeta ? Main_tabControl : null;
            UA_tabPage.Parent = tps.AllowPatchUA ? Main_tabControl : null;
            Patch_Settings_tabPage.Parent = String.IsNullOrEmpty(tps.CPCUrl) ? Main_tabControl : null;
            Reset_PC_button.Visible = String.IsNullOrEmpty(tps.CPCUrl)?true:false;
            Settings_tabPage.Parent = Main_tabControl;

            if (tps.MustShownCloudServers)
            {
                Show_Cloud_Server_checkBox.Checked = true;
                Show_Cloud_Server_checkBox.Enabled = false;
                lc.config.Show_Cloud_Server = true;
            }
            else
            {
                Show_Cloud_Server_checkBox.Enabled = true;
            }
            NoServerTip_label.Text = tps.AllowAddServer ? "右键添加服务器" : "管理员还没有配置服务器哦\n一会再来看看吧";
        }
        private void Show_Ver()
        {
            //this.Servers_listView.Controls.Add(this.NoServerTip_label);
            bool isdebug = Methods.DebugBuild(Assembly.GetExecutingAssembly());
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string ver = string.Format("(v{0}.{1}.{2})", version.Major, version.Minor, version.Build);
            VerCode = version.Major * 100 + version.Minor * 10 + version.Build;
            this.Text += ver;
            this.Text += isdebug ? " - Debug" : " - Release";
        }

        public string GetConfigV2Url()
        {
            return tps.CCV2Url.Replace("<lang>", Thread.CurrentThread.CurrentUICulture.Name).Replace("<ver>", VerCode.ToString());
        }
        public void Check_Proxy()
        {
            if (lc.config.StartupCheckProxy && Methods.using_proxy().ProxyEnable)
            {
                string show = "检测到您当前开启了系统代理，这可能是启动器上次未正确关闭导致的,代理配置不正确会导致无法连接网络,当前的代理配置如下\n";
                show += Methods.Get_Proxy_Text();
                show += "\n若您想关闭代理,请点击“是”，若不想关闭代理，请点击“否”";
                if (MessageBox.Show(show, "要关闭代理吗?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Methods.Clear_Proxy();
                }
            }
        }
        private void Proxy_status_toolStripStatusLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Methods.Get_Proxy_Text(), "代理状态", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Home_tabPage_Enter(object sender, EventArgs e)
        {
            UpdateAndNotice();
        }
        public void Load_Author(Cloud_Config.AuthorLabel au)
        {
            Author_label.Text = au.Content;
            Author_label.ForeColor = au.textcolor;
            if (au.LeftClickAble)
            {
                Author_label.Cursor = Cursors.Hand;
            }
            else
            {
                Author_label.Cursor = Cursors.Default;
            }
        }
        public void Refresh_Notice(Cloud_Config.Notice notice, NoticeErrorType ccerror = NoticeErrorType.noticeerr)
        {
            // return Task.Run(() =>
            //{
            if (notice == null)
            {
                Notice_label.Visible = true;
                Notice_pictureBox.Visible = false;
                Notice_webBrowser.Visible = false;

                if (ccerror == NoticeErrorType.noticeerr)
                {
                    Notice_label.Text = "获取公告失败";
                }
                else if (ccerror == NoticeErrorType.clouderr)
                {
                    Notice_label.Text = "获取云配置文件失败";
                }
                else if (ccerror == NoticeErrorType.imgerr)
                {
                    Notice_label.Text = "图片加载失败";
                }
                Notice_label.ForeColor = System.Drawing.Color.Red;
                return;
            }
            switch (notice.type)
            {
                default:
                case NoticeType.text:
                    {
                        Notice_label.Visible = true;
                        Notice_pictureBox.Visible = false;
                        Notice_webBrowser.Visible = false;
                        Notice_webView.Visible = false;

                        Notice_label.Text = notice.Content;
                        Notice_label.ForeColor = notice.textcolor;
                        if (notice.ClickAble)
                        {
                            Notice_label.Cursor = Cursors.Hand;
                        }
                        else
                        {
                            Notice_label.Cursor = Cursors.Default;
                        }
                        break;
                    }
                case NoticeType.img:
                    {
                        Notice_label.Visible = false;
                        Notice_pictureBox.Visible = true;
                        Notice_webBrowser.Visible = false;
                        Notice_webView.Visible = false;

                        if (LastloadPic != notice.Content || LastSizeMode != notice.sizemode)
                        {
                            Task.Run(() =>
                            {
                                try
                                {
                                    Notice_pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                                    Notice_pictureBox.Image = Resources.loading;

                                    Notice_pictureBox.Image = Image.FromStream(WebRequest.Create(notice.Content).GetResponse().GetResponseStream());
                                    Notice_pictureBox.SizeMode = notice.sizemode;
                                    LastloadPic = notice.Content;
                                    LastSizeMode = notice.sizemode;
                                }
                                catch (Exception e)
                                {
                                    Debug.Print("Pic Load error" + e.Message);
                                    Refresh_Notice(null, NoticeErrorType.imgerr);
                                }
                            });
                        }
                        if (notice.ClickAble)
                        {
                            Notice_pictureBox.Cursor = Cursors.Hand;
                        }
                        else
                        {
                            Notice_pictureBox.Cursor = Cursors.Default;
                        }
                        break;
                    }
                case NoticeType.IEWebpage:
                    {
                        if (IsFirstLoadIE)
                        {
                            Notice_webBrowser.Navigate(notice.Content);
                            IsFirstLoadIE = false;
                        }

                        Notice_label.Visible = false;
                        Notice_pictureBox.Visible = false;
                        Notice_webBrowser.Visible = true;
                        Notice_webView.Visible = false;

                        break;
                    }
                case NoticeType.EdgeWebpage:
                    {

                        if (IsFirstLoadEdge)
                        {
                            Notice_webView.EnsureCoreWebView2Async().ContinueWith(t =>
                            {
                                Notice_webView.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
                                Notice_webView.CoreWebView2.Navigate(notice.Content);

                                Notice_label.Visible = false;
                                Notice_pictureBox.Visible = false;
                                Notice_webBrowser.Visible = false;
                                Notice_webView.Visible = true;
                            });
                            IsFirstLoadEdge = false;
                        }
                        if (Notice_webView.CoreWebView2 != null)
                        {
                            Notice_label.Visible = false;
                            Notice_pictureBox.Visible = false;
                            Notice_webBrowser.Visible = false;
                            Notice_webView.Visible = true;
                        }
                        break;
                    }
            }
            //   });
        }
        private void CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            Notice_webView.CoreWebView2.Navigate(e.Uri.ToString());
            e.Handled = true;
        }
        public Task GetCloudConfigV2()
        {
            return Task.Run(() =>
             {
                 try
                 {
                     string ccs = Methods.Get(GetConfigV2Url());
                     if (ccs == null)
                     {
                         Refresh_Notice(null, NoticeErrorType.clouderr);
                         return;
                     }
                     cc = JsonConvert.DeserializeObject<Cloud_Config>(ccs);
                 }
                 catch (Exception e)
                 {
                     Refresh_Notice(null, NoticeErrorType.clouderr);
                 }
             });
        }
        public void UpdateAndNotice()
        {
            try
            {
                while (lc == null)
                {
                    Debug.Print("等待本地配置加载");
                    Thread.Sleep(100);
                }
                GetCloudConfigV2().ContinueWith(t => CloudConfigAction(), TaskScheduler.FromCurrentSynchronizationContext());

            }
            catch (Exception ex)
            {
                Program.Application_Catched_Exception(ex);
            }
        }
        public void CloudConfigAction()
        {
            if (cc == null) { return; }
            if (cc.notice != null) { Refresh_Notice(cc.notice); } else { Refresh_Notice(null, NoticeErrorType.noticeerr); }
            if (cc.author != null) { Load_Author(cc.author); }
            if (cc.update != null && is_first_check && VerCode < cc.update.LastVerCode && lc.config.lastvercode != cc.update.LastVerCode)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("发现有新版本，是否更新?");
                stringBuilder.AppendLine("[当前版本]:" + VerCode); ;
                stringBuilder.AppendLine("[最新版本]:" + cc.update.LastVerCode);
                stringBuilder.AppendLine("[更新内容]:");
                cc.update.Content = cc.update.Content != null ? cc.update.Content : "无";
                stringBuilder.AppendLine(cc.update.Content);
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("点击“是”，跳转到更新连接");
                stringBuilder.AppendLine("点击“否”，跳过此版本");
                stringBuilder.AppendLine("点击“取消”，本次关闭此消息框");
                DialogResult dgr = MessageBox.Show(stringBuilder.ToString(), "版本更新提醒", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dgr == DialogResult.Yes)
                {
                    Methods.Start(cc.update.Target);
                }
                else if (dgr == DialogResult.No)
                {
                    lc.config.lastvercode = cc.update.LastVerCode;
                }
            }
            is_first_check = false;
        }
        private void Auto_close_proxy_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            lc.config.Auto_Close_Proxy = Auto_close_proxy_checkBox.Checked;
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Apply_Patch_Config();
            if (lc.config.UseHabit)
            {
                Save_Habits_ToLC();
            }
            Save_Local_Config();
            if (lc.config.Auto_Close_Proxy)
            {
                Methods.Clear_Proxy();
            }
            System.Environment.Exit(0);
        }
        public void Load_Local_Config(object sender = null, EventArgs e = null)
        {
            Debug.Print(config_path);
            if (File.Exists(config_path))
            {
                Debug.Print("已找到config文件");
                string lcs = File.ReadAllText(config_path);
                try
                {
                    lc = JsonConvert.DeserializeObject<Local_Config>(lcs);
                }
                catch (Exception ex)
                {
                    Debug.Print("解析json时出现错误:" + ex.Message);
                }
            }
            else
            {
                Debug.Print("未找到config文件");
            }

            Local_Config.FixLC(ref lc);
            LoadSettingsToForm();
            if (lc.config.UseHabit)
            {
                Apply_Habits_ToForm();
            }
        }
        public void Apply_Habits_ToForm()
        {
            if (WindowState != FormWindowState.Minimized)
            {
                WindowState = lc.habits.MainFormState;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                Size = lc.habits.MainFormSize;
            }
            Debug.Print(lc.habits.MainFormLocation.ToString());
            if (lc.habits.MainFormLocation != Point.Empty)
            {
                Location = lc.habits.MainFormLocation;
            }
            else
            {
                StartPosition = FormStartPosition.CenterScreen;
            }

            if (!File.Exists(lc.habits.MetaFile_Input))
            {
                lc.habits.MetaFile_Input = "";
            }
            if (!File.Exists(lc.habits.UAFile_Input))
            {
                lc.habits.UAFile_Input = "";
            }
            MetaFile_Input_textBox.Text = lc.habits.MetaFile_Input;
            INOUT_Meta_checkBox.Checked = lc.habits.INOUT_Meta;
            MetaFile_Output_textBox.Text = lc.habits.MetaFile_Output;

            UAFile_Input_textBox.Text = lc.habits.UAFile_Input;
            INOUT_UA_checkBox.Checked = lc.habits.INOUT_UA;
            UAFile_Output_textBox.Text = lc.habits.UAFile_Output;

            if (MetaFile_Input_textBox.Text == "")
            {
                if (File.Exists(Path.GetDirectoryName(lc.config.Game_Path) + @"\YuanShen_Data\Managed\Metadata\global-metadata.dat"))
                {
                    MetaFile_Input_textBox.Text = Path.GetDirectoryName(lc.config.Game_Path) + @"\YuanShen_Data\Managed\Metadata\global-metadata.dat";
                }
                else if (File.Exists(Path.GetDirectoryName(lc.config.Game_Path) + @"\GenshinImpact_Data\Managed\Metadata\global-metadata.dat"))
                {
                    MetaFile_Input_textBox.Text = Path.GetDirectoryName(lc.config.Game_Path) + @"\GenshinImpact_Data\Managed\Metadata\global-metadata.dat";
                }
            }
            if (UAFile_Input_textBox.Text == "")
            {
                if (File.Exists(Path.GetDirectoryName(lc.config.Game_Path) + @"\YuanShen_Data\Native\UserAssembly.dll"))
                {
                    UAFile_Input_textBox.Text = Path.GetDirectoryName(lc.config.Game_Path) + @"\YuanShen_Data\Native\UserAssembly.dll";
                }
                else if (File.Exists(Path.GetDirectoryName(lc.config.Game_Path) + @"\GenshinImpact_Data\Native\UserAssembly.dll"))
                {
                    UAFile_Input_textBox.Text = Path.GetDirectoryName(lc.config.Game_Path) + @"\GenshinImpact_Data\Native\UserAssembly.dll";
                }
            }

            Title_columnHeader.Width = lc.habits.Title_columnHeader_Width;
            Host_columnHeader.Width = lc.habits.Host_columnHeader_Width;
            Dispatch_columnHeader.Width = lc.habits.Dispatch_columnHeader_Width;
            Count_columnHeader.Width = lc.habits.Count_columnHeader_Width;
            Ver_columnHeader.Width = lc.habits.Ver_columnHeader_Width;
            Ping_columnHeader.Width = lc.habits.Ping_columnHeader_Width;
            Content_columnHeader.Width = lc.habits.Content_columnHeader_Width;

        }
        public void LoadSettingsToForm(bool Save = true)
        {
            Proxy_port_numericUpDown.Value = lc.config.ProxyPort;
            Auto_close_proxy_checkBox.Checked = lc.config.Auto_Close_Proxy;
            Use_Habits_checkBox.Checked = lc.config.UseHabit;
            Show_Cloud_Server_checkBox.Checked = lc.config.Show_Cloud_Server;
            if (lc.config.Game_Path == null)
            {
                lc.config.Game_Path = Methods.GameRegReader.GetGameExePath();
            }
            if (lc.config.Game_Path != null)
            {
                Game_Path_textBox.Text = lc.config.Game_Path;
            }
            Proxy_Mode_comboBox.SelectedIndex = (int)lc.config.proxyMode;
            Startup_Check_Proxy_checkBox.Checked = lc.config.StartupCheckProxy;
            CheckChannel_checkBox.Checked = lc.patch.CheckChannel;
            PatchP1_checkBox.Checked = lc.patch.PatchP1;
            Nopatch1_textBox.Text = lc.patch.Nopatch1;
            Patched1_textBox.Text = lc.patch.Patched1;
            Nopatch2_cn_textBox.Text = lc.patch.Nopatch2_cn;
            Nopatch2_os_textBox.Text = lc.patch.Nopatch2_os;
            Patched2_Meta_textBox.Text = lc.patch.Patched2_Meta;
            Patched2_UA_textBox.Text = lc.patch.Patched2_UA;
            Features_cn_textBox.Text = lc.patch.Features_cn;
            Features_os_textBox.Text = lc.patch.Features_os;
            if (lc.patch.SetChannel == Channel.CN)
            {
                CN_Channel_radioButton.Checked = true;
            }
            else if (lc.patch.SetChannel == Channel.OS)
            {
                OS_Channel_radioButton.Checked = true;
            }

            if (Save)
            {
                Save_Local_Config();
            }

        }
        private void Show_Cloud_Server_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            lc.config.Show_Cloud_Server = Show_Cloud_Server_checkBox.Checked;
        }
        public void Load_Servers()
        {
            servers.Clear();
            if (lc.config.Show_Cloud_Server && cc != null)
            {
                for (int i = 0; i < cc.servers.Count; i++)
                {
                    ServersItem_List ser = new ServersItem_List();
                    ser.title = cc.servers[i].title;
                    ser.host = cc.servers[i].host;
                    ser.dispatch = cc.servers[i].dispatch;
                    ser.content = cc.servers[i].content;
                    ser.is_cloud = true;
                    servers.Add(ser);
                }
            }
            for (int i = 0; i < lc.servers.Count; i++)
            {
                ServersItem_List ser = new ServersItem_List();
                ser.title = lc.servers[i].title;
                ser.host = lc.servers[i].host;
                ser.dispatch = lc.servers[i].dispatch;
                ser.content = lc.servers[i].content;
                ser.is_cloud = false;
                servers.Add(ser);
            }
            Load_Server_List();
        }
        public void Load_Server_List()
        {
            Servers_listView.BeginUpdate();
            Servers_listView.Items.Clear();
            int local_index = 0;
            for (int i = 0; i < servers.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = servers[i].title;
                lvi.SubItems.Add(servers[i].host);
                lvi.SubItems.Add(servers[i].dispatch + "");
                lvi.SubItems.Add("N/A");
                lvi.SubItems.Add("N/A");
                lvi.SubItems.Add("N/A");
                lvi.SubItems.Add(servers[i].content + "");
                if (servers[i].is_cloud)
                {
                    lvi.Tag = -1;
                }
                else
                {
                    lvi.Tag = local_index;
                    local_index++;
                }
                Servers_listView.Items.Add(lvi);
            }
            if (Servers_listView.Items.Count == 0)
            {
                NoServerTip_label.Visible = true;
            }
            else
            {
                NoServerTip_label.Visible = false;
            }
            Servers_listView.EndUpdate();
            loaded = true;
            Load_Server_Status();
        }
        public void Save_Local_Config()
        {
            Debug.Print("正在保存config"); ;
            Local_Config.FixLC(ref lc);
            File.WriteAllText(config_path, JsonConvert.SerializeObject(lc));
            Debug.Print("已保存config");
            LoadSettingsToForm(false);
        }
        public void Choice_Game_Path_button_Click(object sender, EventArgs e)
        {
            string path = Methods.Choice_Path("国服游戏文件|YuanShen.exe|国际服游戏文件|GenshinImpact.exe", "选择游戏文件", null);
            if (path == null)
            {
                return;
            }
            lc.config.Game_Path = path;
            DefaultPatchPath();
            LoadSettingsToForm();
        }

        private void Game_Path_textBox_TextChanged(object sender, EventArgs e)
        {
            lc.config.Game_Path = Game_Path_textBox.Text;
        }

        private void Servers_List_tabPage_Enter(object sender, EventArgs e)
        {
            Status_timer.Enabled = true;
            Load_Servers();
            Load_Server_Status();

        }

        private void Servers_listView_MouseDown(object sender, MouseEventArgs e)
        {
            if (!loaded)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                var item = Servers_listView.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    ci = item.Index;
                    if (servers[ci].is_cloud)
                    {
                        添加ToolStripMenuItem.Visible = true;
                        连接ToolStripMenuItem.Visible = true;
                        检查连接ToolStripMenuItem.Visible = true;
                        编辑ToolStripMenuItem.Visible = false;
                        删除ToolStripMenuItem.Visible = false;
                        toolStripSeparator1.Visible = true;
                        toolStripSeparator2.Visible = false;
                    }
                    else
                    {
                        添加ToolStripMenuItem.Visible = true;
                        连接ToolStripMenuItem.Visible = true;
                        检查连接ToolStripMenuItem.Visible = true;
                        编辑ToolStripMenuItem.Visible = true;
                        删除ToolStripMenuItem.Visible = true;
                        toolStripSeparator1.Visible = true;
                        toolStripSeparator2.Visible = true;
                    }
                }
                else
                {
                    添加ToolStripMenuItem.Visible = true;
                    连接ToolStripMenuItem.Visible = false;
                    检查连接ToolStripMenuItem.Visible = false;
                    编辑ToolStripMenuItem.Visible = false;
                    删除ToolStripMenuItem.Visible = false;
                    toolStripSeparator1.Visible = false;
                    toolStripSeparator2.Visible = false;
                }
                if (!tps.AllowAddServer)
                {
                    添加ToolStripMenuItem.Visible = false;
                    toolStripSeparator1.Visible = false;
                }
                Servers_contextMenuStrip.Show(Servers_listView, e.Location);
            }
        }

        private void Servers_listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!loaded)
            {
                return;
            }
            var item = Servers_listView.GetItemAt(e.X, e.Y);
            if (item == null)
            {
                return;
            }
            ci = item.Index;
            连接ToolStripMenuItem_Click(null, null);
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServersItem ser = Edit_Form.Edit_Server();
            if (ser != null)
            {
                lc.servers.Add(ser);
                Save_Local_Config();
                Load_Servers();
            }
        }

        private void 连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Details_Form.Open_Index(servers[ci]);
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = (int)Servers_listView.Items[ci].Tag;
            ServersItem ser = Edit_Form.Edit_Server(lc.servers[index]);
            if (ser != null)
            {
                lc.servers[index] = ser;
                Save_Local_Config();
                Load_Servers();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lc.servers.RemoveAt((int)Servers_listView.Items[ci].Tag);
            Load_Servers();
        }

        private void Open_Check_button_Click(object sender, EventArgs e)
        {
            Check_Form.Open_Form();
        }

        private void 检查连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Check_Form.Open_Form(servers[ci]);
        }
        Thread th;
        int stc = 0;
        int etc = 0;
        public void Load_Server_Status()
        {
            if (th != null)
            {
                th.Abort();
            }
            th = new Thread(() =>
              {
                  try
                  {
                      for (int i = 0; i < servers.Count; i++)
                      {
                          int s = i;
                          //while(stc - etc >=3){Thread.Sleep(100);}
                          new Thread(() =>
                          {
                              stc++;
                              try
                              {
                                  string str = "https://" + servers[s].host + ":" + servers[s].dispatch + "/status/server";
                                  Debug.Print(str);
                                  Details_Get ig = Methods.Get_for_Index(str);
                                  if (ig.Use_time >= 0 && ig.StatusCode == System.Net.HttpStatusCode.OK)
                                  {
                                      Def_status.Root df = JsonConvert.DeserializeObject<Def_status.Root>(ig.Result);
                                      Servers_listView.Items[s].SubItems[3].Text = df.status.playerCount.ToString();
                                      Servers_listView.Items[s].SubItems[4].Text = df.status.version;
                                  }
                                  else
                                  {
                                      Servers_listView.Items[s].SubItems[3].Text = "N/A";
                                      Servers_listView.Items[s].SubItems[4].Text = "N/A";
                                  }
                                  try
                                  {
                                      PingReply reply = new Ping().Send(servers[s].host, 1000);

                                      if (reply.Status == IPStatus.Success)
                                          Servers_listView.Items[s].SubItems[5].Text = reply.RoundtripTime + "ms";
                                      /*
                                     var sbuilder = new StringBuilder();
                                      sbuilder.AppendLine(string.Format("Address: {0} ", reply.Address.ToString()));
                                      sbuilder.AppendLine(string.Format("RoundTrip time: {0} ", reply.RoundtripTime));
                                      sbuilder.AppendLine(string.Format("Time to live: {0} ", reply.Options.Ttl));
                                      sbuilder.AppendLine(string.Format("Don't fragment: {0} ", reply.Options.DontFragment));
                                      sbuilder.AppendLine(string.Format("Buffer size: {0} ", reply.Buffer.Length));
                                      Console.WriteLine(sbuilder.ToString());
                                      */
                                  }
                                  catch
                                  {
                                      Servers_listView.Items[s].SubItems[5].Text = "N/A";
                                  }
                              }
                              catch (NullReferenceException e)
                              {
                                  Debug.Print("加载状态出错NullReferenceException:" + e.Message);
                              }
                              catch (Exception e)
                              {
                                  Debug.Print("加载状态出错:" + e.Message);
                              }
                              finally
                              {
                                  etc++;
                              }
                          }).Start();
                      }
                  }
                  catch (Exception ex)
                  {
                      Debug.Print(ex.Message);
                  }
              });
            th.Start();
        }


        private void Status_timer_Tick(object sender, EventArgs e)
        {
            Load_Server_Status();
        }


        private void Find_GameExe_button_Click(object sender, EventArgs e)
        {
            string path = Methods.GameRegReader.GetGameExePath();
            if (path == null)
            {
                MessageBox.Show("自动寻找路径失败", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("找到游戏路径:\n" + path + "\n点击“是”：设置为游戏路径\n点击“否”：不设为游戏路径", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                lc.config.Game_Path = path;
                DefaultPatchPath();
                LoadSettingsToForm();
            }
        }

        public void DefaultPatchPath()
        {
            if (File.Exists(Path.GetDirectoryName(lc.config.Game_Path) + @"\YuanShen_Data\Managed\Metadata\global-metadata.dat"))
            {
                MetaFile_Input_textBox.Text = Path.GetDirectoryName(lc.config.Game_Path) + @"\YuanShen_Data\Managed\Metadata\global-metadata.dat";
            }
            else if (File.Exists(Path.GetDirectoryName(lc.config.Game_Path) + @"\GenshinImpact_Data\Managed\Metadata\global-metadata.dat"))
            {
                MetaFile_Input_textBox.Text = Path.GetDirectoryName(lc.config.Game_Path) + @"\GenshinImpact_Data\Managed\Metadata\global-metadata.dat";
            }
            if (File.Exists(Path.GetDirectoryName(lc.config.Game_Path) + @"\YuanShen_Data\Native\UserAssembly.dll"))
            {
                UAFile_Input_textBox.Text = Path.GetDirectoryName(lc.config.Game_Path) + @"\YuanShen_Data\Native\UserAssembly.dll";
            }
            else if (File.Exists(Path.GetDirectoryName(lc.config.Game_Path) + @"\GenshinImpact_Data\Native\UserAssembly.dll"))
            {
                UAFile_Input_textBox.Text = Path.GetDirectoryName(lc.config.Game_Path) + @"\GenshinImpact_Data\Native\UserAssembly.dll";
            }
        }
        private void Servers_List_tabPage_Leave(object sender, EventArgs e)
        {
            Status_timer.Enabled = false;
        }

        private void Set_MetaInputpath_button_Click(object sender, EventArgs e)
        {
            string path = Methods.Choice_Path("global-metadata文件|global-metadata.dat|所有文件|*.*", "选择文件", Path.GetDirectoryName(lc.config.Game_Path));
            if (path == null)
            {
                return;
            }
            MetaFile_Input_textBox.Text = path;
        }

        private void Outpath_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Output_panel.Enabled = !INOUT_Meta_checkBox.Checked;
        }

        private void Set_MetaOutputpath_button_Click(object sender, EventArgs e)
        {
            string path = Methods.Choice_Save_Path("dat文件|*.dat|所有文件|*.*", "选择保存位置", Path.GetDirectoryName(lc.config.Game_Path), "global-metadata.dat");
            if (path == null)
            {
                return;
            }
            MetaFile_Output_textBox.Text = path;
        }

        public void Meta_Actions(Meta_Action action)
        {
            Show_Meta_Doing_Tip(true);
            string input = MetaFile_Input_textBox.Text;
            string output;
            if (!INOUT_Meta_checkBox.Checked)
            {
                output = MetaFile_Output_textBox.Text;
            }
            else
            {
                output = input;
            }
            if (input == null || output == null || input == "" || output == "")
            {
                MessageBox.Show("路径未选择！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Show_Meta_Doing_Tip(false);
                return;
            }
            Task.Run(() =>
             {
                 var pc = lc.patch;
                 string show = "OK";
                 if (!String.IsNullOrEmpty(tps.CPCUrl))
                 {
                     try
                     {
                         pc = JsonConvert.DeserializeObject<Patch_Config>(Methods.Get(tps.CPCUrl));
                     }
                     catch (Exception e)
                     {
                         Debug.Print($"CPC GET Fail:{e.Message}");
                         MessageBox.Show("获取修补方案失败", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                     }
                 }
                 try
                 {

                     switch (action)
                     {
                         case Meta_Action.Patch:
                             {
                                 show = Meta_Patch_Mgr.Patch_File(input, output, pc);
                                 break;
                             }
                         case Meta_Action.UnPatch:
                             {
                                 show = Meta_Patch_Mgr.UnPatch_File(input, output, pc);
                                 break;
                             }
                         case Meta_Action.Encrypt:
                             {
                                 Meta_Patch_Mgr.Encrypt_File(input, output);
                                 break;
                             }
                         case Meta_Action.Decrypt:
                             {
                                 Meta_Patch_Mgr.Decrypt_File(input, output);
                                 break;
                             }
                     }

                     MessageBox.Show(show, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     GC.Collect();
                 }
                 catch (System.Runtime.InteropServices.SEHException)
                 {
                     MessageBox.Show("在解包或打包Meta时出现了错误，这可能是由以下原因导致的\n\n①尝试修补(或反修补)已经被解包过的Meta文件\n②Meta文件已被损坏\n\n若您已经解包过Meta，请尝试打包后重试\n若您已经打包过Meta，请尝试解包后重试", "解包/打包时出现错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                catch (Exception e)
                 {
                     Program.Application_Catched_Exception(e);
                 }
             }).ContinueWith(task => Show_Meta_Doing_Tip(false));
        }
        public void Show_Meta_Doing_Tip(bool Doing)
        {
            Meta_DoingTip_label.Visible = Doing;
            Meta_Actions_groupBox.Enabled = !Doing;
        }

        private void Decrypt_File_button_Click(object sender, EventArgs e)
        {
            Meta_Actions(Meta_Action.Decrypt);
        }

        private void Encrypt_File_button_Click(object sender, EventArgs e)
        {
            Meta_Actions(Meta_Action.Encrypt);
        }

        private void Patch_Meta_button_Click(object sender, EventArgs e)
        {
            Meta_Actions(Meta_Action.Patch);
        }

        private void UnPatch_Meta_button_Click(object sender, EventArgs e)
        {
            Meta_Actions(Meta_Action.UnPatch);
        }

        private void CheckChannel_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetChannel_Panel.Enabled = !CheckChannel_checkBox.Checked;
        }

        private void Reset_PC_button_Click(object sender, EventArgs e)
        {
            lc.patch = new Patch_Config();
            Save_Local_Config();
            MessageBox.Show("OK", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Save_PC_button_Click(object sender, EventArgs e)
        {
            Apply_Patch_Config();
            Save_Local_Config();
            MessageBox.Show("OK", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Apply_Patch_Config()
        {
            lc.patch.CheckChannel = CheckChannel_checkBox.Checked;
            lc.patch.PatchP1 = PatchP1_checkBox.Checked;
            lc.patch.Nopatch1 = Nopatch1_textBox.Text;
            lc.patch.Patched1 = Patched1_textBox.Text;
            lc.patch.Nopatch2_cn = Nopatch2_cn_textBox.Text;
            lc.patch.Nopatch2_os = Nopatch2_os_textBox.Text;
            lc.patch.Patched2_Meta = Patched2_Meta_textBox.Text;
            lc.patch.Patched2_UA = Patched2_UA_textBox.Text;
            lc.patch.Features_cn = Features_cn_textBox.Text;
            lc.patch.Features_os = Features_os_textBox.Text;
            if (CN_Channel_radioButton.Checked)
            {
                lc.patch.SetChannel = Channel.CN;
            }
            else if (OS_Channel_radioButton.Checked)
            {
                lc.patch.SetChannel = Channel.OS;
            }
            Debug.Print("修补设置已应用");
        }
        private void Set_UAInputpath_button_Click(object sender, EventArgs e)
        {
            string path = Methods.Choice_Path("UserAssembly文件|UserAssembly.dll|所有文件|*.*", "选择文件", Path.GetDirectoryName(lc.config.Game_Path));
            if (path == null)
            {
                return;
            }
            UAFile_Input_textBox.Text = path;
        }

        private void Set_UAOutputpath_button_Click(object sender, EventArgs e)
        {
            string path = Methods.Choice_Save_Path("dll文件|*.dll|所有文件|*.*", "选择保存位置", Path.GetDirectoryName(lc.config.Game_Path), "UserAssembly.dll");
            if (path == null)
            {
                return;
            }
            UAFile_Output_textBox.Text = path;
        }
        public void UA_Actions(bool ispatch)
        {
            Show_UA_Doing_Tip(true);
            string input = UAFile_Input_textBox.Text;
            string output;
            if (!INOUT_UA_checkBox.Checked)
            {
                output = UAFile_Output_textBox.Text;
            }
            else
            {
                output = input;
            }
            if (input == null || output == null || input == "" || output == "")
            {
                MessageBox.Show("路径未选择！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Show_UA_Doing_Tip(false);
                return;
            }

            Task.Run(() =>
            {
                var pc = lc.patch;
                if (!String.IsNullOrEmpty(tps.CPCUrl))
                {
                    try
                    {
                        pc = JsonConvert.DeserializeObject<Patch_Config>(Methods.Get(tps.CPCUrl));
                    }
                    catch (Exception e)
                    {
                        Debug.Print($"CPC GET Fail:{e.Message}");
                        MessageBox.Show("获取修补方案失败", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                string show = "";
                try
                {
                    if (ispatch)
                    {
                        show = UA_Patch_Mgr.Patch_File(input, output, pc);
                    }
                    else
                    {

                        show = UA_Patch_Mgr.UnPatch_File(input, output, pc);
                    }
                    GC.Collect();
                    MessageBox.Show(show, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    Program.Application_Catched_Exception(e);
                }
            }).ContinueWith(task => Show_UA_Doing_Tip(false));
        }

        public void Show_UA_Doing_Tip(bool Doing)
        {
            UA_DoingTip_label.Visible = Doing;
            UA_Actions_groupBox.Enabled = !Doing;
        }

        private void INOUT_UA_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            UA_Output_panel.Enabled = !INOUT_UA_checkBox.Checked;
        }


        private void NoServerTip_label_MouseDown(object sender, MouseEventArgs e)
        {
            Servers_listView_MouseDown(sender, new MouseEventArgs(e.Button, e.Clicks, e.X + NoServerTip_label.Location.X, e.Y + NoServerTip_label.Location.Y, e.Delta));
        }

        private void Patch_UA_button_Click(object sender, EventArgs e)
        {
            UA_Actions(true);
        }

        private void UnPatch_UA_button_Click(object sender, EventArgs e)
        {
            UA_Actions(false);
        }

        private void Patch_Settings_tabPage_Leave(object sender, EventArgs e)
        {
            Apply_Patch_Config();
            Save_Local_Config();
        }

        private void Proxy_port_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            lc.config.ProxyPort = (ushort)Proxy_port_numericUpDown.Value;
        }

        private void Save_Config_button_Click(object sender, EventArgs e)
        {
            Save_Local_Config();
            MessageBox.Show("OK", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Settings_tabPage_Leave(object sender, EventArgs e)
        {
            Save_Local_Config();
        }
        public void Save_Habits_ToLC()
        {

            lc.habits.MainFormSize = Size;
            lc.habits.MainFormState = WindowState;
            lc.habits.MainFormLocation = Location;

            lc.habits.MetaFile_Input = MetaFile_Input_textBox.Text;
            lc.habits.INOUT_Meta = INOUT_Meta_checkBox.Checked;
            lc.habits.MetaFile_Output = MetaFile_Output_textBox.Text;

            lc.habits.UAFile_Input = UAFile_Input_textBox.Text;
            lc.habits.INOUT_UA = INOUT_UA_checkBox.Checked;
            lc.habits.UAFile_Output = UAFile_Output_textBox.Text;

            lc.habits.Title_columnHeader_Width = Title_columnHeader.Width;
            lc.habits.Host_columnHeader_Width = Host_columnHeader.Width;
            lc.habits.Dispatch_columnHeader_Width = Dispatch_columnHeader.Width;
            lc.habits.Count_columnHeader_Width = Count_columnHeader.Width;
            lc.habits.Ver_columnHeader_Width = Ver_columnHeader.Width;
            lc.habits.Ping_columnHeader_Width = Ping_columnHeader.Width;
            lc.habits.Content_columnHeader_Width = Content_columnHeader.Width;
        }

        private void Set_UAInputpath_button_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("OK");
        }

        private void Use_Habits_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            lc.config.UseHabit = Use_Habits_checkBox.Checked;
        }

        private void Proxy_Mode_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            lc.config.proxyMode = (ProxyMode)Proxy_Mode_comboBox.SelectedIndex;
        }

        private void Author_label_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (cc != null && cc.author != null && cc.author.LeftClickAble && !String.IsNullOrEmpty(cc.author.Target))
                {
                    Methods.Start(cc.author.Target);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ThirdParty_Form.Open(tps);
                ThirdPartyMgr.LoadSettings();
                UpdateAndNotice();
            }
        }

        private void Notice_Click(object sender, EventArgs e)
        {
            if (cc != null && cc.notice != null && cc.notice.ClickAble && !String.IsNullOrEmpty(cc.notice.Target))
            {
                Methods.Start(cc.notice.Target);
            }
        }

        private void Notice_webBrowser_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Notice_webBrowser.Navigate(Notice_webBrowser.StatusText);
        }

        private void Import_PC_button_Click(object sender, EventArgs e)
        {
            string path = Methods.Choice_Path("json文件|*.json|所有文件|*.*");
            if (!String.IsNullOrEmpty(path))
            {
                Patch_Config pc = JsonConvert.DeserializeObject<Patch_Config>(File.ReadAllText(path));
                lc.patch = pc;
                LoadSettingsToForm();
                MessageBox.Show("已导入", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Export_PC_button_Click(object sender, EventArgs e)
        {
            Apply_Patch_Config();
            Save_Local_Config();
            string path = Methods.Choice_Save_Path("json文件|*.json|所有文件|*.*");
            if (!String.IsNullOrEmpty(path))
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(lc.patch));
                MessageBox.Show("已导出", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Startup_Check_Proxy_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            lc.config.StartupCheckProxy = Startup_Check_Proxy_checkBox.Checked;
        }
    }
}

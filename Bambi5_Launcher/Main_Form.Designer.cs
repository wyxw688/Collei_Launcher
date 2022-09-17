
namespace Collei_Launcher
{
    partial class Main_Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.Main_tabControl = new System.Windows.Forms.TabControl();
            this.Home_tabPage = new System.Windows.Forms.TabPage();
            this.Notice_label = new System.Windows.Forms.Label();
            this.Servers_List_tabPage = new System.Windows.Forms.TabPage();
            this.NoServerTip_label = new System.Windows.Forms.Label();
            this.Servers_listView = new System.Windows.Forms.ListView();
            this.Title_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Host_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dispatch_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Game_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ver_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ping_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Content_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Meta_tabPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.Meta_Actions_groupBox = new System.Windows.Forms.GroupBox();
            this.Meta_DoingTip_label = new System.Windows.Forms.Label();
            this.UnPatch_Meta_button = new System.Windows.Forms.Button();
            this.Patch_Meta_button = new System.Windows.Forms.Button();
            this.Encrypt_File_button = new System.Windows.Forms.Button();
            this.Decrypt_File_button = new System.Windows.Forms.Button();
            this.Output_panel = new System.Windows.Forms.Panel();
            this.Set_MetaOutputpath_button = new System.Windows.Forms.Button();
            this.MetaFile_Output_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.INOUT_Meta_checkBox = new System.Windows.Forms.CheckBox();
            this.Set_MetaInputpath_button = new System.Windows.Forms.Button();
            this.MetaFile_Input_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UA_tabPage = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.UA_Actions_groupBox = new System.Windows.Forms.GroupBox();
            this.UA_DoingTip_label = new System.Windows.Forms.Label();
            this.UnPatch_UA_button = new System.Windows.Forms.Button();
            this.Patch_UA_button = new System.Windows.Forms.Button();
            this.UA_Output_panel = new System.Windows.Forms.Panel();
            this.Set_UAOutputpath_button = new System.Windows.Forms.Button();
            this.UAFile_Output_textBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.INOUT_UA_checkBox = new System.Windows.Forms.CheckBox();
            this.Set_UAInputpath_button = new System.Windows.Forms.Button();
            this.UAFile_Input_textBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Patch_Settings_tabPage = new System.Windows.Forms.TabPage();
            this.Patch_Settings_Tip_label = new System.Windows.Forms.Label();
            this.SetChannel_Panel = new System.Windows.Forms.Panel();
            this.CN_Channel_radioButton = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.OS_Channel_radioButton = new System.Windows.Forms.RadioButton();
            this.CheckChannel_checkBox = new System.Windows.Forms.CheckBox();
            this.PatchP1_checkBox = new System.Windows.Forms.CheckBox();
            this.Save_PC_button = new System.Windows.Forms.Button();
            this.Patch_Bytes_tabControl = new System.Windows.Forms.TabControl();
            this.Nopatch1_tabPage = new System.Windows.Forms.TabPage();
            this.Nopatch1_textBox = new System.Windows.Forms.TextBox();
            this.Patched1_tabPage = new System.Windows.Forms.TabPage();
            this.Patched1_textBox = new System.Windows.Forms.TextBox();
            this.Nopatch2_cn_tabPage = new System.Windows.Forms.TabPage();
            this.Nopatch2_cn_textBox = new System.Windows.Forms.TextBox();
            this.Nopatch2_os_tabPage = new System.Windows.Forms.TabPage();
            this.Nopatch2_os_textBox = new System.Windows.Forms.TextBox();
            this.Patched2_Meta_tabPage = new System.Windows.Forms.TabPage();
            this.Patched2_Meta_textBox = new System.Windows.Forms.TextBox();
            this.Patched2_UA_tabPage = new System.Windows.Forms.TabPage();
            this.Patched2_UA_textBox = new System.Windows.Forms.TextBox();
            this.Features_cn_tabPage = new System.Windows.Forms.TabPage();
            this.Features_cn_textBox = new System.Windows.Forms.TextBox();
            this.Features_os_tabPage = new System.Windows.Forms.TabPage();
            this.Features_os_textBox = new System.Windows.Forms.TextBox();
            this.Settings_tabPage = new System.Windows.Forms.TabPage();
            this.Save_Config_button = new System.Windows.Forms.Button();
            this.Reset_PC_button = new System.Windows.Forms.Button();
            this.Find_GameExe_button = new System.Windows.Forms.Button();
            this.Open_Check_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Choice_Game_Path_button = new System.Windows.Forms.Button();
            this.Game_Path_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Auto_close_proxy_checkBox = new System.Windows.Forms.CheckBox();
            this.Show_Public_Server_checkBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Proxy_port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Main_statusStrip = new System.Windows.Forms.StatusStrip();
            this.Proxy_status_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Servers_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Status_timer = new System.Windows.Forms.Timer(this.components);
            this.Author_label = new System.Windows.Forms.Label();
            this.Main_tabControl.SuspendLayout();
            this.Home_tabPage.SuspendLayout();
            this.Servers_List_tabPage.SuspendLayout();
            this.Meta_tabPage.SuspendLayout();
            this.Meta_Actions_groupBox.SuspendLayout();
            this.Output_panel.SuspendLayout();
            this.UA_tabPage.SuspendLayout();
            this.UA_Actions_groupBox.SuspendLayout();
            this.UA_Output_panel.SuspendLayout();
            this.Patch_Settings_tabPage.SuspendLayout();
            this.SetChannel_Panel.SuspendLayout();
            this.Patch_Bytes_tabControl.SuspendLayout();
            this.Nopatch1_tabPage.SuspendLayout();
            this.Patched1_tabPage.SuspendLayout();
            this.Nopatch2_cn_tabPage.SuspendLayout();
            this.Nopatch2_os_tabPage.SuspendLayout();
            this.Patched2_Meta_tabPage.SuspendLayout();
            this.Patched2_UA_tabPage.SuspendLayout();
            this.Features_cn_tabPage.SuspendLayout();
            this.Features_os_tabPage.SuspendLayout();
            this.Settings_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Proxy_port_numericUpDown)).BeginInit();
            this.Main_statusStrip.SuspendLayout();
            this.Servers_contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_tabControl
            // 
            resources.ApplyResources(this.Main_tabControl, "Main_tabControl");
            this.Main_tabControl.Controls.Add(this.Home_tabPage);
            this.Main_tabControl.Controls.Add(this.Servers_List_tabPage);
            this.Main_tabControl.Controls.Add(this.Meta_tabPage);
            this.Main_tabControl.Controls.Add(this.UA_tabPage);
            this.Main_tabControl.Controls.Add(this.Patch_Settings_tabPage);
            this.Main_tabControl.Controls.Add(this.Settings_tabPage);
            this.Main_tabControl.Name = "Main_tabControl";
            this.Main_tabControl.SelectedIndex = 0;
            // 
            // Home_tabPage
            // 
            resources.ApplyResources(this.Home_tabPage, "Home_tabPage");
            this.Home_tabPage.Controls.Add(this.Notice_label);
            this.Home_tabPage.Name = "Home_tabPage";
            this.Home_tabPage.UseVisualStyleBackColor = true;
            this.Home_tabPage.Enter += new System.EventHandler(this.Home_tabPage_Enter);
            // 
            // Notice_label
            // 
            resources.ApplyResources(this.Notice_label, "Notice_label");
            this.Notice_label.Name = "Notice_label";
            // 
            // Servers_List_tabPage
            // 
            resources.ApplyResources(this.Servers_List_tabPage, "Servers_List_tabPage");
            this.Servers_List_tabPage.Controls.Add(this.NoServerTip_label);
            this.Servers_List_tabPage.Controls.Add(this.Servers_listView);
            this.Servers_List_tabPage.Name = "Servers_List_tabPage";
            this.Servers_List_tabPage.UseVisualStyleBackColor = true;
            this.Servers_List_tabPage.Enter += new System.EventHandler(this.Servers_List_tabPage_Enter);
            this.Servers_List_tabPage.Leave += new System.EventHandler(this.Servers_List_tabPage_Leave);
            // 
            // NoServerTip_label
            // 
            resources.ApplyResources(this.NoServerTip_label, "NoServerTip_label");
            this.NoServerTip_label.BackColor = System.Drawing.Color.Transparent;
            this.NoServerTip_label.Name = "NoServerTip_label";
            this.NoServerTip_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NoServerTip_label_MouseDown);
            // 
            // Servers_listView
            // 
            resources.ApplyResources(this.Servers_listView, "Servers_listView");
            this.Servers_listView.AllowDrop = true;
            this.Servers_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title_columnHeader,
            this.Host_columnHeader,
            this.Dispatch_columnHeader,
            this.Game_columnHeader,
            this.Count_columnHeader,
            this.Ver_columnHeader,
            this.Ping_columnHeader,
            this.Content_columnHeader});
            this.Servers_listView.FullRowSelect = true;
            this.Servers_listView.GridLines = true;
            this.Servers_listView.HideSelection = false;
            this.Servers_listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("Servers_listView.Items")))});
            this.Servers_listView.MultiSelect = false;
            this.Servers_listView.Name = "Servers_listView";
            this.Servers_listView.ShowGroups = false;
            this.Servers_listView.UseCompatibleStateImageBehavior = false;
            this.Servers_listView.View = System.Windows.Forms.View.Details;
            this.Servers_listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Servers_listView_MouseDoubleClick);
            this.Servers_listView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Servers_listView_MouseDown);
            // 
            // Title_columnHeader
            // 
            resources.ApplyResources(this.Title_columnHeader, "Title_columnHeader");
            // 
            // Host_columnHeader
            // 
            resources.ApplyResources(this.Host_columnHeader, "Host_columnHeader");
            // 
            // Dispatch_columnHeader
            // 
            resources.ApplyResources(this.Dispatch_columnHeader, "Dispatch_columnHeader");
            // 
            // Game_columnHeader
            // 
            resources.ApplyResources(this.Game_columnHeader, "Game_columnHeader");
            // 
            // Count_columnHeader
            // 
            resources.ApplyResources(this.Count_columnHeader, "Count_columnHeader");
            // 
            // Ver_columnHeader
            // 
            resources.ApplyResources(this.Ver_columnHeader, "Ver_columnHeader");
            // 
            // Ping_columnHeader
            // 
            resources.ApplyResources(this.Ping_columnHeader, "Ping_columnHeader");
            // 
            // Content_columnHeader
            // 
            resources.ApplyResources(this.Content_columnHeader, "Content_columnHeader");
            // 
            // Meta_tabPage
            // 
            resources.ApplyResources(this.Meta_tabPage, "Meta_tabPage");
            this.Meta_tabPage.Controls.Add(this.label6);
            this.Meta_tabPage.Controls.Add(this.Meta_Actions_groupBox);
            this.Meta_tabPage.Controls.Add(this.Output_panel);
            this.Meta_tabPage.Controls.Add(this.INOUT_Meta_checkBox);
            this.Meta_tabPage.Controls.Add(this.Set_MetaInputpath_button);
            this.Meta_tabPage.Controls.Add(this.MetaFile_Input_textBox);
            this.Meta_tabPage.Controls.Add(this.label4);
            this.Meta_tabPage.Name = "Meta_tabPage";
            this.Meta_tabPage.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Name = "label6";
            // 
            // Meta_Actions_groupBox
            // 
            resources.ApplyResources(this.Meta_Actions_groupBox, "Meta_Actions_groupBox");
            this.Meta_Actions_groupBox.Controls.Add(this.Meta_DoingTip_label);
            this.Meta_Actions_groupBox.Controls.Add(this.UnPatch_Meta_button);
            this.Meta_Actions_groupBox.Controls.Add(this.Patch_Meta_button);
            this.Meta_Actions_groupBox.Controls.Add(this.Encrypt_File_button);
            this.Meta_Actions_groupBox.Controls.Add(this.Decrypt_File_button);
            this.Meta_Actions_groupBox.Name = "Meta_Actions_groupBox";
            this.Meta_Actions_groupBox.TabStop = false;
            // 
            // Meta_DoingTip_label
            // 
            resources.ApplyResources(this.Meta_DoingTip_label, "Meta_DoingTip_label");
            this.Meta_DoingTip_label.Name = "Meta_DoingTip_label";
            // 
            // UnPatch_Meta_button
            // 
            resources.ApplyResources(this.UnPatch_Meta_button, "UnPatch_Meta_button");
            this.UnPatch_Meta_button.Name = "UnPatch_Meta_button";
            this.UnPatch_Meta_button.UseVisualStyleBackColor = true;
            this.UnPatch_Meta_button.Click += new System.EventHandler(this.UnPatch_Meta_button_Click);
            // 
            // Patch_Meta_button
            // 
            resources.ApplyResources(this.Patch_Meta_button, "Patch_Meta_button");
            this.Patch_Meta_button.Name = "Patch_Meta_button";
            this.Patch_Meta_button.UseVisualStyleBackColor = true;
            this.Patch_Meta_button.Click += new System.EventHandler(this.Patch_Meta_button_Click);
            // 
            // Encrypt_File_button
            // 
            resources.ApplyResources(this.Encrypt_File_button, "Encrypt_File_button");
            this.Encrypt_File_button.Name = "Encrypt_File_button";
            this.Encrypt_File_button.UseVisualStyleBackColor = true;
            this.Encrypt_File_button.Click += new System.EventHandler(this.Encrypt_File_button_Click);
            // 
            // Decrypt_File_button
            // 
            resources.ApplyResources(this.Decrypt_File_button, "Decrypt_File_button");
            this.Decrypt_File_button.Name = "Decrypt_File_button";
            this.Decrypt_File_button.UseVisualStyleBackColor = true;
            this.Decrypt_File_button.Click += new System.EventHandler(this.Decrypt_File_button_Click);
            // 
            // Output_panel
            // 
            resources.ApplyResources(this.Output_panel, "Output_panel");
            this.Output_panel.Controls.Add(this.Set_MetaOutputpath_button);
            this.Output_panel.Controls.Add(this.MetaFile_Output_textBox);
            this.Output_panel.Controls.Add(this.label5);
            this.Output_panel.Name = "Output_panel";
            // 
            // Set_MetaOutputpath_button
            // 
            resources.ApplyResources(this.Set_MetaOutputpath_button, "Set_MetaOutputpath_button");
            this.Set_MetaOutputpath_button.Name = "Set_MetaOutputpath_button";
            this.Set_MetaOutputpath_button.UseVisualStyleBackColor = true;
            this.Set_MetaOutputpath_button.Click += new System.EventHandler(this.Set_MetaOutputpath_button_Click);
            // 
            // MetaFile_Output_textBox
            // 
            resources.ApplyResources(this.MetaFile_Output_textBox, "MetaFile_Output_textBox");
            this.MetaFile_Output_textBox.Name = "MetaFile_Output_textBox";
            this.MetaFile_Output_textBox.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // INOUT_Meta_checkBox
            // 
            resources.ApplyResources(this.INOUT_Meta_checkBox, "INOUT_Meta_checkBox");
            this.INOUT_Meta_checkBox.Checked = true;
            this.INOUT_Meta_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.INOUT_Meta_checkBox.Name = "INOUT_Meta_checkBox";
            this.INOUT_Meta_checkBox.UseVisualStyleBackColor = true;
            this.INOUT_Meta_checkBox.CheckedChanged += new System.EventHandler(this.Outpath_checkBox_CheckedChanged);
            // 
            // Set_MetaInputpath_button
            // 
            resources.ApplyResources(this.Set_MetaInputpath_button, "Set_MetaInputpath_button");
            this.Set_MetaInputpath_button.Name = "Set_MetaInputpath_button";
            this.Set_MetaInputpath_button.UseVisualStyleBackColor = true;
            this.Set_MetaInputpath_button.Click += new System.EventHandler(this.Set_MetaInputpath_button_Click);
            // 
            // MetaFile_Input_textBox
            // 
            resources.ApplyResources(this.MetaFile_Input_textBox, "MetaFile_Input_textBox");
            this.MetaFile_Input_textBox.Name = "MetaFile_Input_textBox";
            this.MetaFile_Input_textBox.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // UA_tabPage
            // 
            resources.ApplyResources(this.UA_tabPage, "UA_tabPage");
            this.UA_tabPage.Controls.Add(this.label11);
            this.UA_tabPage.Controls.Add(this.UA_Actions_groupBox);
            this.UA_tabPage.Controls.Add(this.UA_Output_panel);
            this.UA_tabPage.Controls.Add(this.INOUT_UA_checkBox);
            this.UA_tabPage.Controls.Add(this.Set_UAInputpath_button);
            this.UA_tabPage.Controls.Add(this.UAFile_Input_textBox);
            this.UA_tabPage.Controls.Add(this.label13);
            this.UA_tabPage.Name = "UA_tabPage";
            this.UA_tabPage.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Name = "label11";
            // 
            // UA_Actions_groupBox
            // 
            resources.ApplyResources(this.UA_Actions_groupBox, "UA_Actions_groupBox");
            this.UA_Actions_groupBox.Controls.Add(this.UA_DoingTip_label);
            this.UA_Actions_groupBox.Controls.Add(this.UnPatch_UA_button);
            this.UA_Actions_groupBox.Controls.Add(this.Patch_UA_button);
            this.UA_Actions_groupBox.Name = "UA_Actions_groupBox";
            this.UA_Actions_groupBox.TabStop = false;
            // 
            // UA_DoingTip_label
            // 
            resources.ApplyResources(this.UA_DoingTip_label, "UA_DoingTip_label");
            this.UA_DoingTip_label.Name = "UA_DoingTip_label";
            // 
            // UnPatch_UA_button
            // 
            resources.ApplyResources(this.UnPatch_UA_button, "UnPatch_UA_button");
            this.UnPatch_UA_button.Name = "UnPatch_UA_button";
            this.UnPatch_UA_button.UseVisualStyleBackColor = true;
            this.UnPatch_UA_button.Click += new System.EventHandler(this.UnPatch_UA_button_Click);
            // 
            // Patch_UA_button
            // 
            resources.ApplyResources(this.Patch_UA_button, "Patch_UA_button");
            this.Patch_UA_button.Name = "Patch_UA_button";
            this.Patch_UA_button.UseVisualStyleBackColor = true;
            this.Patch_UA_button.Click += new System.EventHandler(this.Patch_UA_button_Click);
            // 
            // UA_Output_panel
            // 
            resources.ApplyResources(this.UA_Output_panel, "UA_Output_panel");
            this.UA_Output_panel.Controls.Add(this.Set_UAOutputpath_button);
            this.UA_Output_panel.Controls.Add(this.UAFile_Output_textBox);
            this.UA_Output_panel.Controls.Add(this.label12);
            this.UA_Output_panel.Name = "UA_Output_panel";
            // 
            // Set_UAOutputpath_button
            // 
            resources.ApplyResources(this.Set_UAOutputpath_button, "Set_UAOutputpath_button");
            this.Set_UAOutputpath_button.Name = "Set_UAOutputpath_button";
            this.Set_UAOutputpath_button.UseVisualStyleBackColor = true;
            this.Set_UAOutputpath_button.Click += new System.EventHandler(this.Set_UAOutputpath_button_Click);
            // 
            // UAFile_Output_textBox
            // 
            resources.ApplyResources(this.UAFile_Output_textBox, "UAFile_Output_textBox");
            this.UAFile_Output_textBox.Name = "UAFile_Output_textBox";
            this.UAFile_Output_textBox.ReadOnly = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // INOUT_UA_checkBox
            // 
            resources.ApplyResources(this.INOUT_UA_checkBox, "INOUT_UA_checkBox");
            this.INOUT_UA_checkBox.Checked = true;
            this.INOUT_UA_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.INOUT_UA_checkBox.Name = "INOUT_UA_checkBox";
            this.INOUT_UA_checkBox.UseVisualStyleBackColor = true;
            this.INOUT_UA_checkBox.CheckedChanged += new System.EventHandler(this.INOUT_UA_checkBox_CheckedChanged);
            // 
            // Set_UAInputpath_button
            // 
            resources.ApplyResources(this.Set_UAInputpath_button, "Set_UAInputpath_button");
            this.Set_UAInputpath_button.Name = "Set_UAInputpath_button";
            this.Set_UAInputpath_button.UseVisualStyleBackColor = true;
            this.Set_UAInputpath_button.Click += new System.EventHandler(this.Set_UAInputpath_button_Click);
            // 
            // UAFile_Input_textBox
            // 
            resources.ApplyResources(this.UAFile_Input_textBox, "UAFile_Input_textBox");
            this.UAFile_Input_textBox.Name = "UAFile_Input_textBox";
            this.UAFile_Input_textBox.ReadOnly = true;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // Patch_Settings_tabPage
            // 
            resources.ApplyResources(this.Patch_Settings_tabPage, "Patch_Settings_tabPage");
            this.Patch_Settings_tabPage.Controls.Add(this.Patch_Settings_Tip_label);
            this.Patch_Settings_tabPage.Controls.Add(this.SetChannel_Panel);
            this.Patch_Settings_tabPage.Controls.Add(this.CheckChannel_checkBox);
            this.Patch_Settings_tabPage.Controls.Add(this.PatchP1_checkBox);
            this.Patch_Settings_tabPage.Controls.Add(this.Save_PC_button);
            this.Patch_Settings_tabPage.Controls.Add(this.Patch_Bytes_tabControl);
            this.Patch_Settings_tabPage.Name = "Patch_Settings_tabPage";
            this.Patch_Settings_tabPage.UseVisualStyleBackColor = true;
            this.Patch_Settings_tabPage.Leave += new System.EventHandler(this.Patch_Settings_tabPage_Leave);
            // 
            // Patch_Settings_Tip_label
            // 
            resources.ApplyResources(this.Patch_Settings_Tip_label, "Patch_Settings_Tip_label");
            this.Patch_Settings_Tip_label.Name = "Patch_Settings_Tip_label";
            // 
            // SetChannel_Panel
            // 
            resources.ApplyResources(this.SetChannel_Panel, "SetChannel_Panel");
            this.SetChannel_Panel.Controls.Add(this.CN_Channel_radioButton);
            this.SetChannel_Panel.Controls.Add(this.label7);
            this.SetChannel_Panel.Controls.Add(this.OS_Channel_radioButton);
            this.SetChannel_Panel.Name = "SetChannel_Panel";
            // 
            // CN_Channel_radioButton
            // 
            resources.ApplyResources(this.CN_Channel_radioButton, "CN_Channel_radioButton");
            this.CN_Channel_radioButton.Checked = true;
            this.CN_Channel_radioButton.Name = "CN_Channel_radioButton";
            this.CN_Channel_radioButton.TabStop = true;
            this.CN_Channel_radioButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // OS_Channel_radioButton
            // 
            resources.ApplyResources(this.OS_Channel_radioButton, "OS_Channel_radioButton");
            this.OS_Channel_radioButton.Name = "OS_Channel_radioButton";
            this.OS_Channel_radioButton.UseVisualStyleBackColor = true;
            // 
            // CheckChannel_checkBox
            // 
            resources.ApplyResources(this.CheckChannel_checkBox, "CheckChannel_checkBox");
            this.CheckChannel_checkBox.Checked = true;
            this.CheckChannel_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckChannel_checkBox.Name = "CheckChannel_checkBox";
            this.CheckChannel_checkBox.UseVisualStyleBackColor = true;
            this.CheckChannel_checkBox.CheckedChanged += new System.EventHandler(this.CheckChannel_checkBox_CheckedChanged);
            // 
            // PatchP1_checkBox
            // 
            resources.ApplyResources(this.PatchP1_checkBox, "PatchP1_checkBox");
            this.PatchP1_checkBox.Checked = true;
            this.PatchP1_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PatchP1_checkBox.Name = "PatchP1_checkBox";
            this.PatchP1_checkBox.UseVisualStyleBackColor = true;
            // 
            // Save_PC_button
            // 
            resources.ApplyResources(this.Save_PC_button, "Save_PC_button");
            this.Save_PC_button.Name = "Save_PC_button";
            this.Save_PC_button.UseVisualStyleBackColor = true;
            this.Save_PC_button.Click += new System.EventHandler(this.Save_PC_button_Click);
            // 
            // Patch_Bytes_tabControl
            // 
            resources.ApplyResources(this.Patch_Bytes_tabControl, "Patch_Bytes_tabControl");
            this.Patch_Bytes_tabControl.Controls.Add(this.Nopatch1_tabPage);
            this.Patch_Bytes_tabControl.Controls.Add(this.Patched1_tabPage);
            this.Patch_Bytes_tabControl.Controls.Add(this.Nopatch2_cn_tabPage);
            this.Patch_Bytes_tabControl.Controls.Add(this.Nopatch2_os_tabPage);
            this.Patch_Bytes_tabControl.Controls.Add(this.Patched2_Meta_tabPage);
            this.Patch_Bytes_tabControl.Controls.Add(this.Patched2_UA_tabPage);
            this.Patch_Bytes_tabControl.Controls.Add(this.Features_cn_tabPage);
            this.Patch_Bytes_tabControl.Controls.Add(this.Features_os_tabPage);
            this.Patch_Bytes_tabControl.Multiline = true;
            this.Patch_Bytes_tabControl.Name = "Patch_Bytes_tabControl";
            this.Patch_Bytes_tabControl.SelectedIndex = 0;
            // 
            // Nopatch1_tabPage
            // 
            resources.ApplyResources(this.Nopatch1_tabPage, "Nopatch1_tabPage");
            this.Nopatch1_tabPage.Controls.Add(this.Nopatch1_textBox);
            this.Nopatch1_tabPage.Name = "Nopatch1_tabPage";
            this.Nopatch1_tabPage.UseVisualStyleBackColor = true;
            // 
            // Nopatch1_textBox
            // 
            resources.ApplyResources(this.Nopatch1_textBox, "Nopatch1_textBox");
            this.Nopatch1_textBox.Name = "Nopatch1_textBox";
            // 
            // Patched1_tabPage
            // 
            resources.ApplyResources(this.Patched1_tabPage, "Patched1_tabPage");
            this.Patched1_tabPage.Controls.Add(this.Patched1_textBox);
            this.Patched1_tabPage.Name = "Patched1_tabPage";
            this.Patched1_tabPage.UseVisualStyleBackColor = true;
            // 
            // Patched1_textBox
            // 
            resources.ApplyResources(this.Patched1_textBox, "Patched1_textBox");
            this.Patched1_textBox.Name = "Patched1_textBox";
            // 
            // Nopatch2_cn_tabPage
            // 
            resources.ApplyResources(this.Nopatch2_cn_tabPage, "Nopatch2_cn_tabPage");
            this.Nopatch2_cn_tabPage.Controls.Add(this.Nopatch2_cn_textBox);
            this.Nopatch2_cn_tabPage.Name = "Nopatch2_cn_tabPage";
            this.Nopatch2_cn_tabPage.UseVisualStyleBackColor = true;
            // 
            // Nopatch2_cn_textBox
            // 
            resources.ApplyResources(this.Nopatch2_cn_textBox, "Nopatch2_cn_textBox");
            this.Nopatch2_cn_textBox.Name = "Nopatch2_cn_textBox";
            // 
            // Nopatch2_os_tabPage
            // 
            resources.ApplyResources(this.Nopatch2_os_tabPage, "Nopatch2_os_tabPage");
            this.Nopatch2_os_tabPage.Controls.Add(this.Nopatch2_os_textBox);
            this.Nopatch2_os_tabPage.Name = "Nopatch2_os_tabPage";
            this.Nopatch2_os_tabPage.UseVisualStyleBackColor = true;
            // 
            // Nopatch2_os_textBox
            // 
            resources.ApplyResources(this.Nopatch2_os_textBox, "Nopatch2_os_textBox");
            this.Nopatch2_os_textBox.Name = "Nopatch2_os_textBox";
            // 
            // Patched2_Meta_tabPage
            // 
            resources.ApplyResources(this.Patched2_Meta_tabPage, "Patched2_Meta_tabPage");
            this.Patched2_Meta_tabPage.Controls.Add(this.Patched2_Meta_textBox);
            this.Patched2_Meta_tabPage.Name = "Patched2_Meta_tabPage";
            this.Patched2_Meta_tabPage.UseVisualStyleBackColor = true;
            // 
            // Patched2_Meta_textBox
            // 
            resources.ApplyResources(this.Patched2_Meta_textBox, "Patched2_Meta_textBox");
            this.Patched2_Meta_textBox.Name = "Patched2_Meta_textBox";
            // 
            // Patched2_UA_tabPage
            // 
            resources.ApplyResources(this.Patched2_UA_tabPage, "Patched2_UA_tabPage");
            this.Patched2_UA_tabPage.Controls.Add(this.Patched2_UA_textBox);
            this.Patched2_UA_tabPage.Name = "Patched2_UA_tabPage";
            this.Patched2_UA_tabPage.UseVisualStyleBackColor = true;
            // 
            // Patched2_UA_textBox
            // 
            resources.ApplyResources(this.Patched2_UA_textBox, "Patched2_UA_textBox");
            this.Patched2_UA_textBox.Name = "Patched2_UA_textBox";
            // 
            // Features_cn_tabPage
            // 
            resources.ApplyResources(this.Features_cn_tabPage, "Features_cn_tabPage");
            this.Features_cn_tabPage.Controls.Add(this.Features_cn_textBox);
            this.Features_cn_tabPage.Name = "Features_cn_tabPage";
            this.Features_cn_tabPage.UseVisualStyleBackColor = true;
            // 
            // Features_cn_textBox
            // 
            resources.ApplyResources(this.Features_cn_textBox, "Features_cn_textBox");
            this.Features_cn_textBox.Name = "Features_cn_textBox";
            // 
            // Features_os_tabPage
            // 
            resources.ApplyResources(this.Features_os_tabPage, "Features_os_tabPage");
            this.Features_os_tabPage.Controls.Add(this.Features_os_textBox);
            this.Features_os_tabPage.Name = "Features_os_tabPage";
            this.Features_os_tabPage.UseVisualStyleBackColor = true;
            // 
            // Features_os_textBox
            // 
            resources.ApplyResources(this.Features_os_textBox, "Features_os_textBox");
            this.Features_os_textBox.Name = "Features_os_textBox";
            // 
            // Settings_tabPage
            // 
            resources.ApplyResources(this.Settings_tabPage, "Settings_tabPage");
            this.Settings_tabPage.Controls.Add(this.Save_Config_button);
            this.Settings_tabPage.Controls.Add(this.Reset_PC_button);
            this.Settings_tabPage.Controls.Add(this.Find_GameExe_button);
            this.Settings_tabPage.Controls.Add(this.Open_Check_button);
            this.Settings_tabPage.Controls.Add(this.label3);
            this.Settings_tabPage.Controls.Add(this.Choice_Game_Path_button);
            this.Settings_tabPage.Controls.Add(this.Game_Path_textBox);
            this.Settings_tabPage.Controls.Add(this.label2);
            this.Settings_tabPage.Controls.Add(this.Auto_close_proxy_checkBox);
            this.Settings_tabPage.Controls.Add(this.Show_Public_Server_checkBox);
            this.Settings_tabPage.Controls.Add(this.label1);
            this.Settings_tabPage.Controls.Add(this.Proxy_port_numericUpDown);
            this.Settings_tabPage.Name = "Settings_tabPage";
            this.Settings_tabPage.UseVisualStyleBackColor = true;
            this.Settings_tabPage.Leave += new System.EventHandler(this.Settings_tabPage_Leave);
            // 
            // Save_Config_button
            // 
            resources.ApplyResources(this.Save_Config_button, "Save_Config_button");
            this.Save_Config_button.Name = "Save_Config_button";
            this.Save_Config_button.UseVisualStyleBackColor = true;
            this.Save_Config_button.Click += new System.EventHandler(this.Save_Config_button_Click);
            // 
            // Reset_PC_button
            // 
            resources.ApplyResources(this.Reset_PC_button, "Reset_PC_button");
            this.Reset_PC_button.Name = "Reset_PC_button";
            this.Reset_PC_button.UseVisualStyleBackColor = true;
            this.Reset_PC_button.Click += new System.EventHandler(this.Reset_PC_button_Click);
            // 
            // Find_GameExe_button
            // 
            resources.ApplyResources(this.Find_GameExe_button, "Find_GameExe_button");
            this.Find_GameExe_button.Name = "Find_GameExe_button";
            this.Find_GameExe_button.UseVisualStyleBackColor = true;
            this.Find_GameExe_button.Click += new System.EventHandler(this.Find_GameExe_button_Click);
            // 
            // Open_Check_button
            // 
            resources.ApplyResources(this.Open_Check_button, "Open_Check_button");
            this.Open_Check_button.Name = "Open_Check_button";
            this.Open_Check_button.UseVisualStyleBackColor = true;
            this.Open_Check_button.Click += new System.EventHandler(this.Open_Check_button_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Choice_Game_Path_button
            // 
            resources.ApplyResources(this.Choice_Game_Path_button, "Choice_Game_Path_button");
            this.Choice_Game_Path_button.Name = "Choice_Game_Path_button";
            this.Choice_Game_Path_button.UseVisualStyleBackColor = true;
            this.Choice_Game_Path_button.Click += new System.EventHandler(this.Choice_Game_Path_button_Click);
            // 
            // Game_Path_textBox
            // 
            resources.ApplyResources(this.Game_Path_textBox, "Game_Path_textBox");
            this.Game_Path_textBox.Name = "Game_Path_textBox";
            this.Game_Path_textBox.ReadOnly = true;
            this.Game_Path_textBox.TextChanged += new System.EventHandler(this.Game_Path_textBox_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Auto_close_proxy_checkBox
            // 
            resources.ApplyResources(this.Auto_close_proxy_checkBox, "Auto_close_proxy_checkBox");
            this.Auto_close_proxy_checkBox.Checked = true;
            this.Auto_close_proxy_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Auto_close_proxy_checkBox.Name = "Auto_close_proxy_checkBox";
            this.Auto_close_proxy_checkBox.UseVisualStyleBackColor = true;
            this.Auto_close_proxy_checkBox.CheckedChanged += new System.EventHandler(this.Auto_close_proxy_checkBox_CheckedChanged);
            // 
            // Show_Public_Server_checkBox
            // 
            resources.ApplyResources(this.Show_Public_Server_checkBox, "Show_Public_Server_checkBox");
            this.Show_Public_Server_checkBox.Checked = true;
            this.Show_Public_Server_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Show_Public_Server_checkBox.Name = "Show_Public_Server_checkBox";
            this.Show_Public_Server_checkBox.UseVisualStyleBackColor = true;
            this.Show_Public_Server_checkBox.CheckedChanged += new System.EventHandler(this.Show_Public_Server_checkBox_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Proxy_port_numericUpDown
            // 
            resources.ApplyResources(this.Proxy_port_numericUpDown, "Proxy_port_numericUpDown");
            this.Proxy_port_numericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Proxy_port_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Proxy_port_numericUpDown.Name = "Proxy_port_numericUpDown";
            this.Proxy_port_numericUpDown.Value = new decimal(new int[] {
            8520,
            0,
            0,
            0});
            this.Proxy_port_numericUpDown.ValueChanged += new System.EventHandler(this.Proxy_port_numericUpDown_ValueChanged);
            // 
            // Main_statusStrip
            // 
            resources.ApplyResources(this.Main_statusStrip, "Main_statusStrip");
            this.Main_statusStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Main_statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Main_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Proxy_status_toolStripStatusLabel});
            this.Main_statusStrip.Name = "Main_statusStrip";
            // 
            // Proxy_status_toolStripStatusLabel
            // 
            resources.ApplyResources(this.Proxy_status_toolStripStatusLabel, "Proxy_status_toolStripStatusLabel");
            this.Proxy_status_toolStripStatusLabel.IsLink = true;
            this.Proxy_status_toolStripStatusLabel.Name = "Proxy_status_toolStripStatusLabel";
            this.Proxy_status_toolStripStatusLabel.Click += new System.EventHandler(this.Proxy_status_toolStripStatusLabel_Click);
            // 
            // Servers_contextMenuStrip
            // 
            resources.ApplyResources(this.Servers_contextMenuStrip, "Servers_contextMenuStrip");
            this.Servers_contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Servers_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.toolStripSeparator1,
            this.连接ToolStripMenuItem,
            this.检查连接ToolStripMenuItem,
            this.toolStripSeparator2,
            this.编辑ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.Servers_contextMenuStrip.Name = "Servers_contextMenuStrip";
            // 
            // 添加ToolStripMenuItem
            // 
            resources.ApplyResources(this.添加ToolStripMenuItem, "添加ToolStripMenuItem");
            this.添加ToolStripMenuItem.Image = global::Collei_Launcher.Properties.Resources.添加;
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // 连接ToolStripMenuItem
            // 
            resources.ApplyResources(this.连接ToolStripMenuItem, "连接ToolStripMenuItem");
            this.连接ToolStripMenuItem.Image = global::Collei_Launcher.Properties.Resources.启动;
            this.连接ToolStripMenuItem.Name = "连接ToolStripMenuItem";
            this.连接ToolStripMenuItem.Click += new System.EventHandler(this.连接ToolStripMenuItem_Click);
            // 
            // 检查连接ToolStripMenuItem
            // 
            resources.ApplyResources(this.检查连接ToolStripMenuItem, "检查连接ToolStripMenuItem");
            this.检查连接ToolStripMenuItem.Image = global::Collei_Launcher.Properties.Resources.搜索;
            this.检查连接ToolStripMenuItem.Name = "检查连接ToolStripMenuItem";
            this.检查连接ToolStripMenuItem.Click += new System.EventHandler(this.检查连接ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // 编辑ToolStripMenuItem
            // 
            resources.ApplyResources(this.编辑ToolStripMenuItem, "编辑ToolStripMenuItem");
            this.编辑ToolStripMenuItem.Image = global::Collei_Launcher.Properties.Resources.编辑;
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            resources.ApplyResources(this.删除ToolStripMenuItem, "删除ToolStripMenuItem");
            this.删除ToolStripMenuItem.Image = global::Collei_Launcher.Properties.Resources.删除;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // Status_timer
            // 
            this.Status_timer.Enabled = true;
            this.Status_timer.Interval = 5000;
            this.Status_timer.Tick += new System.EventHandler(this.Status_timer_Tick);
            // 
            // Author_label
            // 
            resources.ApplyResources(this.Author_label, "Author_label");
            this.Author_label.BackColor = System.Drawing.Color.Transparent;
            this.Author_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Author_label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Author_label.Name = "Author_label";
            this.Author_label.Click += new System.EventHandler(this.Author_label_Click);
            // 
            // Main_Form
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.Author_label);
            this.Controls.Add(this.Main_statusStrip);
            this.Controls.Add(this.Main_tabControl);
            this.MaximizeBox = false;
            this.Name = "Main_Form";
            this.Opacity = 0D;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing);
            this.Shown += new System.EventHandler(this.Main_Form_Shown);
            this.Main_tabControl.ResumeLayout(false);
            this.Home_tabPage.ResumeLayout(false);
            this.Servers_List_tabPage.ResumeLayout(false);
            this.Meta_tabPage.ResumeLayout(false);
            this.Meta_tabPage.PerformLayout();
            this.Meta_Actions_groupBox.ResumeLayout(false);
            this.Output_panel.ResumeLayout(false);
            this.Output_panel.PerformLayout();
            this.UA_tabPage.ResumeLayout(false);
            this.UA_tabPage.PerformLayout();
            this.UA_Actions_groupBox.ResumeLayout(false);
            this.UA_Output_panel.ResumeLayout(false);
            this.UA_Output_panel.PerformLayout();
            this.Patch_Settings_tabPage.ResumeLayout(false);
            this.Patch_Settings_tabPage.PerformLayout();
            this.SetChannel_Panel.ResumeLayout(false);
            this.SetChannel_Panel.PerformLayout();
            this.Patch_Bytes_tabControl.ResumeLayout(false);
            this.Nopatch1_tabPage.ResumeLayout(false);
            this.Nopatch1_tabPage.PerformLayout();
            this.Patched1_tabPage.ResumeLayout(false);
            this.Patched1_tabPage.PerformLayout();
            this.Nopatch2_cn_tabPage.ResumeLayout(false);
            this.Nopatch2_cn_tabPage.PerformLayout();
            this.Nopatch2_os_tabPage.ResumeLayout(false);
            this.Nopatch2_os_tabPage.PerformLayout();
            this.Patched2_Meta_tabPage.ResumeLayout(false);
            this.Patched2_Meta_tabPage.PerformLayout();
            this.Patched2_UA_tabPage.ResumeLayout(false);
            this.Patched2_UA_tabPage.PerformLayout();
            this.Features_cn_tabPage.ResumeLayout(false);
            this.Features_cn_tabPage.PerformLayout();
            this.Features_os_tabPage.ResumeLayout(false);
            this.Features_os_tabPage.PerformLayout();
            this.Settings_tabPage.ResumeLayout(false);
            this.Settings_tabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Proxy_port_numericUpDown)).EndInit();
            this.Main_statusStrip.ResumeLayout(false);
            this.Main_statusStrip.PerformLayout();
            this.Servers_contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TabControl Main_tabControl;
        public System.Windows.Forms.TabPage Settings_tabPage;
        public System.Windows.Forms.StatusStrip Main_statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel Proxy_status_toolStripStatusLabel;
        public System.Windows.Forms.TabPage Home_tabPage;
        public System.Windows.Forms.Label Notice_label;
        public System.Windows.Forms.ListView Servers_listView;
        public System.Windows.Forms.ColumnHeader Title_columnHeader;
        public System.Windows.Forms.ColumnHeader Host_columnHeader;
        public System.Windows.Forms.ColumnHeader Dispatch_columnHeader;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown Proxy_port_numericUpDown;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ContextMenuStrip Servers_contextMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem 连接ToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        public System.Windows.Forms.TabPage Servers_List_tabPage;
        public System.Windows.Forms.ColumnHeader Game_columnHeader;
        public System.Windows.Forms.ColumnHeader Content_columnHeader;
        public System.Windows.Forms.CheckBox Show_Public_Server_checkBox;
        public System.Windows.Forms.CheckBox Auto_close_proxy_checkBox;
        public System.Windows.Forms.TextBox Game_Path_textBox;
        public System.Windows.Forms.Button Choice_Game_Path_button;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button Open_Check_button;
        public System.Windows.Forms.Button Find_GameExe_button;
        public System.Windows.Forms.ToolStripMenuItem 检查连接ToolStripMenuItem;
        public System.Windows.Forms.ColumnHeader Count_columnHeader;
        public System.Windows.Forms.Timer Status_timer;
        public System.Windows.Forms.ColumnHeader Ver_columnHeader;
        public System.Windows.Forms.ColumnHeader Ping_columnHeader;
        public System.Windows.Forms.Button Set_MetaInputpath_button;
        public System.Windows.Forms.TextBox MetaFile_Input_textBox;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button Set_MetaOutputpath_button;
        public System.Windows.Forms.TextBox MetaFile_Output_textBox;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button UnPatch_Meta_button;
        public System.Windows.Forms.Button Patch_Meta_button;
        public System.Windows.Forms.Button Encrypt_File_button;
        public System.Windows.Forms.Button Decrypt_File_button;
        public System.Windows.Forms.TabPage Meta_tabPage;
        public System.Windows.Forms.Panel Output_panel;
        public System.Windows.Forms.CheckBox INOUT_Meta_checkBox;
        public System.Windows.Forms.GroupBox Meta_Actions_groupBox;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label Author_label;
        private System.Windows.Forms.TabPage Patch_Settings_tabPage;
        private System.Windows.Forms.TabControl Patch_Bytes_tabControl;
        private System.Windows.Forms.TabPage Nopatch1_tabPage;
        private System.Windows.Forms.TabPage Patched1_tabPage;
        private System.Windows.Forms.TabPage Nopatch2_cn_tabPage;
        private System.Windows.Forms.TabPage Patched2_Meta_tabPage;
        private System.Windows.Forms.TabPage Nopatch2_os_tabPage;
        private System.Windows.Forms.TabPage Features_cn_tabPage;
        private System.Windows.Forms.TabPage Features_os_tabPage;
        private System.Windows.Forms.Panel SetChannel_Panel;
        private System.Windows.Forms.RadioButton CN_Channel_radioButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton OS_Channel_radioButton;
        private System.Windows.Forms.CheckBox CheckChannel_checkBox;
        private System.Windows.Forms.CheckBox PatchP1_checkBox;
        private System.Windows.Forms.Button Save_PC_button;
        public System.Windows.Forms.Button Reset_PC_button;
        private System.Windows.Forms.TextBox Nopatch1_textBox;
        private System.Windows.Forms.TextBox Patched1_textBox;
        private System.Windows.Forms.TextBox Patched2_Meta_textBox;
        private System.Windows.Forms.TextBox Nopatch2_cn_textBox;
        private System.Windows.Forms.TextBox Nopatch2_os_textBox;
        private System.Windows.Forms.TextBox Features_cn_textBox;
        private System.Windows.Forms.TextBox Features_os_textBox;
        private System.Windows.Forms.Label Patch_Settings_Tip_label;
        public System.Windows.Forms.TabPage UA_tabPage;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.GroupBox UA_Actions_groupBox;
        public System.Windows.Forms.Panel UA_Output_panel;
        public System.Windows.Forms.Button Set_UAOutputpath_button;
        public System.Windows.Forms.TextBox UAFile_Output_textBox;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.CheckBox INOUT_UA_checkBox;
        public System.Windows.Forms.Button Set_UAInputpath_button;
        public System.Windows.Forms.TextBox UAFile_Input_textBox;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button Patch_UA_button;
        private System.Windows.Forms.TabPage Patched2_UA_tabPage;
        private System.Windows.Forms.TextBox Patched2_UA_textBox;
        private System.Windows.Forms.Label NoServerTip_label;
        private System.Windows.Forms.Label Meta_DoingTip_label;
        private System.Windows.Forms.Label UA_DoingTip_label;
        public System.Windows.Forms.Button UnPatch_UA_button;
        public System.Windows.Forms.Button Save_Config_button;
    }
}


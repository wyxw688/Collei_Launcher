namespace Collei_Launcher
{
    partial class ThirdParty_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CCV2Url_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CloudPatchConfig_checkBox = new System.Windows.Forms.CheckBox();
            this.CPCUrl_textBox = new System.Windows.Forms.TextBox();
            this.AllowAddServer_checkBox = new System.Windows.Forms.CheckBox();
            this.MustShownCloudServers_checkBox = new System.Windows.Forms.CheckBox();
            this.AllowPatchMeta_checkBox = new System.Windows.Forms.CheckBox();
            this.AllowPatchUA_checkBox = new System.Windows.Forms.CheckBox();
            this.AllowModify_checkBox = new System.Windows.Forms.CheckBox();
            this.Save_button = new System.Windows.Forms.Button();
            this.HelpLink_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 92);
            this.label1.TabIndex = 0;
            this.label1.Text = "从此链接获取云端配置(更新,服务器,公告等):\r\n动态参数(非必须):\r\n<ver>启动器版本号\r\n<lang>客户端语言";
            // 
            // CCV2Url_textBox
            // 
            this.CCV2Url_textBox.Location = new System.Drawing.Point(12, 104);
            this.CCV2Url_textBox.Name = "CCV2Url_textBox";
            this.CCV2Url_textBox.Size = new System.Drawing.Size(358, 29);
            this.CCV2Url_textBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 23);
            this.label2.TabIndex = 2;
            // 
            // CloudPatchConfig_checkBox
            // 
            this.CloudPatchConfig_checkBox.AutoSize = true;
            this.CloudPatchConfig_checkBox.Location = new System.Drawing.Point(12, 139);
            this.CloudPatchConfig_checkBox.Name = "CloudPatchConfig_checkBox";
            this.CloudPatchConfig_checkBox.Size = new System.Drawing.Size(321, 27);
            this.CloudPatchConfig_checkBox.TabIndex = 3;
            this.CloudPatchConfig_checkBox.Text = "不允许更改修补设置，从以下链接获取";
            this.CloudPatchConfig_checkBox.UseVisualStyleBackColor = true;
            this.CloudPatchConfig_checkBox.CheckedChanged += new System.EventHandler(this.CloudPatchConfig_checkBox_CheckedChanged);
            // 
            // CPCUrl_textBox
            // 
            this.CPCUrl_textBox.Enabled = false;
            this.CPCUrl_textBox.Location = new System.Drawing.Point(12, 172);
            this.CPCUrl_textBox.Name = "CPCUrl_textBox";
            this.CPCUrl_textBox.Size = new System.Drawing.Size(358, 29);
            this.CPCUrl_textBox.TabIndex = 4;
            // 
            // AllowAddServer_checkBox
            // 
            this.AllowAddServer_checkBox.AutoSize = true;
            this.AllowAddServer_checkBox.Location = new System.Drawing.Point(12, 207);
            this.AllowAddServer_checkBox.Name = "AllowAddServer_checkBox";
            this.AllowAddServer_checkBox.Size = new System.Drawing.Size(185, 27);
            this.AllowAddServer_checkBox.TabIndex = 5;
            this.AllowAddServer_checkBox.Text = "允许手动添加服务器";
            this.AllowAddServer_checkBox.UseVisualStyleBackColor = true;
            // 
            // MustShownCloudServers_checkBox
            // 
            this.MustShownCloudServers_checkBox.AutoSize = true;
            this.MustShownCloudServers_checkBox.Location = new System.Drawing.Point(12, 240);
            this.MustShownCloudServers_checkBox.Name = "MustShownCloudServers_checkBox";
            this.MustShownCloudServers_checkBox.Size = new System.Drawing.Size(270, 27);
            this.MustShownCloudServers_checkBox.TabIndex = 6;
            this.MustShownCloudServers_checkBox.Text = "强制服务器列表显示云端服务器";
            this.MustShownCloudServers_checkBox.UseVisualStyleBackColor = true;
            // 
            // AllowPatchMeta_checkBox
            // 
            this.AllowPatchMeta_checkBox.AutoSize = true;
            this.AllowPatchMeta_checkBox.Location = new System.Drawing.Point(12, 273);
            this.AllowPatchMeta_checkBox.Name = "AllowPatchMeta_checkBox";
            this.AllowPatchMeta_checkBox.Size = new System.Drawing.Size(142, 27);
            this.AllowPatchMeta_checkBox.TabIndex = 7;
            this.AllowPatchMeta_checkBox.Text = "允许修补Meta";
            this.AllowPatchMeta_checkBox.UseVisualStyleBackColor = true;
            // 
            // AllowPatchUA_checkBox
            // 
            this.AllowPatchUA_checkBox.AutoSize = true;
            this.AllowPatchUA_checkBox.Location = new System.Drawing.Point(160, 273);
            this.AllowPatchUA_checkBox.Name = "AllowPatchUA_checkBox";
            this.AllowPatchUA_checkBox.Size = new System.Drawing.Size(125, 27);
            this.AllowPatchUA_checkBox.TabIndex = 8;
            this.AllowPatchUA_checkBox.Text = "允许修补UA";
            this.AllowPatchUA_checkBox.UseVisualStyleBackColor = true;
            // 
            // AllowModify_checkBox
            // 
            this.AllowModify_checkBox.AutoSize = true;
            this.AllowModify_checkBox.Location = new System.Drawing.Point(12, 306);
            this.AllowModify_checkBox.Name = "AllowModify_checkBox";
            this.AllowModify_checkBox.Size = new System.Drawing.Size(219, 27);
            this.AllowModify_checkBox.TabIndex = 9;
            this.AllowModify_checkBox.Text = "允许再次修改以上此设置";
            this.AllowModify_checkBox.UseVisualStyleBackColor = true;
            // 
            // Save_button
            // 
            this.Save_button.Location = new System.Drawing.Point(12, 346);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(219, 45);
            this.Save_button.TabIndex = 10;
            this.Save_button.Text = "保存设置并关闭此窗口";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // HelpLink_button
            // 
            this.HelpLink_button.Location = new System.Drawing.Point(237, 346);
            this.HelpLink_button.Name = "HelpLink_button";
            this.HelpLink_button.Size = new System.Drawing.Size(133, 45);
            this.HelpLink_button.TabIndex = 11;
            this.HelpLink_button.Text = "查看帮助";
            this.HelpLink_button.UseVisualStyleBackColor = true;
            this.HelpLink_button.Click += new System.EventHandler(this.HelpLink_button_Click);
            // 
            // ThirdParty_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(382, 403);
            this.Controls.Add(this.HelpLink_button);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.AllowModify_checkBox);
            this.Controls.Add(this.AllowPatchUA_checkBox);
            this.Controls.Add(this.AllowPatchMeta_checkBox);
            this.Controls.Add(this.MustShownCloudServers_checkBox);
            this.Controls.Add(this.AllowAddServer_checkBox);
            this.Controls.Add(this.CPCUrl_textBox);
            this.Controls.Add(this.CloudPatchConfig_checkBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CCV2Url_textBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "ThirdParty_Form";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "第三方设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CCV2Url_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CloudPatchConfig_checkBox;
        private System.Windows.Forms.TextBox CPCUrl_textBox;
        private System.Windows.Forms.CheckBox AllowAddServer_checkBox;
        private System.Windows.Forms.CheckBox MustShownCloudServers_checkBox;
        private System.Windows.Forms.CheckBox AllowPatchMeta_checkBox;
        private System.Windows.Forms.CheckBox AllowPatchUA_checkBox;
        private System.Windows.Forms.CheckBox AllowModify_checkBox;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.Button HelpLink_button;
    }
}
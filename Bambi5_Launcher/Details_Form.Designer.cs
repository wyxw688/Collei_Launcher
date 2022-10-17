namespace Collei_Launcher
{
    partial class Details_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Details_Form));
            this.Turn_button = new System.Windows.Forms.Button();
            this.Content_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Dispatch_port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.Host_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Title_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Status_statusStrip = new System.Windows.Forms.StatusStrip();
            this.Server_status_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Server_Status_timer = new System.Windows.Forms.Timer(this.components);
            this.Check_button = new System.Windows.Forms.Button();
            this.Turn_Proxy_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Log_richTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dispatch_port_numericUpDown)).BeginInit();
            this.Status_statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Turn_button
            // 
            resources.ApplyResources(this.Turn_button, "Turn_button");
            this.Turn_button.Name = "Turn_button";
            this.Turn_button.UseVisualStyleBackColor = true;
            this.Turn_button.Click += new System.EventHandler(this.Turn_button_Click);
            // 
            // Content_textBox
            // 
            resources.ApplyResources(this.Content_textBox, "Content_textBox");
            this.Content_textBox.Name = "Content_textBox";
            this.Content_textBox.ReadOnly = true;
            this.Content_textBox.Tag = "Content";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // Dispatch_port_numericUpDown
            // 
            resources.ApplyResources(this.Dispatch_port_numericUpDown, "Dispatch_port_numericUpDown");
            this.Dispatch_port_numericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Dispatch_port_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Dispatch_port_numericUpDown.Name = "Dispatch_port_numericUpDown";
            this.Dispatch_port_numericUpDown.ReadOnly = true;
            this.Dispatch_port_numericUpDown.Value = new decimal(new int[] {
            443,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // Host_textBox
            // 
            resources.ApplyResources(this.Host_textBox, "Host_textBox");
            this.Host_textBox.Name = "Host_textBox";
            this.Host_textBox.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // Title_textBox
            // 
            resources.ApplyResources(this.Title_textBox, "Title_textBox");
            this.Title_textBox.Name = "Title_textBox";
            this.Title_textBox.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Status_statusStrip
            // 
            this.Status_statusStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.Status_statusStrip, "Status_statusStrip");
            this.Status_statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Status_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Server_status_toolStripStatusLabel});
            this.Status_statusStrip.Name = "Status_statusStrip";
            // 
            // Server_status_toolStripStatusLabel
            // 
            this.Server_status_toolStripStatusLabel.Name = "Server_status_toolStripStatusLabel";
            resources.ApplyResources(this.Server_status_toolStripStatusLabel, "Server_status_toolStripStatusLabel");
            // 
            // Server_Status_timer
            // 
            this.Server_Status_timer.Enabled = true;
            this.Server_Status_timer.Interval = 2500;
            this.Server_Status_timer.Tick += new System.EventHandler(this.Server_Status_timer_Tick);
            // 
            // Check_button
            // 
            resources.ApplyResources(this.Check_button, "Check_button");
            this.Check_button.Name = "Check_button";
            this.Check_button.UseVisualStyleBackColor = true;
            this.Check_button.Click += new System.EventHandler(this.Check_button_Click);
            // 
            // Turn_Proxy_button
            // 
            resources.ApplyResources(this.Turn_Proxy_button, "Turn_Proxy_button");
            this.Turn_Proxy_button.Name = "Turn_Proxy_button";
            this.Turn_Proxy_button.UseVisualStyleBackColor = true;
            this.Turn_Proxy_button.Click += new System.EventHandler(this.Turn_Proxy_button_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Log_richTextBox
            // 
            resources.ApplyResources(this.Log_richTextBox, "Log_richTextBox");
            this.Log_richTextBox.Name = "Log_richTextBox";
            this.Log_richTextBox.ReadOnly = true;
            // 
            // Details_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Log_richTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Turn_Proxy_button);
            this.Controls.Add(this.Check_button);
            this.Controls.Add(this.Status_statusStrip);
            this.Controls.Add(this.Turn_button);
            this.Controls.Add(this.Content_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Dispatch_port_numericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Host_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Title_textBox);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.Name = "Details_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Index_Form_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Index_Form_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Dispatch_port_numericUpDown)).EndInit();
            this.Status_statusStrip.ResumeLayout(false);
            this.Status_statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Turn_button;
        private System.Windows.Forms.TextBox Content_textBox;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown Dispatch_port_numericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Host_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Title_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip Status_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel Server_status_toolStripStatusLabel;
        private System.Windows.Forms.Timer Server_Status_timer;
        private System.Windows.Forms.Button Check_button;
        private System.Windows.Forms.Button Turn_Proxy_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox Log_richTextBox;
    }
}
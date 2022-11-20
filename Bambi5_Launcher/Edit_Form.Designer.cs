namespace Collei_Launcher
{
    partial class Edit_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_Form));
            this.label3 = new System.Windows.Forms.Label();
            this.Title_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Host_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Dispatch_port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.Content_textBox = new System.Windows.Forms.TextBox();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.Update_button = new System.Windows.Forms.Button();
            this.UseSSL_checkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dispatch_port_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Title_textBox
            // 
            resources.ApplyResources(this.Title_textBox, "Title_textBox");
            this.Title_textBox.Name = "Title_textBox";
            this.Title_textBox.TextChanged += new System.EventHandler(this.Title_textBox_TextChanged);
            this.Title_textBox.Enter += new System.EventHandler(this.Title_textBox_Enter);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // Host_textBox
            // 
            resources.ApplyResources(this.Host_textBox, "Host_textBox");
            this.Host_textBox.Name = "Host_textBox";
            this.Host_textBox.TextChanged += new System.EventHandler(this.Host_textBox_TextChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
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
            this.Dispatch_port_numericUpDown.Value = new decimal(new int[] {
            443,
            0,
            0,
            0});
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // Content_textBox
            // 
            resources.ApplyResources(this.Content_textBox, "Content_textBox");
            this.Content_textBox.Name = "Content_textBox";
            this.Content_textBox.Tag = "Content";
            // 
            // Cancel_button
            // 
            resources.ApplyResources(this.Cancel_button, "Cancel_button");
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // Update_button
            // 
            resources.ApplyResources(this.Update_button, "Update_button");
            this.Update_button.Name = "Update_button";
            this.Update_button.UseVisualStyleBackColor = true;
            this.Update_button.Click += new System.EventHandler(this.Update_button_Click);
            // 
            // UseSSL_checkBox
            // 
            resources.ApplyResources(this.UseSSL_checkBox, "UseSSL_checkBox");
            this.UseSSL_checkBox.Checked = true;
            this.UseSSL_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseSSL_checkBox.Name = "UseSSL_checkBox";
            this.UseSSL_checkBox.UseVisualStyleBackColor = true;
            // 
            // Edit_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.UseSSL_checkBox);
            this.Controls.Add(this.Update_button);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Content_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Dispatch_port_numericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Host_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Title_textBox);
            this.Controls.Add(this.label3);
            this.Name = "Edit_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Edit_Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Dispatch_port_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Title_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Host_textBox;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown Dispatch_port_numericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Content_textBox;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button Update_button;
        private System.Windows.Forms.CheckBox UseSSL_checkBox;
    }
}
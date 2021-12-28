namespace Vm4j_exp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.targetGroupBox = new System.Windows.Forms.GroupBox();
            this.ProductListBox = new System.Windows.Forms.ComboBox();
            this.ProductLabel = new System.Windows.Forms.Label();
            this.targetBox = new System.Windows.Forms.TextBox();
            this.TargetLabel = new System.Windows.Forms.Label();
            this.serverGroupBox = new System.Windows.Forms.GroupBox();
            this.cmdBox = new System.Windows.Forms.TextBox();
            this.cmdlabel = new System.Windows.Forms.Label();
            this.payloadBox = new System.Windows.Forms.ComboBox();
            this.payloadlabel = new System.Windows.Forms.Label();
            this.gadgetBox = new System.Windows.Forms.ComboBox();
            this.SvrIpBox = new System.Windows.Forms.TextBox();
            this.gadgetLabel = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.SvrIpLabel = new System.Windows.Forms.Label();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.infoTxtBox = new System.Windows.Forms.RichTextBox();
            this.logBox = new System.Windows.Forms.GroupBox();
            this.logTxtBox = new System.Windows.Forms.RichTextBox();
            this.targetGroupBox.SuspendLayout();
            this.serverGroupBox.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.logBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // targetGroupBox
            // 
            this.targetGroupBox.Controls.Add(this.ProductListBox);
            this.targetGroupBox.Controls.Add(this.ProductLabel);
            this.targetGroupBox.Controls.Add(this.targetBox);
            this.targetGroupBox.Controls.Add(this.TargetLabel);
            this.targetGroupBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetGroupBox.Location = new System.Drawing.Point(12, 12);
            this.targetGroupBox.Name = "targetGroupBox";
            this.targetGroupBox.Size = new System.Drawing.Size(332, 100);
            this.targetGroupBox.TabIndex = 0;
            this.targetGroupBox.TabStop = false;
            this.targetGroupBox.Text = "Target";
            // 
            // ProductListBox
            // 
            this.ProductListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProductListBox.Enabled = false;
            this.ProductListBox.FormattingEnabled = true;
            this.ProductListBox.Items.AddRange(new object[] {
            "VMware HCX",
            "VMware vCenter",
            "VMware Workspace One",
            "VMware NSX",
            "VMware Horizon",
            "VMware vRealize Operations Manager"});
            this.ProductListBox.Location = new System.Drawing.Point(85, 60);
            this.ProductListBox.Name = "ProductListBox";
            this.ProductListBox.Size = new System.Drawing.Size(229, 23);
            this.ProductListBox.TabIndex = 3;
            this.ProductListBox.SelectedValueChanged += new System.EventHandler(this.ProductListBox_SelectedValueChanged);
            // 
            // ProductLabel
            // 
            this.ProductLabel.AutoSize = true;
            this.ProductLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.ProductLabel.Location = new System.Drawing.Point(17, 66);
            this.ProductLabel.Name = "ProductLabel";
            this.ProductLabel.Size = new System.Drawing.Size(62, 18);
            this.ProductLabel.TabIndex = 2;
            this.ProductLabel.Text = "Product";
            // 
            // targetBox
            // 
            this.targetBox.BackColor = System.Drawing.SystemColors.Window;
            this.targetBox.Location = new System.Drawing.Point(84, 24);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(230, 21);
            this.targetBox.TabIndex = 1;
            this.targetBox.TextChanged += new System.EventHandler(this.TargetInputBox_TextChanged);
            // 
            // TargetLabel
            // 
            this.TargetLabel.AutoSize = true;
            this.TargetLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.TargetLabel.Location = new System.Drawing.Point(17, 24);
            this.TargetLabel.Name = "TargetLabel";
            this.TargetLabel.Size = new System.Drawing.Size(51, 18);
            this.TargetLabel.TabIndex = 0;
            this.TargetLabel.Text = "Target";
            // 
            // serverGroupBox
            // 
            this.serverGroupBox.Controls.Add(this.cmdBox);
            this.serverGroupBox.Controls.Add(this.cmdlabel);
            this.serverGroupBox.Controls.Add(this.payloadBox);
            this.serverGroupBox.Controls.Add(this.payloadlabel);
            this.serverGroupBox.Controls.Add(this.gadgetBox);
            this.serverGroupBox.Controls.Add(this.SvrIpBox);
            this.serverGroupBox.Controls.Add(this.gadgetLabel);
            this.serverGroupBox.Controls.Add(this.sendBtn);
            this.serverGroupBox.Controls.Add(this.SvrIpLabel);
            this.serverGroupBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverGroupBox.Location = new System.Drawing.Point(350, 12);
            this.serverGroupBox.Name = "serverGroupBox";
            this.serverGroupBox.Size = new System.Drawing.Size(562, 100);
            this.serverGroupBox.TabIndex = 1;
            this.serverGroupBox.TabStop = false;
            this.serverGroupBox.Text = "Server";
            // 
            // cmdBox
            // 
            this.cmdBox.Enabled = false;
            this.cmdBox.Location = new System.Drawing.Point(361, 24);
            this.cmdBox.Name = "cmdBox";
            this.cmdBox.Size = new System.Drawing.Size(195, 21);
            this.cmdBox.TabIndex = 17;
            // 
            // cmdlabel
            // 
            this.cmdlabel.AutoSize = true;
            this.cmdlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdlabel.Location = new System.Drawing.Point(274, 24);
            this.cmdlabel.Name = "cmdlabel";
            this.cmdlabel.Size = new System.Drawing.Size(81, 18);
            this.cmdlabel.TabIndex = 16;
            this.cmdlabel.Text = "Command";
            // 
            // payloadBox
            // 
            this.payloadBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payloadBox.DropDownWidth = 228;
            this.payloadBox.Enabled = false;
            this.payloadBox.FormattingEnabled = true;
            this.payloadBox.IntegralHeight = false;
            this.payloadBox.Location = new System.Drawing.Point(263, 60);
            this.payloadBox.Name = "payloadBox";
            this.payloadBox.Size = new System.Drawing.Size(229, 23);
            this.payloadBox.TabIndex = 15;
            this.payloadBox.SelectedValueChanged += new System.EventHandler(this.payloadBox_SelectedValueChanged);
            // 
            // payloadlabel
            // 
            this.payloadlabel.AutoSize = true;
            this.payloadlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payloadlabel.Location = new System.Drawing.Point(199, 62);
            this.payloadlabel.Name = "payloadlabel";
            this.payloadlabel.Size = new System.Drawing.Size(65, 18);
            this.payloadlabel.TabIndex = 14;
            this.payloadlabel.Text = "Payload";
            // 
            // gadgetBox
            // 
            this.gadgetBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gadgetBox.FormattingEnabled = true;
            this.gadgetBox.Items.AddRange(new object[] {
            "Basic",
            "Deserialize",
            "TomcatBypass",
            "GroovyBypass",
            "WebsphereBypass"});
            this.gadgetBox.Location = new System.Drawing.Point(87, 60);
            this.gadgetBox.Name = "gadgetBox";
            this.gadgetBox.Size = new System.Drawing.Size(110, 23);
            this.gadgetBox.TabIndex = 13;
            this.gadgetBox.SelectedValueChanged += new System.EventHandler(this.gadgetBox_SelectedValueChanged);
            // 
            // SvrIpBox
            // 
            this.SvrIpBox.Location = new System.Drawing.Point(87, 24);
            this.SvrIpBox.Name = "SvrIpBox";
            this.SvrIpBox.Size = new System.Drawing.Size(181, 21);
            this.SvrIpBox.TabIndex = 12;
            // 
            // gadgetLabel
            // 
            this.gadgetLabel.AutoSize = true;
            this.gadgetLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gadgetLabel.Location = new System.Drawing.Point(9, 62);
            this.gadgetLabel.Name = "gadgetLabel";
            this.gadgetLabel.Size = new System.Drawing.Size(60, 18);
            this.gadgetLabel.TabIndex = 11;
            this.gadgetLabel.Text = "Gadget";
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(498, 58);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(58, 25);
            this.sendBtn.TabIndex = 10;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // SvrIpLabel
            // 
            this.SvrIpLabel.AutoSize = true;
            this.SvrIpLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SvrIpLabel.Location = new System.Drawing.Point(9, 24);
            this.SvrIpLabel.Name = "SvrIpLabel";
            this.SvrIpLabel.Size = new System.Drawing.Size(72, 18);
            this.SvrIpLabel.TabIndex = 0;
            this.SvrIpLabel.Text = "Server IP";
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.infoTxtBox);
            this.infoBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBox.Location = new System.Drawing.Point(11, 125);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(429, 330);
            this.infoBox.TabIndex = 2;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "infoBox";
            // 
            // infoTxtBox
            // 
            this.infoTxtBox.BackColor = System.Drawing.SystemColors.Control;
            this.infoTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoTxtBox.Location = new System.Drawing.Point(6, 16);
            this.infoTxtBox.Name = "infoTxtBox";
            this.infoTxtBox.Size = new System.Drawing.Size(414, 309);
            this.infoTxtBox.TabIndex = 0;
            this.infoTxtBox.Text = "";
            // 
            // logBox
            // 
            this.logBox.Controls.Add(this.logTxtBox);
            this.logBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBox.Location = new System.Drawing.Point(446, 125);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(466, 330);
            this.logBox.TabIndex = 3;
            this.logBox.TabStop = false;
            this.logBox.Text = "logBox";
            // 
            // logTxtBox
            // 
            this.logTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTxtBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTxtBox.Location = new System.Drawing.Point(6, 20);
            this.logTxtBox.Name = "logTxtBox";
            this.logTxtBox.ReadOnly = true;
            this.logTxtBox.Size = new System.Drawing.Size(442, 300);
            this.logTxtBox.TabIndex = 0;
            this.logTxtBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 461);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.serverGroupBox);
            this.Controls.Add(this.targetGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vm4J Exploit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.targetGroupBox.ResumeLayout(false);
            this.targetGroupBox.PerformLayout();
            this.serverGroupBox.ResumeLayout(false);
            this.serverGroupBox.PerformLayout();
            this.infoBox.ResumeLayout(false);
            this.logBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox targetGroupBox;
        private System.Windows.Forms.GroupBox serverGroupBox;
        private System.Windows.Forms.Label ProductLabel;
        private System.Windows.Forms.Label TargetLabel;
        private System.Windows.Forms.ComboBox ProductListBox;
        private System.Windows.Forms.Label SvrIpLabel;
        private System.Windows.Forms.TextBox targetBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.GroupBox infoBox;
        private System.Windows.Forms.GroupBox logBox;
        public System.Windows.Forms.RichTextBox logTxtBox;
        private System.Windows.Forms.TextBox cmdBox;
        private System.Windows.Forms.Label cmdlabel;
        private System.Windows.Forms.ComboBox payloadBox;
        private System.Windows.Forms.Label payloadlabel;
        private System.Windows.Forms.ComboBox gadgetBox;
        private System.Windows.Forms.TextBox SvrIpBox;
        private System.Windows.Forms.Label gadgetLabel;
        public System.Windows.Forms.RichTextBox infoTxtBox;
    }
}


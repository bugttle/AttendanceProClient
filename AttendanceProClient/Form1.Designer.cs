namespace AttendanceProClient {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();

                // WebClientの破棄
                mClient.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator toolStripSeparator;
            System.Windows.Forms.Label userIdLabel;
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label companyCodeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemIn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemOpenBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.companyCodeTextBox = new System.Windows.Forms.TextBox();
            this.toolStripMenuItemPreference = new System.Windows.Forms.ToolStripMenuItem();
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            userIdLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            companyCodeLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(155, 6);
            // 
            // userIdLabel
            // 
            userIdLabel.AutoSize = true;
            userIdLabel.Location = new System.Drawing.Point(12, 22);
            userIdLabel.Name = "userIdLabel";
            userIdLabel.Size = new System.Drawing.Size(56, 12);
            userIdLabel.TabIndex = 3;
            userIdLabel.Text = "ユーザーID";
            userIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(16, 56);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(52, 12);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "パスワード";
            passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // companyCodeLabel
            // 
            companyCodeLabel.AutoSize = true;
            companyCodeLabel.Location = new System.Drawing.Point(12, 90);
            companyCodeLabel.Name = "companyCodeLabel";
            companyCodeLabel.Size = new System.Drawing.Size(56, 12);
            companyCodeLabel.TabIndex = 6;
            companyCodeLabel.Text = "企業コード";
            companyCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AttendancePro Client (非公式)";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemIn,
            this.toolStripMenuItemOut,
            this.toolStripSeparator1,
            this.toolStripMenuItemOpenBrowser,
            toolStripSeparator,
            this.toolStripMenuItemPreference,
            this.toolStripMenuItemExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(159, 126);
            // 
            // toolStripMenuItemIn
            // 
            this.toolStripMenuItemIn.Name = "toolStripMenuItemIn";
            this.toolStripMenuItemIn.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemIn.Text = "出社";
            this.toolStripMenuItemIn.Click += new System.EventHandler(this.toolStripMenuItemIn_Click);
            // 
            // toolStripMenuItemOut
            // 
            this.toolStripMenuItemOut.Name = "toolStripMenuItemOut";
            this.toolStripMenuItemOut.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemOut.Text = "退社";
            this.toolStripMenuItemOut.Click += new System.EventHandler(this.toolStripMenuItemOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // toolStripMenuItemOpenBrowser
            // 
            this.toolStripMenuItemOpenBrowser.Name = "toolStripMenuItemOpenBrowser";
            this.toolStripMenuItemOpenBrowser.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemOpenBrowser.Text = "ブラウザで開く";
            this.toolStripMenuItemOpenBrowser.Click += new System.EventHandler(this.toolStripMenuItemOpenBrowser_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemExit.Text = "終了";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.Location = new System.Drawing.Point(72, 19);
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(140, 19);
            this.userIdTextBox.TabIndex = 0;
            this.userIdTextBox.TextChanged += new System.EventHandler(this.userIdTextBox_TextChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(72, 53);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(140, 19);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // companyCodeTextBox
            // 
            this.companyCodeTextBox.Location = new System.Drawing.Point(72, 87);
            this.companyCodeTextBox.Name = "companyCodeTextBox";
            this.companyCodeTextBox.ReadOnly = true;
            this.companyCodeTextBox.Size = new System.Drawing.Size(140, 19);
            this.companyCodeTextBox.TabIndex = 2;
            this.companyCodeTextBox.TabStop = false;
            // 
            // toolStripMenuItemPreference
            // 
            this.toolStripMenuItemPreference.Name = "toolStripMenuItemPreference";
            this.toolStripMenuItemPreference.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemPreference.Text = "設定";
            this.toolStripMenuItemPreference.Click += new System.EventHandler(this.toolStripMenuItemPreference_Click);
            // 
            // checkBox
            // 
            this.startupCheckBox.AutoSize = true;
            this.startupCheckBox.Location = new System.Drawing.Point(12, 122);
            this.startupCheckBox.Name = "checkBox";
            this.startupCheckBox.Size = new System.Drawing.Size(205, 16);
            this.startupCheckBox.TabIndex = 7;
            this.startupCheckBox.Text = "スタートアップへ登録 (自動起動させる)";
            this.startupCheckBox.UseVisualStyleBackColor = true;
            this.startupCheckBox.CheckedChanged += new System.EventHandler(this.startupCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 150);
            this.Controls.Add(this.startupCheckBox);
            this.Controls.Add(this.companyCodeTextBox);
            this.Controls.Add(companyCodeLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userIdTextBox);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(userIdLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "AttendancePro Client (非公式)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOut;
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.TextBox companyCodeTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenBrowser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPreference;
        private System.Windows.Forms.CheckBox startupCheckBox;
    }
}


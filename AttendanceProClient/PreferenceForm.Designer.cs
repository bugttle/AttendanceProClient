namespace AttendanceProClient {
    partial class PreferenceForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferenceForm));
            System.Windows.Forms.Label userIdLabel;
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label companyCodeLabel;
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemIn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemShowWorkingLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemOpenBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPreference = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.companyCodeTextBox = new System.Windows.Forms.TextBox();
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            this.loginCheckButton = new System.Windows.Forms.Button();
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
            resources.ApplyResources(toolStripSeparator, "toolStripSeparator");
            // 
            // userIdLabel
            // 
            resources.ApplyResources(userIdLabel, "userIdLabel");
            userIdLabel.Name = "userIdLabel";
            // 
            // passwordLabel
            // 
            resources.ApplyResources(passwordLabel, "passwordLabel");
            passwordLabel.Name = "passwordLabel";
            // 
            // companyCodeLabel
            // 
            resources.ApplyResources(companyCodeLabel, "companyCodeLabel");
            companyCodeLabel.Name = "companyCodeLabel";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemIn,
            this.toolStripMenuItemOut,
            this.toolStripSeparator1,
            this.toolStripMenuItemShowWorkingLog,
            this.toolStripSeparator2,
            this.toolStripMenuItemOpenBrowser,
            toolStripSeparator,
            this.toolStripMenuItemPreference,
            this.toolStripMenuItemExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // toolStripMenuItemIn
            // 
            this.toolStripMenuItemIn.Name = "toolStripMenuItemIn";
            resources.ApplyResources(this.toolStripMenuItemIn, "toolStripMenuItemIn");
            this.toolStripMenuItemIn.Click += new System.EventHandler(this.toolStripMenuItemIn_Click);
            // 
            // toolStripMenuItemOut
            // 
            this.toolStripMenuItemOut.Name = "toolStripMenuItemOut";
            resources.ApplyResources(this.toolStripMenuItemOut, "toolStripMenuItemOut");
            this.toolStripMenuItemOut.Click += new System.EventHandler(this.toolStripMenuItemOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripMenuItemShowWorkingLog
            // 
            this.toolStripMenuItemShowWorkingLog.Name = "toolStripMenuItemShowWorkingLog";
            resources.ApplyResources(this.toolStripMenuItemShowWorkingLog, "toolStripMenuItemShowWorkingLog");
            this.toolStripMenuItemShowWorkingLog.Click += new System.EventHandler(this.toolStripMenuItemShowWorkingLog_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripMenuItemOpenBrowser
            // 
            this.toolStripMenuItemOpenBrowser.Name = "toolStripMenuItemOpenBrowser";
            resources.ApplyResources(this.toolStripMenuItemOpenBrowser, "toolStripMenuItemOpenBrowser");
            this.toolStripMenuItemOpenBrowser.Click += new System.EventHandler(this.toolStripMenuItemOpenBrowser_Click);
            // 
            // toolStripMenuItemPreference
            // 
            this.toolStripMenuItemPreference.Name = "toolStripMenuItemPreference";
            resources.ApplyResources(this.toolStripMenuItemPreference, "toolStripMenuItemPreference");
            this.toolStripMenuItemPreference.Click += new System.EventHandler(this.toolStripMenuItemPreference_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            resources.ApplyResources(this.toolStripMenuItemExit, "toolStripMenuItemExit");
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // userIdTextBox
            // 
            resources.ApplyResources(this.userIdTextBox, "userIdTextBox");
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.TextChanged += new System.EventHandler(this.userIdTextBox_TextChanged);
            // 
            // passwordTextBox
            // 
            resources.ApplyResources(this.passwordTextBox, "passwordTextBox");
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // companyCodeTextBox
            // 
            resources.ApplyResources(this.companyCodeTextBox, "companyCodeTextBox");
            this.companyCodeTextBox.Name = "companyCodeTextBox";
            this.companyCodeTextBox.ReadOnly = true;
            this.companyCodeTextBox.TabStop = false;
            // 
            // startupCheckBox
            // 
            resources.ApplyResources(this.startupCheckBox, "startupCheckBox");
            this.startupCheckBox.Name = "startupCheckBox";
            this.startupCheckBox.UseVisualStyleBackColor = true;
            this.startupCheckBox.CheckedChanged += new System.EventHandler(this.startupCheckBox_CheckedChanged);
            // 
            // loginCheckButton
            // 
            resources.ApplyResources(this.loginCheckButton, "loginCheckButton");
            this.loginCheckButton.Name = "loginCheckButton";
            this.loginCheckButton.UseVisualStyleBackColor = true;
            this.loginCheckButton.Click += new System.EventHandler(this.loginCheckButton_Click);
            // 
            // PreferenceForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loginCheckButton);
            this.Controls.Add(this.startupCheckBox);
            this.Controls.Add(this.companyCodeTextBox);
            this.Controls.Add(companyCodeLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userIdTextBox);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(userIdLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "PreferenceForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
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
        private System.Windows.Forms.Button loginCheckButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowWorkingLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}


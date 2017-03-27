namespace AttendanceProClient
{
    partial class MonthlyReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyReportForm));
            this.workingLogsTextBox = new System.Windows.Forms.TextBox();
            this.reloadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // workingLogsTextBox
            // 
            this.workingLogsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workingLogsTextBox.Location = new System.Drawing.Point(12, 12);
            this.workingLogsTextBox.Multiline = true;
            this.workingLogsTextBox.Name = "workingLogsTextBox";
            this.workingLogsTextBox.Size = new System.Drawing.Size(312, 203);
            this.workingLogsTextBox.TabIndex = 0;
            // 
            // reloadButton
            // 
            this.reloadButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.reloadButton.Location = new System.Drawing.Point(127, 226);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(75, 23);
            this.reloadButton.TabIndex = 1;
            this.reloadButton.Text = "更新";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // MonthlyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 261);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.workingLogsTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonthlyReportForm";
            this.Text = "部下の勤務情報を表示";
            this.Load += new System.EventHandler(this.MonthlyReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox workingLogsTextBox;
        private System.Windows.Forms.Button reloadButton;
    }
}
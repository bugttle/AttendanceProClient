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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyReportForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.workingLogsTextBox = new System.Windows.Forms.TextBox();
            this.reloadButton = new System.Windows.Forms.Button();
            this.subordinatesDataGridView = new System.Windows.Forms.DataGridView();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.dataGridViewColumnPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnTotalMonthlyNeeds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewWorkingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTotalOvertime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.subordinatesDataGridView)).BeginInit();
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
            this.workingLogsTextBox.Size = new System.Drawing.Size(331, 46);
            this.workingLogsTextBox.TabIndex = 0;
            // 
            // reloadButton
            // 
            this.reloadButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.reloadButton.Location = new System.Drawing.Point(292, 272);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(75, 23);
            this.reloadButton.TabIndex = 1;
            this.reloadButton.Text = "更新";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // subordinatesDataGridView
            // 
            this.subordinatesDataGridView.AllowUserToAddRows = false;
            this.subordinatesDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.subordinatesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.subordinatesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subordinatesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewColumnPersonName,
            this.dataGridViewColumnTotalMonthlyNeeds,
            this.dataGridViewWorkingTime,
            this.dataGridViewColumn,
            this.dataGridViewTotalOvertime,
            this.col});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.subordinatesDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.subordinatesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.subordinatesDataGridView.Name = "subordinatesDataGridView";
            this.subordinatesDataGridView.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.subordinatesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.subordinatesDataGridView.RowTemplate.Height = 21;
            this.subordinatesDataGridView.Size = new System.Drawing.Size(643, 250);
            this.subordinatesDataGridView.TabIndex = 2;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AttendancePro Client (非公式)";
            this.notifyIcon.Visible = true;
            // 
            // dataGridViewColumnPersonName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewColumnPersonName.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewColumnPersonName.HeaderText = "名前";
            this.dataGridViewColumnPersonName.Name = "dataGridViewColumnPersonName";
            this.dataGridViewColumnPersonName.ReadOnly = true;
            // 
            // dataGridViewColumnTotalMonthlyNeeds
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewColumnTotalMonthlyNeeds.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewColumnTotalMonthlyNeeds.HeaderText = "所定労働時間";
            this.dataGridViewColumnTotalMonthlyNeeds.Name = "dataGridViewColumnTotalMonthlyNeeds";
            this.dataGridViewColumnTotalMonthlyNeeds.ReadOnly = true;
            // 
            // dataGridViewWorkingTime
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewWorkingTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewWorkingTime.HeaderText = "勤務時間";
            this.dataGridViewWorkingTime.Name = "dataGridViewWorkingTime";
            this.dataGridViewWorkingTime.ReadOnly = true;
            // 
            // dataGridViewColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewColumn.HeaderText = "不就労";
            this.dataGridViewColumn.Name = "dataGridViewColumn";
            this.dataGridViewColumn.ReadOnly = true;
            // 
            // dataGridViewTotalOvertime
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTotalOvertime.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTotalOvertime.HeaderText = "累計残業時間";
            this.dataGridViewTotalOvertime.Name = "dataGridViewTotalOvertime";
            this.dataGridViewTotalOvertime.ReadOnly = true;
            // 
            // col
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col.DefaultCellStyle = dataGridViewCellStyle7;
            this.col.HeaderText = "未入力日数";
            this.col.Name = "col";
            this.col.ReadOnly = true;
            // 
            // MonthlyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 307);
            this.Controls.Add(this.subordinatesDataGridView);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.workingLogsTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonthlyReportForm";
            this.Text = "部下の勤務情報を表示";
            this.Load += new System.EventHandler(this.MonthlyReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.subordinatesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox workingLogsTextBox;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.DataGridView subordinatesDataGridView;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnPersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnTotalMonthlyNeeds;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewWorkingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTotalOvertime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col;
    }
}
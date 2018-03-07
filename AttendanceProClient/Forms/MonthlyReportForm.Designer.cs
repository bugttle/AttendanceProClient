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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyReportForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.reloadButton = new System.Windows.Forms.Button();
            this.subordinatesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewColumnPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnTotalMonthlyNeeds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewWorkingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTotalOvertime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.subordinatesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // reloadButton
            // 
            resources.ApplyResources(this.reloadButton, "reloadButton");
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // subordinatesDataGridView
            // 
            this.subordinatesDataGridView.AllowUserToAddRows = false;
            this.subordinatesDataGridView.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.subordinatesDataGridView, "subordinatesDataGridView");
            this.subordinatesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            // 
            // dataGridViewColumnPersonName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewColumnPersonName.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dataGridViewColumnPersonName, "dataGridViewColumnPersonName");
            this.dataGridViewColumnPersonName.Name = "dataGridViewColumnPersonName";
            this.dataGridViewColumnPersonName.ReadOnly = true;
            // 
            // dataGridViewColumnTotalMonthlyNeeds
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewColumnTotalMonthlyNeeds.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dataGridViewColumnTotalMonthlyNeeds, "dataGridViewColumnTotalMonthlyNeeds");
            this.dataGridViewColumnTotalMonthlyNeeds.Name = "dataGridViewColumnTotalMonthlyNeeds";
            this.dataGridViewColumnTotalMonthlyNeeds.ReadOnly = true;
            // 
            // dataGridViewWorkingTime
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewWorkingTime.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dataGridViewWorkingTime, "dataGridViewWorkingTime");
            this.dataGridViewWorkingTime.Name = "dataGridViewWorkingTime";
            this.dataGridViewWorkingTime.ReadOnly = true;
            // 
            // dataGridViewColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewColumn.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.dataGridViewColumn, "dataGridViewColumn");
            this.dataGridViewColumn.Name = "dataGridViewColumn";
            this.dataGridViewColumn.ReadOnly = true;
            // 
            // dataGridViewTotalOvertime
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTotalOvertime.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.dataGridViewTotalOvertime, "dataGridViewTotalOvertime");
            this.dataGridViewTotalOvertime.Name = "dataGridViewTotalOvertime";
            this.dataGridViewTotalOvertime.ReadOnly = true;
            // 
            // col
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.col, "col");
            this.col.Name = "col";
            this.col.ReadOnly = true;
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            // 
            // MonthlyReportForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.subordinatesDataGridView);
            this.Controls.Add(this.reloadButton);
            this.Name = "MonthlyReportForm";
            this.Load += new System.EventHandler(this.MonthlyReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.subordinatesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
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
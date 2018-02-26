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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
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
            resources.ApplyResources(this.subordinatesDataGridView, "subordinatesDataGridView");
            this.subordinatesDataGridView.AllowUserToAddRows = false;
            this.subordinatesDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.subordinatesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.subordinatesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subordinatesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewColumnPersonName,
            this.dataGridViewColumnTotalMonthlyNeeds,
            this.dataGridViewWorkingTime,
            this.dataGridViewColumn,
            this.dataGridViewTotalOvertime,
            this.col});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.subordinatesDataGridView.DefaultCellStyle = dataGridViewCellStyle17;
            this.subordinatesDataGridView.Name = "subordinatesDataGridView";
            this.subordinatesDataGridView.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.subordinatesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.subordinatesDataGridView.RowTemplate.Height = 21;
            // 
            // dataGridViewColumnPersonName
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewColumnPersonName.DefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(this.dataGridViewColumnPersonName, "dataGridViewColumnPersonName");
            this.dataGridViewColumnPersonName.Name = "dataGridViewColumnPersonName";
            this.dataGridViewColumnPersonName.ReadOnly = true;
            // 
            // dataGridViewColumnTotalMonthlyNeeds
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewColumnTotalMonthlyNeeds.DefaultCellStyle = dataGridViewCellStyle12;
            resources.ApplyResources(this.dataGridViewColumnTotalMonthlyNeeds, "dataGridViewColumnTotalMonthlyNeeds");
            this.dataGridViewColumnTotalMonthlyNeeds.Name = "dataGridViewColumnTotalMonthlyNeeds";
            this.dataGridViewColumnTotalMonthlyNeeds.ReadOnly = true;
            // 
            // dataGridViewWorkingTime
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewWorkingTime.DefaultCellStyle = dataGridViewCellStyle13;
            resources.ApplyResources(this.dataGridViewWorkingTime, "dataGridViewWorkingTime");
            this.dataGridViewWorkingTime.Name = "dataGridViewWorkingTime";
            this.dataGridViewWorkingTime.ReadOnly = true;
            // 
            // dataGridViewColumn
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewColumn.DefaultCellStyle = dataGridViewCellStyle14;
            resources.ApplyResources(this.dataGridViewColumn, "dataGridViewColumn");
            this.dataGridViewColumn.Name = "dataGridViewColumn";
            this.dataGridViewColumn.ReadOnly = true;
            // 
            // dataGridViewTotalOvertime
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTotalOvertime.DefaultCellStyle = dataGridViewCellStyle15;
            resources.ApplyResources(this.dataGridViewTotalOvertime, "dataGridViewTotalOvertime");
            this.dataGridViewTotalOvertime.Name = "dataGridViewTotalOvertime";
            this.dataGridViewTotalOvertime.ReadOnly = true;
            // 
            // col
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col.DefaultCellStyle = dataGridViewCellStyle16;
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
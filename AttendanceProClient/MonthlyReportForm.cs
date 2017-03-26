using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AttendanceProClient.Account;
using AttendanceProClient.Client;

namespace AttendanceProClient
{
    public partial class MonthlyReportForm : Form
    {
        public MonthlyReportForm()
        {
            InitializeComponent();
        }

        void MonthlyReportForm_Load(object sender, EventArgs e)
        {
            UpdateSubordinateLog();
        }

        async void UpdateSubordinateLog()
        {
            var account = AccountManager.Instance.Account;
            var workingLogs = await AttendanceProClient.Instance.FetchSubordinateWorkingLogs(account);

            workingLogsTextBox.Text = "所定労働時間 | 勤務時間 | 合計残業時間" + Environment.NewLine + "==============================" + Environment.NewLine;
            workingLogsTextBox.Text = string.Join(Environment.NewLine, workingLogs.Select(log =>
            {
                return log.PersonName + "\t" +
                string.Format("{0:F1}h ", log.TotalMonthlyNeeds.TotalHours) +
                string.Format("{0:F1}h ", log.TotalMonthlyCurrent.TotalHours) +
                string.Format("{0:F1}h ", log.TotalMonthlyOvertime.TotalHours);
            }).ToArray());
        }

        void reloadButton_Click(object sender, EventArgs e)
        {
            UpdateSubordinateLog();
        }
    }
}

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
            try
            {
                reloadButton.Enabled = false;
                workingLogsTextBox.Text = "読み込み中...";

                var account = AccountManager.Instance.Account;
                var workingLogs = await AttendanceProClient.Instance.FetchSubordinateWorkingLogs(account);

                workingLogsTextBox.Text = "名前 | 所定労働時間 | 勤務時間 | 合計残業時間" + Environment.NewLine + "==============================" + Environment.NewLine;
                workingLogsTextBox.Text += string.Join(Environment.NewLine, workingLogs.Select(log =>
                {
                    return log.PersonName + " | " +
                    string.Format("{0:F1}h | ", log.TotalMonthlyNeeds.TotalHours) +
                    string.Format("{0:F1}h | ", log.TotalMonthlyCurrent.TotalHours) +
                    string.Format("{0:F1}h", log.TotalMonthlyOvertime.TotalHours);
                }).ToArray());

                reloadButton.Enabled = true;

                ShowNotify("残業時間の情報を取得しました。", ToolTipIcon.Info);
            }
            catch (AttendanceProLoginException e)
            {
                var message = e.Message ?? Properties.Resources.LoginFailed;
                ShowNotify(message, ToolTipIcon.Error);
            }
            catch (AttendanceProPasswordExpiredException)
            {
                ShowNotify(Properties.Resources.PasswordHasExpired, ToolTipIcon.Error);
            }
            catch (AttendanceProFetchTableFullTimeException)
            {
                ShowNotify(Properties.Resources.FailedToFetchWorkingTable, ToolTipIcon.Error);
            }
            catch (Exception e)
            {
                ShowNotify(Properties.Resources.AnUnknownErrorOccurred + " : " + e.ToString(), ToolTipIcon.Error);
            }
        }

        void ShowNotify(string tipText, ToolTipIcon tipIcon, int timeout = 3000)
        {
            (ParentForm as PreferenceForm).ShowNotify(tipText, tipIcon);
        }

        void reloadButton_Click(object sender, EventArgs e)
        {
            UpdateSubordinateLog();
        }
    }
}

using System;
using System.Windows.Forms;
using AttendanceProClient.Account;
using AttendanceProClient.Client;
using AttendanceProClient.Client.Exceptions;

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
            reloadButton.Enabled = false;
            subordinatesDataGridView.Rows.Clear();

            try
            {
                var account = AccountManager.Instance.Account;
                var workingLogs = await AttendanceProClient.Instance.FetchSubordinateWorkingLogs(account);

                while (workingLogs.MoveNext())
                {
                    // 名前, 所定労働時間, 勤務時間, 不就労, 累計残業時間, 未入力日数
                    var log = await workingLogs.Current;
                    subordinatesDataGridView.Rows.Add(new string[] {
                        log.PersonName,
                        string.Format("{0:F1}h", log.TotalMonthlyNeeds.TotalHours),
                        string.Format("{0:F1}h", log.TotalMonthlyCurrent.TotalHours),
                        string.Format("{0:F1}h", log.TotalMonthlyRemains.TotalHours),
                        string.Format("{0:F1}h", log.TotalMonthlyOvertime.TotalHours),
                        log.EmptyFormsCount.ToString()
                    });
                }

                notifyIcon.ShowBalloonTip(Properties.Resources.GotOvertimeHours, ToolTipIcon.Info);
            }
            catch (AttendanceProLoginException e)
            {
                var message = e.Message ?? Properties.Resources.LoginFailed;
                notifyIcon.ShowBalloonTip(message, ToolTipIcon.Error);
            }
            catch (AttendanceProPasswordExpiredException)
            {
                notifyIcon.ShowBalloonTip(Properties.Resources.PasswordHasExpired, ToolTipIcon.Error);
            }
            catch (AttendanceProFetchApprovalMonthlyException)
            {
                notifyIcon.ShowBalloonTip(Properties.Resources.FailedToFetchSubordinateWorkHour, ToolTipIcon.Error);
            }
            catch (Exception e)
            {
                notifyIcon.ShowBalloonTip(Properties.Resources.AnUnknownErrorOccurred + " : " + e.ToString(), ToolTipIcon.Error);
            }

            // 更新ボタンを戻す
            reloadButton.Enabled = true;
        }

        //
        // UI
        //

        void reloadButton_Click(object sender, EventArgs e)
        {
            UpdateSubordinateLog();
        }
    }
}
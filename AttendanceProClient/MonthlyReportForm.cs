﻿using System;
using System.Collections.Generic;
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

                while (workingLogs.MoveNext())
                {
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

                /*
                 * 名前
所定労働時間
勤務時間
不就労
累計残業時間
未入力数
*/
                //workingLogsTextBox.Text = "名前 | 所定労働時間 | 勤務時間 | 不就労 | 累計残業時間 | 未入力日数" + Environment.NewLine + "==============================" + Environment.NewLine;
                //workingLogsTextBox.Text += string.Join(Environment.NewLine, workingLogs.Select(log =>
                //{
                //    return log.PersonName + " | " +
                //    string.Format("{0:F1}h | ", log.TotalMonthlyNeeds.TotalHours) +
                //    string.Format("{0:F1}h | ", log.TotalMonthlyCurrent.TotalHours) +
                //    string.Format("{0:F1}h", log.TotalMonthlyOvertime.TotalHours);
                //}).ToArray());

                reloadButton.Enabled = true;

                notifyIcon.ShowBalloonTip("残業時間の情報を取得しました。", ToolTipIcon.Info);
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
            catch (AttendanceProFetchTableFullTimeException)
            {
                notifyIcon.ShowBalloonTip(Properties.Resources.FailedToFetchWorkingTable, ToolTipIcon.Error);
            }
            catch (Exception e)
            {
                notifyIcon.ShowBalloonTip(Properties.Resources.AnUnknownErrorOccurred + " : " + e.ToString(), ToolTipIcon.Error);
            }
        }

        void reloadButton_Click(object sender, EventArgs e)
        {
            UpdateSubordinateLog();
        }
    }
}

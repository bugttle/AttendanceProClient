using ArmyKnifeDotNet.Diagnostics;
using ArmyKnifeDotNet.IO.File;
using ArmyKnifeDotNet.IO.GlobalHook;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceProClient.Account;
using AttendanceProClient.Client;

namespace AttendanceProClient
{
    public partial class PreferenceForm : Form
    {
        bool mIsShownDialog = false;

        public PreferenceForm()
        {
            InitializeComponent();
        }

        public async void Init()
        {
            try
            {
                AccountManager.Instance.Load();
            }
            catch (Exception e)
            {
                notifyIcon.ShowBalloonTip(Properties.Resources.FailedToLoadYourAccount + " : " + e.ToString(), ToolTipIcon.Error);
            }

            // アカウント情報に基づいてUIの更新
            UpdateUI();

            if (!AccountManager.Instance.IsValidAccount())
            {
                // アカウント情報が正しくなければフォームを表示する
                Show();
                Activate();
            }
            else
            {
                // ログインチェック
                await CheckLogOn();
                HookMouse(true);
            }
        }

        private void PreferenceForm_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Versions.GetApplicationVersion();
        }

        //
        // UIの更新
        //

        void UpdateUI()
        {
            UpdateAccountTextBoxies();
            UpdateAttendnceButtons();
            UpdateStartupCheckbox();
        }

        // アカウント情報の反映
        void UpdateAccountTextBoxies()
        {
            var account = AccountManager.Instance.Account;
            userIdTextBox.Text = account.UserId;
            passwordTextBox.Text = account.Password;
            companyCodeTextBox.Text = account.CompanyCode;
        }

        // 出退勤のボタンの有効/無効化
        void UpdateAttendnceButtons()
        {
            var enabled = AccountManager.Instance.IsValidAccount();
            toolStripMenuItemIn.Enabled = enabled;
            toolStripMenuItemOut.Enabled = enabled;
        }

        void UpdateStartupCheckbox()
        {
            startupCheckBox.Checked = StartupLink.Exists();
        }

        //
        // 勤怠処理の実行
        //

        // ログインチェック
        async Task CheckLogOn()
        {
            try
            {
                await AttendanceProClient.Instance.ChceckLogOn(AccountManager.Instance.Account);
                notifyIcon.ShowBalloonTip(Properties.Resources.LoginSucceeded, ToolTipIcon.Info);

                var isManager = await AttendanceProClient.Instance.IsManagerAccount();
                toolStripMenuItemShowSubordinateLogs.Visible = isManager;
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
            catch (Exception e)
            {
                notifyIcon.ShowBalloonTip(Properties.Resources.AnUnknownErrorOccurred + " : " + e.ToString(), ToolTipIcon.Error);
            }
        }

        // 勤務時間の表示
        void ShowWorkingLog(WorkingLogOwn workingLog, bool ignoreTodaysEmptyForm)
        {
            // 出勤履歴の情報
            var message = string.Format(Properties.Resources.TotalOverTimeWork, workingLog.TotalMonthlyOvertime.Hours, workingLog.TotalMonthlyOvertime.Minutes);
            var messageIcon = ToolTipIcon.Info;
            if (workingLog.HasEmptyForm(ignoreTodaysEmptyForm))
            {
                // 未入力な日があればアイコンを変えてメッセージの追加
                messageIcon = ToolTipIcon.Warning;
                message += Environment.NewLine + Properties.Resources.YouHaveNoInputDay;
            }
            if (workingLog.IsTodayLastWorkday && workingLog.IsMonthlyCommitButtonEnabled)
            {
                // 月の最終出社日かつ、月次確定がまだであれば、アイコンを変えてメッセージの追加
                messageIcon = ToolTipIcon.Warning;
                message += Environment.NewLine + Environment.NewLine + Properties.Resources.YouShouldSendMonthlyCommit;
            }

            // 勤務時間の表示
            notifyIcon.ShowBalloonTip(message, messageIcon);
        }

        // 勤務時間を取得
        async Task FetchWorkingLog()
        {
            try
            {
                var workingLog = await AttendanceProClient.Instance.FetchOwnWorkingLog(AccountManager.Instance.Account);
                ShowWorkingLog(workingLog, ignoreTodaysEmptyForm: false);
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

        // 出退勤実行
        async Task Attend(AttendanceTypes type)
        {
            try
            {
                var workingLog = await AttendanceProClient.Instance.Attend(AccountManager.Instance.Account, type);

                // 出勤退勤の完了メッセージ(短めの時間表示させる)
                int showingTime = 1000;
                notifyIcon.ShowBalloonTip(string.Format(Properties.Resources.AttendanceSucceeded, type.ToName()), ToolTipIcon.Info, timeout: showingTime);

                // 少しのディレイを挿んで通知メッセージの表示
                await Task.Delay(showingTime);
                ShowWorkingLog(workingLog, ignoreTodaysEmptyForm: (type == AttendanceTypes.Arrival));
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
            catch (AttendanceProAlreadyAttendException e)
            {
                notifyIcon.ShowBalloonTip(string.Format(Properties.Resources.AttendAlready, e.AttendanceType.ToName()), ToolTipIcon.Warning);
            }
            catch (AttendanceProAttendException e)
            {
                notifyIcon.ShowBalloonTip(string.Format(Properties.Resources.AttendanceFailed, e.AttendanceType.ToName()), ToolTipIcon.Error);
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

        // 自動出勤のチェック
        async void CheckAutoAttendance()
        {
            var timeKeeper = TimeKeeper.TimeKeeper.Instance;
            if (!mIsShownDialog && timeKeeper.UpdateTime())
            {
                // 出退勤ダイアログの表示
                var attendanceType = AttendanceTypes.Arrival;
                mIsShownDialog = true;
                var result = MessageBox.Show(
                    string.Format(Properties.Resources.DoYouWantToArrival, attendanceType.ToName()),
                    Application.ProductName,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                switch (result)
                {
                    case DialogResult.Yes:
                        await Attend(attendanceType);
                        break;

                    case DialogResult.No:
                        break;
                }
                mIsShownDialog = false;
                // この日の出退勤処理は終了
                timeKeeper.IsFinished = true;
            }
        }

        //
        // Formのイベント
        //

        void PreferenceForm_Shown(object sender, EventArgs e)
        {
            // マウスフックの停止
            HookMouse(false);
        }

        void PreferenceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notifyIcon.Visible)
            {
                e.Cancel = true;
                Hide(); // 閉じるのではなく、隠す

                try
                {
                    AccountManager.Instance.Save(); // アカウント情報の保存
                }
                catch (Exception err)
                {
                    notifyIcon.ShowBalloonTip(Properties.Resources.FailedToSaveYourAccount + " : " + err.ToString(), ToolTipIcon.Error);
                }

                // マウスフックの処理変更
                HookMouse(AccountManager.Instance.IsValidAccount());
            }
        }

        // ユーザIDの更新
        void userIdTextBox_TextChanged(object sender, EventArgs e)
        {
            var userId = ((TextBox)sender).Text;
            AccountManager.Instance.SetUserId(userId);
            UpdateAttendnceButtons();
        }

        // パスワードの更新
        void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            var password = ((TextBox)sender).Text;
            AccountManager.Instance.SetPassword(password);
            UpdateAttendnceButtons();
        }

        // スタートアップチェックの変更
        void startupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (startupCheckBox.Checked)
                {
                    StartupLink.Create();
                }
                else
                {
                    StartupLink.Remove();
                }
            }
        }

        async void loginCheckButton_Click(object sender, EventArgs e)
        {
            loginCheckButton.Enabled = false;
            await CheckLogOn();
            loginCheckButton.Enabled = true;
        }

        //
        // NotifyIcon関連
        //

        // タスクトレイのアイコンをダブルクリックでフォーム表示
        void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            Activate();
        }

        // 出社
        async void toolStripMenuItemIn_Click(object sender, EventArgs e)
        {
            await Attend(AttendanceTypes.Arrival);
        }

        // 退社
        async void toolStripMenuItemOut_Click(object sender, EventArgs e)
        {
            await Attend(AttendanceTypes.Depart);
        }

        // 自分の勤務時間を表示
        async void toolStripMenuItemShowWorkingLog_Click(object sender, EventArgs e)
        {
            await FetchWorkingLog();
        }

        // 部下の勤務時間を表示
        void toolStripMenuItemShowSubordinateLogs_Click(object sender, EventArgs e)
        {
            new MonthlyReportForm().Show();
        }

        // ブラウザで開く
        void toolStripMenuItemOpenBrowser_Click(object sender, EventArgs e)
        {
            Process.Start(AttendanceProURLs.Top);
        }

        // 設定
        void toolStripMenuItemPreference_Click(object sender, EventArgs e)
        {
            Show();
            Activate();
        }

        // アプリケーションの終了
        void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Dispose(true);
            Application.Exit();
        }

        //
        // マウスのフック
        //

        void HookFunc(ref MouseHook.StateMouse s)
        {
            // 出勤するかどうかのチェック
            CheckAutoAttendance();
        }

        void HookMouse(bool enabled)
        {
            if (enabled)
            {
                MouseHook.AddEvent(HookFunc);
                MouseHook.Start();
            }
            else
            {
                MouseHook.RemoveEvent(HookFunc);
                MouseHook.Stop();
            }
        }
    }
}
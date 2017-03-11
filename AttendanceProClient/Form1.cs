using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceProClient.Account;
using AttendanceProClient.Client;
using AttendanceProClient.GlobalHook;
using AttendanceProClient.Utilities;

namespace AttendanceProClient
{
    public partial class Form1 : Form
    {
        AccountManager mAccountManager = new AccountManager();
        AttendanceProClient mClient = new AttendanceProClient();
        bool mIsShownDialog = false;

        public Form1()
        {
            InitializeComponent();

            try
            {
                mAccountManager.Load();
            }
            catch (Exception e)
            {
                ShowNotify(Properties.Resources.FailedToLoadYourAccount + " : " + e.ToString(), ToolTipIcon.Error);
            }

            // アカウント情報に基づいてUIの更新
            UpdateUI();

            if (!mAccountManager.IsValidAccount())
            {
                // アカウント情報が正しくなければフォームを表示する
                Show();
                Activate();
            }
            else
            {
                HookMouse(true);
            }
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
            var account = mAccountManager.Account;
            userIdTextBox.Text = account.UserId;
            passwordTextBox.Text = account.Password;
            companyCodeTextBox.Text = account.CompanyCode;
        }

        // 出退勤のボタンの有効/無効化
        void UpdateAttendnceButtons()
        {
            var enabled = mAccountManager.IsValidAccount();
            toolStripMenuItemIn.Enabled = enabled;
            toolStripMenuItemOut.Enabled = enabled;
        }

        void UpdateStartupCheckbox()
        {
            startupCheckBox.Checked = StartupLinkUtility.Exists();
        }

        //
        // 勤怠処理の実行
        //

        async Task CheckLogOn()
        {
            try
            {
                await mClient.ChceckLogOn(mAccountManager.Account);
                ShowNotify(Properties.Resources.LoginSucceeded, ToolTipIcon.Info);
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
            catch (Exception e)
            {
                ShowNotify(Properties.Resources.AnUnknownErrorOccurred + " : " + e.ToString(), ToolTipIcon.Error);
            }
        }

        async Task Attend(AttendanceTypes type)
        {
            try
            {
                await mClient.Attend(mAccountManager.Account, type);
                ShowNotify(string.Format(Properties.Resources.AttendanceSucceeded, type.ToName()), ToolTipIcon.Info);
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
            catch (AttendanceProAlreadyAttendException e)
            {
                ShowNotify(string.Format(Properties.Resources.AttendAlready, e.AttendanceType.ToName()), ToolTipIcon.Warning);
            }
            catch (AttendanceProAttendException e)
            {
                ShowNotify(string.Format(Properties.Resources.AttendanceFailed, e.AttendanceType.ToName()), ToolTipIcon.Error);
            }
            catch (Exception e)
            {
                ShowNotify(Properties.Resources.AnUnknownErrorOccurred + " : " + e.ToString(), ToolTipIcon.Error);
            }
        }

        async void CheckAutoAttendance()
        {
            var timeKeeper = TimeKeeper.TimeKeeper.Instance;
            if (!mIsShownDialog && timeKeeper.UpdateTime())
            {
                // 出退勤ダイアログの表示
                var attendanceType = AttendanceTypes.Arrival;
                mIsShownDialog = true;
                var result = MessageBox.Show(string.Format(Properties.Resources.DoYouWantToArrival, attendanceType.ToName()),
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

        void Form1_Shown(object sender, EventArgs e)
        {
            // マウスフックの停止
            HookMouse(false);
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notifyIcon.Visible)
            {
                e.Cancel = true;
                Hide(); // 閉じるのではなく、隠す

                try
                {
                    mAccountManager.Save(); // アカウント情報の保存
                }
                catch (Exception err)
                {
                    ShowNotify(Properties.Resources.FailedToSaveYourAccount + " : " + err.ToString(), ToolTipIcon.Error);
                }

                // マウスフックの処理変更
                HookMouse(mAccountManager.IsValidAccount());
            }
        }

        // ユーザIDの更新
        void userIdTextBox_TextChanged(object sender, EventArgs e)
        {
            mAccountManager.Account.UserId = ((TextBox)sender).Text;
            UpdateAttendnceButtons();
        }

        // パスワードの更新
        void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            mAccountManager.Account.Password = ((TextBox)sender).Text;
            UpdateAttendnceButtons();
        }

        // スタートアップチェックの変更
        void startupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (startupCheckBox.Checked)
                {
                    StartupLinkUtility.AddStartup();
                }
                else
                {
                    StartupLinkUtility.RemoveStartup();
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

        // ブラウザで開く
        void toolStripMenuItemOpenBrowser_Click(object sender, EventArgs e)
        {
            Process.Start(AttendanceProUrls.TopURL);
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

        // 通知メッセージの表示
        void ShowNotify(string tipText, ToolTipIcon tipIcon)
        {
            int timeout = 3000;
            string tipTitle = "";
            switch (tipIcon)
            {
                case ToolTipIcon.None:
                case ToolTipIcon.Info:
                    break;

                case ToolTipIcon.Warning:
                    tipTitle = Properties.Resources.Information;
                    break;

                case ToolTipIcon.Error:
                    timeout = 5000; // エラーのときは長めに
                    tipTitle = Properties.Resources.Error;
                    break;
            }
            notifyIcon.ShowBalloonTip(timeout, tipTitle, tipText, tipIcon);
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

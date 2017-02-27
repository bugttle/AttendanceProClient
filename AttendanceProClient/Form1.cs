using System;
using System.Diagnostics;
using System.Windows.Forms;
using AttendanceProClient.Client;
using AttendanceProClient.Preference;
using AttendanceProClient.Utilities;

namespace AttendanceProClient
{
    public partial class Form1 : Form
    {
        AccountManager mAccountManager = new AccountManager();
        AttendanceProClient mClient = new AttendanceProClient();

        public Form1()
        {
            InitializeComponent();

            try
            {
                mAccountManager.Load();
            }
            catch (Exception e)
            {
                ShowNotify("アカウント情報の読み込みに失敗しました。: " + e.ToString(), ToolTipIcon.Error);
            }

            // アカウント情報に基づいてUIの更新
            UpdateUI();

            if (!mAccountManager.IsValidAccount())
            {
                // アカウント情報が正しくなければフォームを表示する
                Show();
                Activate();
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

        void Attend(AttendanceTypes type)
        {
            try
            {
                mClient.Attend(mAccountManager.Account, type);
                ShowNotify("「" + type.ToName() + "」が完了しました。", ToolTipIcon.Info);
            }
            catch (AttendanceProLoginException e)
            {
                var message = e.Message ?? "ログインに失敗しました。";
                ShowNotify(message, ToolTipIcon.Error);
            }
            catch (AttendanceProPasswordExpiredException)
            {
                ShowNotify("パスワードの期限が切れています。更新してください。", ToolTipIcon.Error);
            }
            catch (AttendanceProAttendException)
            {
                ShowNotify("「" + type.ToName() + "」 に失敗しました。", ToolTipIcon.Error);
            }
            catch (Exception e)
            {
                ShowNotify("原因不明のエラーです。: " + e.ToString(), ToolTipIcon.Error);
            }
        }

        //
        // Formのイベント
        //

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
                    ShowNotify("アカウント情報の保存に失敗しました。: " + err.ToString(), ToolTipIcon.Error);
                }
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
        void toolStripMenuItemIn_Click(object sender, EventArgs e)
        {
            Attend(AttendanceTypes.In);
        }

        // 退社
        void toolStripMenuItemOut_Click(object sender, EventArgs e)
        {
            Attend(AttendanceTypes.Out);
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
                case ToolTipIcon.Error:
                    timeout = 5000; // エラーのときは長めに
                    tipTitle = "エラー";
                    break;
            }
            notifyIcon.ShowBalloonTip(timeout, tipTitle, tipText, tipIcon);
        }
    }
}
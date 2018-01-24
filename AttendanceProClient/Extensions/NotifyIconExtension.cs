using System.Windows.Forms;

namespace AttendanceProClient
{
    public static class NotifyIconExtension
    {
        // 通知メッセージの表示
        public static void ShowBalloonTip(this NotifyIcon notifyIcon, string tipText, ToolTipIcon tipIcon, int timeout = 3000)
        {
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
    }
}

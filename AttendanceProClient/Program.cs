using DotNetCommonLibrary.Threading;
using System;
using System.Windows.Forms;

namespace AttendanceProClient
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
#if false
            // テスト用に英語モードにする
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en", false);
#endif

            // Mutexを利用して、二重起動を防止
            using (var mutex = new MutexLock(Application.ProductName))
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    // 起動時にFormを表示したくないので、Runメソッドに渡さない
                    var form = new PreferenceForm();
                    form.Init();

                    Application.Run();
                }
                catch (Exception)
                {
                    MessageBox.Show(Properties.Resources.ItHasAlreadyLaunched);
                }
            }
        }
    }
}

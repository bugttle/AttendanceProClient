using System;
using System.Threading;
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
            // Mutexを利用して、二重起動を防止
            bool createdNew;
            var mutex = new Mutex(true, Application.ProductName, out createdNew);
            if (!createdNew)
            {
                MessageBox.Show("既に起動しています。");
                mutex.Close();
                return;
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // 起動時にFormを表示したくないので、Runメソッドに渡さない
                new Form1();
                Application.Run();
            }
            finally
            {
                mutex.ReleaseMutex();
                mutex.Close();
            }
        }
    }
}
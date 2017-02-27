using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Windows.Forms;

namespace AttendanceProClient.Utilities
{
    /// <summary>
    /// 参照: http://dobon.net/vb/dotnet/file/createshortcut.html
    /// </summary>
    public static class StartupLinkUtility
    {
        static string GetShotcutLinkPath()
        {
            var startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            var linkName = Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".lnk";
            return Path.Combine(startupFolder, linkName);
        }

        /// <summary>
        /// スタートアップへショートカットの作成
        /// </summary>
        public static void AddStartup()
        {
            // WshShellでショートカットを作成する
            var shell = new WshShell();
            var shortcut = (IWshShortcut)shell.CreateShortcut(GetShotcutLinkPath());
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.WindowStyle = 1;
            shortcut.IconLocation = Application.ExecutablePath + ",0";

            shortcut.Save();

            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shortcut);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shell);
        }

        /// <summary>
        /// スタートアップからショートカットの削除
        /// </summary>
        public static void RemoveStartup()
        {
            var linkPath = GetShotcutLinkPath();
            if (System.IO.File.Exists(linkPath))
            {
                System.IO.File.Delete(linkPath);
            }
        }

        /// <summary>
        /// スタートアップにショートカットがあるかのチェック
        /// </summary>
        /// <returns></returns>
        public static bool Exists()
        {
            var linkPath = GetShotcutLinkPath();
            return System.IO.File.Exists(linkPath);
        }
    }
}
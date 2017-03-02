using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AttendanceProClient.Account
{
    public class AccountEncryptionSerializer
    {
        const string PersistentFileName = "masterdata";

        string GetPersistentFilePath()
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(folderPath, Application.ProductName, PersistentFileName);
        }

        // 指定されたパスにバイナリ形式で保存
        byte[] LoadFile(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        // 指定されたパスからバイナリ形式で読み込み
        void SaveFile(string filePath, byte[] data)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                fs.Write(data, 0, data.Length);
                fs.Flush();
            }
        }

        // バイナリをアカウント情報に戻す
        Account Unprotect(byte[] data)
        {
            var unprotectedData = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            using (var ms = new MemoryStream(unprotectedData))
            {
                var bf = new BinaryFormatter();
                return (Account)bf.Deserialize(ms);
            }
        }

        // アカウント情報をバイナリにする
        byte[] Protect(Account account)
        {
            byte[] buffer = null;
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, account);
                buffer = ms.ToArray();
            }
            return ProtectedData.Protect(buffer, null, DataProtectionScope.CurrentUser);
        }

        /// <summary>
        /// アカウント情報をファイルから復元する
        /// </summary>
        /// <returns></returns>
        public Account DeserializeFromFile()
        {
            try
            {
                var filePath = GetPersistentFilePath();
                if (File.Exists(filePath))
                {
                    var buffer = LoadFile(filePath);
                    if (buffer != null)
                    {
                        return Unprotect(buffer);
                    }
                }
                return null;
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                return null;
            }
        }

        /// <summary>
        /// アカウント情報をファイルに書き込む
        /// </summary>
        /// <param name="account"></param>
        public void SerializeToFile(Account account)
        {
            try
            {
                var filePath = GetPersistentFilePath();
                var directory = Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                if (directory != null)
                {
                    var encryptedData = Protect(account);
                    SaveFile(filePath, encryptedData);
                }
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
            }
        }
    }
}

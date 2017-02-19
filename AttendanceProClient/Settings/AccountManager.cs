namespace AttendanceProClient.Settings
{
    public class AccountManager
    {
        public Account Account { get; private set; }

        /// <summary>
        /// アカウント情報の読み出し
        /// </summary>
        /// <returns></returns>
        public Account Load()
        {
            var serializer = new AccountEncryptionSerializer();
            Account = serializer.DeserializeFromFile();
            if (Account == null)
            {
                Account = new Account();
            }
            return Account;
        }

        /// <summary>
        /// アカウント情報の保存
        /// </summary>
        public void Save()
        {
            var serializer = new AccountEncryptionSerializer();
            serializer.SerializeToFile(Account);
        }

        /// <summary>
        /// アカウント情報が正しいかどうかを判定
        /// </summary>
        /// <returns></returns>
        public bool IsValidAccount()
        {
            if (Account == null)
            {
                return false;
            }
            return (0 < Account.UserId.Length && 0 < Account.Password.Length && 0 < Account.CompanyCode.Length);
        }
    }
}

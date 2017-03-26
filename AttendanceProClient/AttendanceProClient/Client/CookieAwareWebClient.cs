using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace AttendanceProClient.Client
{
    /// <summary>
    /// Cookie情報を扱えるように拡張した WebClient
    /// </summary>

    // Attributeを追加しないと、以下のようなWarningが出る
    // To add components to your class, drag them from the Toolbox and use the Properties window to set their properties
    [System.ComponentModel.DesignerCategory("Code")]
    public class CookieAwareWebClient : WebClient
    {
        CookieContainer cc = new CookieContainer();
        string lastPage;

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                var wr = (HttpWebRequest)request;
                wr.CookieContainer = cc;
                if (lastPage != null)
                {
                    wr.Referer = lastPage;
                }
            }
            lastPage = address.ToString();
            return request;
        }

        void SetHeader()
        {
            Headers.Set("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
        }

        /// <summary>
        /// GETリクエストの実行
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url, NameValueCollection query = null)
        {
            SetHeader();
            QueryString = query;
            var resData = DownloadData(url);
            return Encoding.UTF8.GetString(resData);
        }

        /// <summary>
        /// POSTリクエストの実行
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Post(string url, NameValueCollection query)
        {
            SetHeader();
            QueryString = null;
            var resData = UploadValues(url, query);
            return Encoding.UTF8.GetString(resData);
        }
    }
}

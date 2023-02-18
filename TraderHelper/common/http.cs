using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TraderHelper.common
{
    internal class http
    {
        public static string HttpResponse(string url, string encoding, Action<HttpWebRequest>requestCustomer)
        {
            try
            {
                // 获取响应流并读取数据
                using (System.IO.Stream httpStream = HttpResponseStream(url, requestCustomer))
                using (System.IO.StreamReader streamReader = new System.IO.StreamReader(httpStream, Encoding.GetEncoding(encoding)))
                {
                    // 返回响应数据
                    string response = streamReader.ReadToEnd();
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static System.IO.Stream HttpResponseStream(string url, Action<HttpWebRequest> requestCustomer)
        {
            // 创建 HttpWeb 请求并接收相应
            HttpWebRequest httpRequest = WebRequest.Create(url) as HttpWebRequest;
            requestCustomer(httpRequest);
            try
            {
                HttpWebResponse httpResponse = httpRequest.GetResponse() as HttpWebResponse;

                // 返回响应流
                return httpResponse.GetResponseStream();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

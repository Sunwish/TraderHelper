using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace TraderHelper
{
    class Helper
    {
        public static string HttpResponse(string url, string encoding)
        {
            // 获取响应流并读取数据
            using (System.IO.Stream httpStream = HttpResponseStream(url))
            using (System.IO.StreamReader streamReader = new System.IO.StreamReader(httpStream, Encoding.GetEncoding(encoding)))
            {
                // 返回响应数据
                return streamReader.ReadToEnd();
            }
        }
        
        public static System.IO.Stream HttpResponseStream(string url)
        {
            // 创建 HttpWeb 请求并接收相应
            HttpWebRequest httpRequst = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse httpResponse = httpRequst.GetResponse() as HttpWebResponse;
            
            // 返回响应流
            return httpResponse.GetResponseStream();
                            
        }
        
        public static System.Drawing.Image HttpRequestImage(string url)
        {
            // 获取响应流
            using (System.IO.Stream httpStream = HttpResponseStream(url))
            {
                // 返回图像数据
                try
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(httpStream);
                    return image;
                }
                catch (System.ArgumentException exp)
                {
                    throw exp;
                }
            }
        }


        public static string Regexer(string regex, string source)
        {
            Regex reg = new Regex(regex);
            Match match = reg.Match(source);
            return match.ToString();
        }

        public static Match Regexer_Ex(string regex, string source)
        {
            Regex reg = new Regex(regex);
            return reg.Match(source);
        }
    }
}

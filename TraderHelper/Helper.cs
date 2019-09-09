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
            HttpWebRequest httpRequst = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse httpResponse = httpRequst.GetResponse() as HttpWebResponse;

            System.IO.Stream httpStream = httpResponse.GetResponseStream();
            System.IO.StreamReader streamReader = new System.IO.StreamReader(httpStream, Encoding.GetEncoding(encoding));

            return streamReader.ReadToEnd();
        }

        public static string Regexer(string regex, string source)
        {
            Regex reg = new Regex(regex);
            Match match = reg.Match(source);
            return match.ToString();
        }
    }
}

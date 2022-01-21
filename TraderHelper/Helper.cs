using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

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

        public static bool isStockCodeExistList(string code, string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string line = streamReader.ReadLine();
                while(line!=null)
                {
                    if (line == code)
                        return true;
                    line = streamReader.ReadLine();
                }
            }
           return false;
        }
    }

    class _ntes_quote_callback
    {
        public string code;
        public double percent;
        public double high;
        public double askvol3;
        public double askvol2;
        public double askvol5;
        public double askvol4;
        public double price;
        public double open;
        public double bid5;
        public double bid4;
        public double bid3;
        public double bid2;
        public double bid1;
        public double low;
        public double updown;
        public string type;
        public string symbol;
        public double ask4;
        public double bidvol3;
        public double bidvol2;
        public double bidvol1;
        public string update;
        public double bidvol5;
        public double bidvol4;
        public double yestclose;
        public double askvol1;
        public double ask5;
        public double volume;
        public double ask1;
        public string name;
        public double ask3;
        public double ask2;
        public string arrow;
        public string time;
        public long turnover;

        public _ntes_quote_callback(string code, double percent, double high, double askvol3, double askvol2, double askvol5, double askvol4, double price, double open, double bid5, double bid4, double bid3, double bid2, double bid1, double low, double updown, string type, string symbol, double ask4, double bidvol3, double bidvol2, double bidvol1, string update, double bidvol5, double bidvol4, double yestclose, double askvol1, double ask5, double volume, double ask1, string name, double ask3, double ask2, string arrow, string time, long turnover)
        {
            this.code = code;
            this.percent = percent;
            this.high = high;
            this.askvol3 = askvol3;
            this.askvol2 = askvol2;
            this.askvol5 = askvol5;
            this.askvol4 = askvol4;
            this.price = price;
            this.open = open;
            this.bid5 = bid5;
            this.bid4 = bid4;
            this.bid3 = bid3;
            this.bid2 = bid2;
            this.bid1 = bid1;
            this.low = low;
            this.updown = updown;
            this.type = type;
            this.symbol = symbol;
            this.ask4 = ask4;
            this.bidvol3 = bidvol3;
            this.bidvol2 = bidvol2;
            this.bidvol1 = bidvol1;
            this.update = update;
            this.bidvol5 = bidvol5;
            this.bidvol4 = bidvol4;
            this.yestclose = yestclose;
            this.askvol1 = askvol1;
            this.ask5 = ask5;
            this.volume = volume;
            this.ask1 = ask1;
            this.name = name;
            this.ask3 = ask3;
            this.ask2 = ask2;
            this.arrow = arrow;
            this.time = time;
            this.turnover = turnover;
        }
    }
}

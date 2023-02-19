using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderHelper.common;
using TraderHelper.staging.formatter;
using TraderHelper.staging.urlbuilder;

namespace TraderHelper.staging.datasource.sina
{
    internal class EastmoneyDataSource
    {
        public static DataSourceInfo Info()
        {
            return new DataSourceInfo
            {
                fetchData = EastmoneyDataFetcher(),
                fetchImage = EastmoneyImgFetcher(),
                formatter = new EastmoneyDataFormatter(),
                dataUrlBuilder = new EastmoneyUrlBuilder("https://push2.eastmoney.com/api/qt/stock/get?fields=f43,f57,f58,f59,f86&secid="),
                imageUrlBuilder = new SinaUrlBuilder("http://image.sinajs.cn/newchart/min/n/", ".gif"),
            };
        }
        static Func<string, string> EastmoneyDataFetcher()
        {
            return (url) =>
            {
                return http.HttpResponse(url, "UTF-8", (request) =>
                {
                    request.Headers.Add(System.Net.HttpRequestHeader.AcceptEncoding, "UTF-8");
                    request.Referer = "https://quote.eastmoney.com/";
                });
            };
        }
        static Func<string, Image> EastmoneyImgFetcher()
        {
            return (url) =>
            {
                return Image.FromStream(http.HttpResponseStream(url, (req) => { }));
            };
        }
    }
}

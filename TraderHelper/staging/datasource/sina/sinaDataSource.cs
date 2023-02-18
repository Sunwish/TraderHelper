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
    internal class sinaDataSource
    {
        public static DataSourceInfo Info()
        {
            return new DataSourceInfo
            {
                fetchData = SinaDataFetcher(),
                fetchImage = SinaImgFetcher(),
                formatter = new SinaDataFormatter(),
                dataUrlBuilder = new SinaUrlBuilder("http://hq.sinajs.cn/list="),
                imageUrlBuilder = new SinaUrlBuilder("http://image.sinajs.cn/newchart/min/n/", ".gif"),
            };
        }
        static Func<string, string> SinaDataFetcher()
        {
            return (url) =>
            {
                return http.HttpResponse(url, "GB2312", (request) =>
                {
                    request.Headers.Add(System.Net.HttpRequestHeader.AcceptEncoding, "GB2312");
                    request.Referer = "http://finance.sina.com.cn/";
                });
            };
        }
        static Func<string, Image> SinaImgFetcher()
        {
            return (url) =>
            {
                return Image.FromStream(http.HttpResponseStream(url, (req) => { }));
            };
        }
    }
}

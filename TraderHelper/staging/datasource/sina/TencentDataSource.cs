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
    internal class TencentDataSource
    {
        public static DataSourceInfo Info()
        {
            return new DataSourceInfo
            {
                fetchData = TencentDataFetcher(),
                fetchImage = TencentImgFetcher(),
                formatter = new TencentDataFormatter(),
                dataUrlBuilder = new TencentUrlBuilder("https://qt.gtimg.cn/?q="),
                imageUrlBuilder = new SinaUrlBuilder("http://image.sinajs.cn/newchart/min/n/", ".gif"),
            };
        }
        static Func<string, string> TencentDataFetcher()
        {
            return (url) =>
            {
                return http.HttpResponse(url, "GB2312", (request) =>
                {
                    request.Headers.Add(System.Net.HttpRequestHeader.AcceptEncoding, "GB2312");
                    request.Referer = "https://gu.qq.com/";
                });
            };
        }
        static Func<string, Image> TencentImgFetcher()
        {
            return (url) =>
            {
                return Image.FromStream(http.HttpResponseStream(url, (req) => { }));
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderHelper.api;
using TraderHelper.common;
using TraderHelper.staging.datasource.sina;

namespace TraderHelper.staging.datasource
{
    struct DataSourceInfo
    {
        internal Func<string, string> fetchData;
        internal Func<string, Image> fetchImage;
        internal Formatter formatter;
        internal UrlBuilder dataUrlBuilder;
        internal UrlBuilder imageUrlBuilder;
    }
    internal class DataSourceImp : DataSource
    {
        Func<string, string> fetchData;
        Func<string, Image> fetchImage;
        Formatter formatter;
        UrlBuilder dataUrlBuilder;
        UrlBuilder imageUrlBuilder;
        DataSourceImp(DataSourceInfo dataSourceInfo)
        {
            fetchData = dataSourceInfo.fetchData;
            fetchImage= dataSourceInfo.fetchImage;
            formatter = dataSourceInfo.formatter;
            dataUrlBuilder = dataSourceInfo.dataUrlBuilder;
            imageUrlBuilder = dataSourceInfo.imageUrlBuilder;
        }
        public SecuritiesData GetData(string code)
        {
            try
            {
                var dataType = Common.GetDataTypeByCode(code);
                var prefixType = Common.GetPrefixTypeByCode(code);
                var url = dataUrlBuilder.Build(dataType, prefixType, code);
                var originData = fetchData(url);
                var data = formatter.Format(new FormatTask
                {
                    code = code,
                    originData = originData,
                    targetType = dataType,
                });
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Image GetImage(string code)
        {
            try
            {
                var dataType = Common.GetDataTypeByCode(code);
                var prefixType = Common.GetPrefixTypeByCode(code);
                var url = imageUrlBuilder.Build(dataType, prefixType, code);
                var image = fetchImage(url);
                return image;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSource New(Source source)
        {
            DataSourceInfo dataSourceInfo = new DataSourceInfo { };
            switch (source)
            {
                case Source.SINA:
                    dataSourceInfo = SinaDataSource.Info();
                    break;
                case Source.TENCENT:
                    dataSourceInfo = TencentDataSource.Info();
                    break;
                case Source.NETEASE:
                    break;
                default:
                    throw new Exception("未知的数据源");
            }
            return new DataSourceImp(dataSourceInfo);
        }
    }
}

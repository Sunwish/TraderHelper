using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TraderHelper.api;
using TraderHelper.common;

namespace TraderHelper.staging.formatter
{
    internal class EastmoneyDataFormatter : Formatter
    {
        Regex regex_name = new Regex("\"f58\":\".+?\"");
        Regex regex_priceWithoutDecimalPoint = new Regex("\"f43\":\\d+");
        Regex regex_decimalLength = new Regex("\"f59\":\\d+");
        Regex regex_timestamp = new Regex("\"f86\":\\d+");

        public SecuritiesData Format(FormatTask task)
        {
            // {"rc":0,"rt":4,"svr":181735163,"lt":1,"full":1,"dlmkts":"","data":{"f43":1340,"f57":"600123","f58":"兰花科创","f59":2,"f86":1676620778}}
            SecuritiesData result = null;
            switch (task.targetType)
            {
                case DataType.STOCK:
                    result = format(task.code, task.originData);
                    break;
                case DataType.FUND:
                    result = format(task.code, task.originData);
                    break;
                default:
                    throw new Exception("无效的格式化任务类型");
            }
            return result;
        }

        SecuritiesData format(string code, string originData)
        {
            string name = regex_name.Match(originData).Value.Split(':').Last<string>();
            name = name.Substring(1, name.Length - 2);

            int decimalLength = int.Parse(regex_decimalLength.Match(originData).Value.Split(':').Last<string>());
            string price = regex_priceWithoutDecimalPoint.Match(originData).Value.Split(':').Last<string>();
            price = price.Insert(price.Length - decimalLength, ".");

            long timestamp = long.Parse(regex_timestamp.Match(originData).Value.Split(':').Last<string>());
            DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            dateTime = dateTime.AddSeconds(timestamp);
            string time = 
                (dateTime.Hour < 10 ? "0" : "") + dateTime.Hour.ToString() + ":" +
                (dateTime.Minute < 10 ? "0" : "") + dateTime.Minute.ToString() + ":" +
                (dateTime.Second < 10 ? "0" : "") + dateTime.Second.ToString();
            return new StockData
            {
                dataType = DataType.STOCK,
                code = code,
                name = name,
                price = price,
                time = time,
            };
        }
    }
}

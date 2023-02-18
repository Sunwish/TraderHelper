using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TraderHelper.api;
using TraderHelper.common;

namespace TraderHelper.staging.formatter
{
    internal class SinaDataFormatter : Formatter
    {
        Regex regex = new Regex("\".+?\"");
        SecuritiesData Formatter.Format(FormatTask task)
        {
            // var hq_str_sh600123="兰花科创,13.630,13.610,13.460,13.720,13.400,13.460,13.470,15243041,206547801.000,3400,13.460,89300,13.450,67000,13.440,48600,13.430,25900,13.420,99300,13.470,58600,13.480,71200,13.490,62400,13.500,110600,13.510,2023-02-15,15:00:01,00,";
            string[] slices = regex.Match(task.originData).Value.Split(',');
            if(slices.Length <= 1)
            {
                throw new Exception("数据解析失败");
            }
            SecuritiesData result = null;
            switch (task.targetType)
            {
                case DataType.STOCK:
                    result = formatStock(task.code, slices);
                    break;
                case DataType.FUND:
                    result = formatFund(task.code, slices);
                    break;
                default:
                    throw new Exception("无效的格式化任务类型");
            }
            return result;
        }

        SecuritiesData formatStock(string code, string[] slices)
        {
            return new StockData
            {
                dataType = DataType.STOCK,
                code = code,
                name = slices[0].Substring(1),
                price = slices[3],
                time = slices[slices.Length - 3],
            };
        }

        SecuritiesData formatFund(string code, string[] slices)
        {
            return new StockData
            {
                dataType = DataType.FUND,
                code = code,
                name = slices[0].Substring(1),
                price = slices[3],
                time = slices[slices.Length - 2],
            };
        }
    }
}

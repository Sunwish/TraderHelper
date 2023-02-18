using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TraderHelper.api;
using TraderHelper.common;

namespace TraderHelper.staging.formatter
{
    internal class TencentDataFormatter : Formatter
    {
        Regex regex = new Regex("\".+?\"");

        public SecuritiesData Format(FormatTask task)
        {
            // v_sh600123="1~兰花科创~600123~13.40~13.19~13.20~177065~95758~81308~13.40~588~13.39~886~13.38~302~13.37~705~13.36~288~13.41~119~13.42~318~13.43~201~13.44~478~13.45~632~~20230217155938~0.21~1.59~13.53~13.20~13.40/177065/237476740~177065~23748~1.55~4.13~~13.53~13.20~2.50~153.08~153.08~1.01~14.51~11.87~1.11~1021~13.41~4.16~6.51~~~1.22~23747.6740~0.0000~0~ ~GP-A~0.45~-1.62~5.60~24.44~12.08~18.63~9.37~-5.30~-8.03~-3.60~1142400000~1142400000~22.60~-2.83~1142400000~~~27.50~-0.07~~CNY";
            string[] slices = regex.Match(task.originData).Value.Split('~');
            if (slices.Length <= 1)
            {
                throw new Exception("数据解析失败");
            }
            SecuritiesData result = null;
            switch (task.targetType)
            {
                case DataType.STOCK:
                case DataType.FUND:
                    result = format(task.code, slices);
                    break;
                default:
                    throw new Exception("无效的格式化任务类型");
            }
            return result;
        }

        SecuritiesData format(string code, string[] slices)
        {
            return new StockData
            {
                dataType = DataType.STOCK,
                code = code,
                name = slices[1],
                price = slices[3],
                time = slices[30].Substring(8, 2) + ":" + slices[30].Substring(10, 2) + ":" + slices[30].Substring(12, 2),
                date = slices[30].Substring(0, 4) + "/" + slices[30].Substring(4, 2) + "/" + slices[30].Substring(6, 2),
            };
        }
    }
}

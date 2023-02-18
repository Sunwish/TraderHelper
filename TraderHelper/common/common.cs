using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace TraderHelper.common
{
    struct FormatTask
    {
        public string code;
        public string originData;
        public DataType targetType;
    }

    class SecuritiesData
    {
        public DataType dataType;
        public string code;
        public string name;
        public string price;
        public string time;
    }
    class StockData : SecuritiesData { }
    class FundData : SecuritiesData { }
    enum DataType
    {
        STOCK,
        FUND,
        UNKNOW
    }
    enum PrefixType
    {
        SZ,
        SH,
        UNKNOW
    }
    enum Source
    {
        SINA,
        TENCENT,
        EASTMONEY
    }

    class Common
    {
        public static DataType GetDataTypeByCode(string code)
        {
            if (code.StartsWith("6") || code.StartsWith("0") || code.StartsWith("3") || code.StartsWith("9"))
            {
                // 以6或0开头的代码为股票
                return DataType.STOCK;
            }
            else if (code.StartsWith("1") || code.StartsWith("2") || code.StartsWith("5"))
            {
                // 以1、2、5开头的代码为基金
                return DataType.FUND;
            }
            else
            {
                // 其他代码暂不支持识别
                throw new Exception("无法识别该证券代码的类别");
            }
        }
        public static PrefixType GetPrefixTypeByCode(string code)
        {

            if (code.StartsWith("6") || code.StartsWith("5") || code.StartsWith("9"))
            {
                // 以6、5、9开头的代码属于上交所
                return PrefixType.SH;
            }
            else if (code.StartsWith("0") || code.StartsWith("1") || code.StartsWith("2") || code.StartsWith("3"))
            {
                // 以0、1、2、3开头的代码属于深交所
                return PrefixType.SZ;
            }
            else
            {
                // 其他代码暂不支持识别
                throw new Exception("无法识别该代码所属的交易所");
            }
        }
    }
}

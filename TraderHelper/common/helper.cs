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
    class helper
    {
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
}

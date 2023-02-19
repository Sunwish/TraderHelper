using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderHelper.api;
using TraderHelper.common;

namespace TraderHelper.staging.urlbuilder
{
    internal class EastmoneyUrlBuilder : UrlBuilder
    {
        private string urlBase;
        private string ext;
        public EastmoneyUrlBuilder(string urlBase, string ext = "")
        {
            this.urlBase = urlBase;
            this.ext = ext;
        }
        public string Build(DataType dataType, PrefixType prefixType, string code)
        {
            string prefix = "";
            switch (prefixType)
            {
                case PrefixType.SH:
                    prefix = "1.";
                    break;
                case PrefixType.SZ:
                    prefix = "0.";
                    break;
                default:
                    break;
            }
            return urlBase + prefix + code + ext;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderHelper.common;

namespace TraderHelper.api
{
    internal interface Formatter
    {
        SecuritiesData Format(FormatTask task);
    }
}

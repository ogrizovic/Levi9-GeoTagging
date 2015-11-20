using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string criteria, StringComparison comp)
        {
            return source.IndexOf(criteria, comp) >= 0;
        }
    }
}
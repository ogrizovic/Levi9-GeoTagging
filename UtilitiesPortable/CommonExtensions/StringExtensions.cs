using System;

namespace UtilitiesPortable.CommonExtensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string criteria, StringComparison comp)
        {
            return source.IndexOf(criteria, comp) >= 0;
        }
    }
}
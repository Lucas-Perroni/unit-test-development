using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sample.Extensions
{
   public static class DatetimeExtensions
    {
        public static string ToStringShortPtBR(this DateTime date)
        {
            return date.ToString("dd/mm/yyyy");
        }

        public static string ToStringPtBR(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy HH:mm");
        }
    }
}

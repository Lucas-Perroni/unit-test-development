using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sample.Extensions
{
    public static class StrongExtensions
    {
        public static bool IsValidMail(this string email)
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;

        }
    }
}

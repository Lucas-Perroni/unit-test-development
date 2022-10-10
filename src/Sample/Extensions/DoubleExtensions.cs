using Gst;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using VisioForge;

namespace Sample.Extensions
{
    public static class DoubleExtensions
    {
        public static bool ToStringMoneyPtBR(this string money)
        {

            var numero = decimal.Parse(money);

            
                Regex regex = new Regex(@"^R$ ?(\d{1,3}.)?\d{1,3},\d{2}$|");
                Match match = regex.Match(money);

                if (match.Success)
                    return true;
                else
                    return false;
            
          



            

            //return string.Format(new CultureInfo("pt-BR"), "{0:C}", value);
        }
    }
}

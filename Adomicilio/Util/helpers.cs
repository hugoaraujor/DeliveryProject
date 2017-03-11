using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adomicilio.Models
{
    public static class Helpers
    {
        public static string Titlecase(this string word)
        {
            return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }
        public static string Getvalue(decimal monto)
        {
            string locale = "es-VE";
            var culture = new System.Globalization.CultureInfo(locale);

            return monto.ToString("C",culture);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adomicilio.Models
{
    public class helpers
    {
        public static string Getvalue(decimal monto)
        {
            string locale = "es-VE";
            var culture = new System.Globalization.CultureInfo(locale);

            return monto.ToString("C",culture);

        }
    }
}
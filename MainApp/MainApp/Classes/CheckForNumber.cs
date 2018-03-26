using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public static class CheckForNumber
    {
        public static bool isNumeric(string strValue)
        {
            decimal n;
            bool result = decimal.TryParse(strValue, out n);
            return result;
        }

        public static string formatCurrency(string strValue)
        {
            string result =  string.Format("{0:#,#.00}", Math.Round(Convert.ToDecimal(strValue),2));
            return result;

        }

        public static string formatCurrency2(string strValue)
        {
            string result = string.Format("{0:0,0.00}", Math.Round(Convert.ToDecimal(strValue),2));
            return result;

        }

    }
}

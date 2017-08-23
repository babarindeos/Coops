using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public static class DateFunction
    {
        public static string getMonthByName(int monthInNumber)
        {
            string monthName = string.Empty;
            switch (monthInNumber)
            {
                case 1:
                    monthName = "January";
                    break;
                case 2:
                    monthName = "February";
                    break;
                case 3:
                    monthName = "March";
                    break;
                case 4:
                    monthName = "April";
                    break;
                case 5:
                    monthName = "May";
                    break;
                case 6:
                    monthName = "June";
                    break;
                case 7:
                    monthName = "July";
                    break;
                case 8:
                    monthName = "August";
                    break;
                case 9:
                    monthName = "September";
                    break;
                case 10:
                    monthName = "October";
                    break;
                case 11:
                    monthName = "November";
                    break;
                case 12:
                    monthName = "December";
                    break;
            }

            return monthName;
        }


        public static int getMonthByDate(string monthInName)
        {
            int monthInNumber = 0;
            switch (monthInName)
            {
                case "January":
                    monthInNumber = 1;
                    break;
                case "February":
                    monthInNumber = 2;
                    break;
                case "March":
                    monthInNumber = 3;
                    break;
                case "April":
                    monthInNumber = 4;
                    break;
                case "May":
                    monthInNumber = 5;
                    break;
                case "June":
                    monthInNumber = 6;
                    break;
                case "July":
                    monthInNumber = 7;
                    break;
                case "August":
                    monthInNumber = 8;
                    break;
                case "September":
                    monthInNumber = 9;
                    break;
                case "October":
                    monthInNumber = 10;
                    break;
                case "November":
                    monthInNumber = 11;
                    break;
                case "December":
                    monthInNumber = 12;
                    break;
            }

            return monthInNumber;
            
        }




    }
}

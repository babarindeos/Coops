using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public static class FieldValidator
    {

        public static bool isBlank(string fieldValue)
        {
            bool result;
            if (fieldValue == string.Empty)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        
    }
}

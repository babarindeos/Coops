using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MainApp
{
    public static class PhotoPath
    {
        private static string path;

        public static string getPath()
        {
            path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            return path;
        }
    }
}

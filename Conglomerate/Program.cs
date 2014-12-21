using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;
using Conglomerate.Classes;

namespace Conglomerate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string[,] str = new string [2,4];
            str[0, 0] = "Product";
            str[0, 1] = "Price_float@Quantity_int@ID_int@Description_varchar(50)";
            str[0, 2] = "True";
            str[0, 3] = "ID";
            str[1, 0] = "Shipment";
            str[1, 1] = "ID@Price@ShipFrom@ShipTo";
            str[1, 2] = "False";
            str[1, 3] = "ID";
            //str[2, 0] = "Ship";
            //str[2, 1] = "ShipIn_int@Date_varchar(50)";
            //str[2, 2] = "True";
            //str[2, 3] = "ShipIn";
            //str[3, 0] = "Process";
            //str[3, 1] = "Process_int@Duration_varchar(50)";
            //str[3, 2] = "True";
            //str[3, 3] = "Process";
            //str[4, 0] = "OUT";
            //str[4, 1] = "";
            //str[4, 2] = "False";
            //str[4, 3] = "";
            string[,] tabledetails=new string[1,3];
            tabledetails[0, 0] = "Ship";
            tabledetails[0, 1] = "ID_int@Price_float@ShipFrom_varchar(50)@ShipTo_varchar(50)";
            tabledetails[0, 2] = "ID";
            //tabledetails[1, 0] = "anchit";
            //tabledetails[1, 1] = "bye_int";
            //tabledetails[1, 2] = "bye";

            //Code for removing titles
            string[] CommonTitles = new string[] { "MR.", "MRS ", "MS ", "MISS ", "DR "};
            string text="Mr.Khun Ying Abu Dina Mr Mrs     Toh Major. my name is Nikhil";

            text = CapitalizeWords(text);
            
            var regex = new Regex(@"(\b" + string.Join("|", CommonTitles) + @")\b\s*",RegexOptions.IgnoreCase);
            var result = regex.Replace(text, String.Empty).Trim();

            text = result;
            RegexOptions options = RegexOptions.None;
            Regex regex1 = new Regex(@"[ ]{2,}", options);
            result = regex.Replace(text, @" ");

            //MainBackend m = new MainBackend("ABC_Anchit");
            //m.ShowDialog();

            //Cleansing cl = new Cleansing();
            //cl.shiftData();

            Application.Run(new Home());
        }
               

        public static string CapitalizeWords(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (value.Length == 0)
                return value;

            StringBuilder result = new StringBuilder(value);
            result[0] = char.ToUpper(result[0]);
            for (int i = 1; i < result.Length; ++i)
            {
                if (char.IsWhiteSpace(result[i - 1]))
                    result[i] = char.ToUpper(result[i]);
                else
                    result[i] = char.ToLower(result[i]);
            }
            return result.ToString();
        }
    }
}

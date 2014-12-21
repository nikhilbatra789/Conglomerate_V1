using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

namespace Conglomerate.Classes
{
    class Cleansing
    {
        Query q = Conglomerate.Properties.Settings.Default.q;

        string OLTPName = "OLTPName";//Conglomerate.Properties.Settings.Default.ProjName;
        string username = "ABC_Anchit";//Conglomerate.Properties.Settings.Default.Gusername;
        delegate void SetCallback(CleansingDisplay l, int change,string tablename);
        //string[] key = new string[] {"BPIT","IIT","MAIT" };
        //string[] value= new string[] { "Bhagwan Parshuram Institute Of technology", "indian institute of technology", "Maharaja Agrasen Institute of Technology" };
        Dictionary<string, string> d = new Dictionary<string, string>();



        public void shiftData()
        {            
            
            string[] prefix = username.Split('_');
            string tablename = prefix[0] + "_" + OLTPName + "Setting";
            string[] settings=q.getOLTPSetting(tablename);
            DataTable dt;
            string[] CommonTitles = settings[3].Split('@');
            string tablenames=q.getOLTPTables(OLTPName);
            if (tablenames == null)
                return;
            string[] tables = tablenames.Split('@');
            string[] companyPrefix=username.Split('_');
            string[] keyvalues=settings[5].Split('@');

            
            if (settings[6] == "0")
                return;

            //for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            //{
            //    if (Application.OpenForms[index].Name == "MainBackend")
            //    {
            //        MainBackend m = (MainBackend)Application.OpenForms[index];
            //        m.WindowState = FormWindowState.Minimized;
            //    }
            //}
            CleansingDisplay cld = new CleansingDisplay();
            Thread t = new Thread(() => loadCleansingDisplay(cld));
            t.Start();
            for (int i = 0; i < keyvalues.Length; i++)
            {
                string[] temp = keyvalues[i].Split(',');
                if (temp[0] != null && temp[1] != null)
                    d.Add(temp[0], temp[1]);
            }

            for(int k=0;k<tables.Length;k++)
            {

                ////////////////////////////////////////////////////////////////
                ////////////                Extract            /////////////////
                ////////////////////////////////////////////////////////////////
                load(cld, 2, companyPrefix[0] + "_" + OLTPName + "_" + tables[k]);
                dt = q.pulldata(companyPrefix[0] + "_" + OLTPName + "_" + tables[k]);
                ////////////////////////////////////////////////////////////////
                ////////////                Transform          /////////////////
                ////////////////////////////////////////////////////////////////
                load(cld, 3, companyPrefix[0] + "_" + OLTPName + "_" + tables[k]);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string s = dt.Rows[i].ItemArray[j].ToString();

                        if (s != null)
                        {
                            s = Abrreviations(s);
                            if (settings[2] == "1")
                            {
                                s = RemoveTitles(s, CommonTitles);
                            }

                            if (settings[0] == "1")
                            {
                                s = camelcase(s);
                            }

                            if (settings[1] == "1")
                            {
                                s = MultipleSpaces(s);
                            }                           

                            dt.Rows[i][j] = s;
                        }
                    }
                }
                ////////////////////////////////////////////////////////////////
                ////////////                Load               /////////////////
                ////////////////////////////////////////////////////////////////
                load(cld, 4, companyPrefix[0] + "_" + OLTPName + "_" + tables[k]);
                q.copyBulkDataDW(dt,companyPrefix[0]+"_"+OLTPName+"_"+ tables[k]);
            }
            load(cld, 5, companyPrefix[0] + "_" + OLTPName);

            //for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            //{
            //    Application.OpenForms[index].WindowState = FormWindowState.Maximized;
            //}
        }

        public string camelcase(string value)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            // Check if we have a string to format
            if (String.IsNullOrEmpty(value))
            {
                // Return an empty string
                return string.Empty;
            }

            // Format the string to Proper Case
            value= textInfo.ToTitleCase(value.ToLower());
            return value;
            //string result = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
            //return result;
        }

        public string Abrreviations(string text)
        {
            

            string[] textarr = text.Split(' ');
            for (int i=0;i<textarr.Length;i++)
            {
                if (d.ContainsKey(textarr[i]))
                { 
                    textarr[i]=d[textarr[i]];
                }
            }
            return String.Join(" ",textarr);
        }

        public string MultipleSpaces(string text)
        {
            
            RegexOptions options = RegexOptions.None;
            Regex regex1 = new Regex(@"[ ]{2,}", options);
            string result=regex1.Replace(text, @" ");
            return result;
        }

        public string RemoveTitles(string text, string[] CommonTitles)
        {
            var regex = new Regex(@"(\b" + string.Join("|", CommonTitles) + @")\b\s*", RegexOptions.IgnoreCase);
            var result = regex.Replace(text.ToUpper(), String.Empty).Trim();
            return result;
        }

        public void load(CleansingDisplay l, int change,string tablename)
        {
            {
                try
                {
                    l.load(change,tablename);
                }
                catch
                {
                    if (l.InvokeRequired)
                    {
                        SetCallback d = new SetCallback(load);
                        l.Invoke(d, new object[] { l, change,tablename });
                    }
                }
            }

        }

        public void loadCleansingDisplay(CleansingDisplay cld)
        {
            cld.ShowDialog();
        }
    }
}

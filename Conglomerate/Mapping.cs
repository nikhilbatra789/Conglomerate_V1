using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conglomerate.Classes;
using System.Threading;

namespace Conglomerate
{
    public partial class Mapping : Form
    {
        delegate void SetCallback(Processing l, bool flag);

        string[,] tables;
        string[,] form;
        public string[,] Map;
        ComboBox tempcmb;
        public int count = 0, fields = 0;
        public string[] formnames;
        public string[] tablenames;
        public int no_of_forms;
        public int no_of_tables;

        Query q = Conglomerate.Properties.Settings.Default.q;
        General g = new General();

        public Mapping(string[,] tempform,string[,] temptables)
        {
            InitializeComponent();

            if (temptables == null)
            {
                label2.Text = "There are no tables to be mapped. Please click finish to complete the proccess.";
                temptables = new string[,] { { "", "", "" } };

                form = tempform;
                tables = temptables;

                no_of_forms = form.Length / 4;
                no_of_tables = tables.Length / 3;

                formnames = new string[no_of_forms];
                tablenames = new string[no_of_tables + no_of_forms];
                int k = 0;
                for (k = 0; k < no_of_forms; k++)
                {
                    formnames[k] = form[k, 0];
                    if (form[k, 2] != "False")
                        tablenames[k] = form[k, 0];
                }

                for (int j = 0; j < no_of_tables; j++)
                {

                    tablenames[k++] = tables[j, 0];
                }
                List<string> lis = formnames.ToList<string>();
                lis.RemoveAll(p => string.IsNullOrEmpty(p));
                formnames = lis.ToArray();

                List<string> lis1 = tablenames.ToList<string>();
                lis1.RemoveAll(p => string.IsNullOrEmpty(p));
                tablenames = lis1.ToArray();

                return;
            }
            else
            {
                label2.Visible = false;
            }

            form = tempform;
            tables = temptables;

            no_of_forms=form.Length/4; 
            no_of_tables=tables.Length/3;
            
            formnames=new string[no_of_forms];
            tablenames = new string[no_of_tables + no_of_forms];
            int i = 0;
            for (i = 0; i < no_of_forms; i++)
            {
                formnames[i] = form[i, 0];
                if(form[i,2]!="False")
                    tablenames[i]=form[i,0];
            }
            
            for (int j = 0; j < no_of_tables; j++)
            {
                
                    tablenames[i++] = tables[j, 0];
            }
            List<string> lis2 = formnames.ToList<string>();
            lis2.RemoveAll(p => string.IsNullOrEmpty(p));
            formnames = lis2.ToArray();

            List<string> lis3 = tablenames.ToList<string>();
            lis3.RemoveAll(p => string.IsNullOrEmpty(p));
            tablenames = lis3.ToArray();


            
            
            for (int j = 0; j < no_of_tables; j++)
            {
                Label lbl = new Label();
                lbl.Location=new Point(10, 30 * (++count));
                lbl.Text = tables[j, 0];
                panel1.Controls.Add(lbl);
                string[] temparr = tables[j, 1].Split('@');
                foreach (string arr in temparr)
                {
                    
                    int x, y;
                    x = 10;
                    y= 30 * (++count);
                    //Display new table attributes
                    string[] element = arr.Split('_');
                    TextBox t = new TextBox();  
                    t.Name = "txt" + fields.ToString();
                    t.Text = element[0];
                    t.Location = new Point(x, y);
                    t.Enabled = false;
                    panel1.Controls.Add(t);  
  
                    //Display form comboboxes
                    ComboBox cmb1 = new ComboBox();
                    cmb1.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmb1.Name = "cb_form_no@" + fields.ToString();
                    cmb1.Location = new Point(x + 170, y);
                    cmb1.Items.AddRange(formnames);
                    panel1.Controls.Add(cmb1);

                    //Display form fields comboboxes
                    ComboBox cmb2 = new ComboBox();
                    cmb2.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmb2.Name = "cb_form_field@" + fields.ToString();
                    cmb2.Location = new Point(x + 320, y);
                    panel1.Controls.Add(cmb2);
                    
                    fields++;
                }                
            }


            for (int j = 0; j < fields; j++)
            {
                tempcmb = (ComboBox)panel1.Controls["cb_form_no@" + j.ToString()];
                tempcmb.SelectedIndexChanged += new System.EventHandler(ComboBox_SelectedIndexChanged);
            }
        }

        public string[] attributes(string att)
        {
            string[] temp = att.Split('@');
            string[] attr=new string[temp.Length];
            int i = 0;
            foreach (string str in temp)
            {
                string[] tempstr = str.Split('_');
                attr[i]=tempstr[0];
                i++;
            }
            return attr;
        }

        public void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string name = cmb.Name;
            string[] no = name.Split('@');
            int index = cmb.SelectedIndex;
            string[] attr=attributes(form[index,1]);
            ComboBox cmb2 = (ComboBox)panel1.Controls["cb_form_field@"+no[1]];
            cmb2.Items.Clear();
            cmb2.Items.AddRange(attr);
        }

        public void Finish_Click(object sender, EventArgs e)
        {
            string error=check();
            if (error == "")
            {
                int mapLength = 0;
                for (int i = 0; i < no_of_forms; i++)
                {
                    if (form[i, 2] != "False")
                    {
                        string[] arr = form[i, 1].Split('@');
                        mapLength += arr.Length;
                    }
                }

                mapLength += fields;
                string[,] Map=new string[mapLength,2];
                int mapcount = 0;
                for (int i = 0; i < no_of_forms; i++)
                {
                    if (form[i, 2] != "False")
                    {
                        Map[mapcount, 0] = form[i, 0];
                        Map[mapcount, 1] = form[i, 0];
                        string[] arr = form[i, 1].Split('@');
                        for (int j = 0; j < arr.Length; j++)
                        { 
                            string[] temparr=arr[j].Split('_');
                            Map[mapcount, 0] += "@" + arr[j];
                            Map[mapcount, 1] += "@" + temparr[0];
                            
                        }
                        mapcount++;
                    }
                }
                string[,] Map1=new string[mapLength,2];
                int num = 0;
                for (int i = 0; i < no_of_tables; i++)
                { 
                    string[] arr=tables[i,1].Split('@');
                    for(int j=0;j<arr.Length;j++)
                    {
                        if (arr[j] == "" || arr[j] == null)
                            continue;
                        string[] temparr=arr[j].Split('_');
                        Map1[num, 0] = tables[i, 0] + "_" + arr[j];
                        ComboBox cmb = new ComboBox();
                        cmb = (ComboBox)panel1.Controls["cb_form_no@"+i.ToString()];
                        ComboBox cmb2 = new ComboBox();
                        cmb2 = (ComboBox)panel1.Controls["cb_form_field@"+i.ToString()];
                        Map1[num++, 1] = cmb.Text + "_" + cmb2.Text;
                    }
                    

                }

                for (int i = 0; i < mapLength-1; i++)
                {
                    if (Map1[i, 0] == "" || Map1[i, 1] == "")
                        continue;
                    if (Map1[i, 0] == null || Map1[i, 1] == null)
                        break;
                    string column1 = Map1[i, 0];
                    string column2 = Map1[i, 1];
                    string[] temp = column1.Split('_');
                    Map1[i, 0] = temp[0]+"@" + temp[1] +"_"+ temp[2];
                    column1 = temp[0];
                    string[] temp2 = column2.Split('_');
                    Map1[i, 1] = temp2[0] + "@" + temp2[1];
                    column2 = temp2[0];
                    for (int j = i + 1; j < mapLength; j++)
                    {
                        if (Map1[j, 0] == null || Map1[j, 1] == null)
                            break;
                        if (Map1[j, 0] == "" || Map1[j, 1] == "")
                            continue;
                        temp = Map1[j, 0].Split('_');
                        temp2 = Map1[j, 1].Split('_');
                        if (column1 == temp[0] && column2 == temp2[0])
                        {
                            Map1[i, 0] += "@" + temp[1] + "_" + temp[2];
                            Map1[i,1]+="@"+temp2[1];
                            Map1[j, 0] = "";
                            Map1[j, 1] = "";
                        }
                    }                    
                }
                for (int i = 0; i < mapLength; i++)
                {
                    if (Map1[i, 0] == null || Map1[i, 1] == null)
                        break;
                    if (Map1[i, 0] == "" && Map1[i, 1] == "")
                        continue;
                    Map[mapcount, 0] = Map1[i, 0];
                    Map[mapcount, 1] = Map1[i, 1];
                    mapcount++;
                }
                string[,] newMap=new string[mapcount,2];
                for (int j = 0; j < mapcount; j++)
                {
                    newMap[j, 0] = Map[j, 0];
                    newMap[j, 1] = Map[j, 1];
                }
                    loading(newMap);
                    Application.Exit();
               
            }
            else 
            {
                MessageBox.Show(error);
            }
        }

        private string check()
        {
            string error="";
            for (int i = 0; i < fields; i++)
            {
                ComboBox cmb = (ComboBox)panel1.Controls["cb_form_no@" + i.ToString()];
                if (cmb.Text == "")
                {
                    error += "One or more rowns contain empty Values";
                    break;
                }
            }

            int k = 0;
            for (int i = 0; i < no_of_tables; i++)
            {
                string[] arr = tables[i, 1].Split('@');
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] == "" || arr[j] == null)
                        continue;
                    ComboBox cmb1 = (ComboBox)panel1.Controls["cb_form_no@"+k.ToString()];
                    ComboBox cmb2 = (ComboBox)panel1.Controls["cb_form_field@"+k.ToString()];

                    string[] element=arr[j].Split('_');
                    string tableVariableType = element[1];
                    string formAttrtype = getFormVariableType(cmb1.Text,cmb2.Text);
                    if (formAttrtype == "False")
                    {
                        k++;
                        continue;
                    }
                    if (ValidMap(formAttrtype, tableVariableType))
                    {
                        TextBox tb=(TextBox)panel1.Controls["txt"+k.ToString()];
                        error = tb.Text+" of type "+tableVariableType+" cannot be mapped to "+cmb1.Text+" "+cmb2.Text+" of type "+formAttrtype;
                        return error;
                    }
                    k++;
                }
            }

            return error;
        }

        public string getFormVariableType(string formname, string attribute)
        {
            for (int i = 0; i < no_of_forms; i++)
            {
                if (form[i, 0] == formname)
                {
                    if (form[i, 2] == "True")
                    {
                        string[] attr = form[i, 1].Split('@');
                        for (int j = 0; j < attr.Length; j++)
                        {
                            string[] element = attr[j].Split('_');
                            if (element[0] == attribute)
                            {
                                return element[1];
                            }
                        }
                    }
                }
            }

            return "False";
        }

        private bool ValidMap(string mapfrom,string mapto)
        {
            mapfrom = mapfrom.ToUpper();
            mapto = mapto.ToUpper();
            if (mapfrom == "VARCHAR(50)" && mapto == "INT")
            {
                return true;
            }
            if (mapfrom == "VARCHAR(50)" && mapto == "FLOAT")
            {
                return true;
            }
            if (mapfrom == "VARCHAR(50)" && mapto == "DOUBLE")
                return true;
            return false;
        }

        public bool loading(string[,] tempMap)
        {
            Processing p = new Processing();
            Thread t = new Thread(()=>loadProcessing(p,true));
            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name == "MainBackend")
                {
                    Application.OpenForms[index].WindowState = FormWindowState.Minimized;
                }
            }
            t.Start();
            string Username = Conglomerate.Properties.Settings.Default.Gusername;
            string OLTPName = Conglomerate.Properties.Settings.Default.ProjName;
            DefineOLTP df = new DefineOLTP();
            string[] prefix = Username.Split('_');
            string formdet=String.Join("@",formnames);
            string tabledet=String.Join("@",tablenames);
            DefineOLTP DefOLTP = new DefineOLTP();
            string OLTPname = DefOLTP.OLTPname;
            q.addOLTP_Details(q.getProjID(Username),df.interval.ToString(), prefix[0], OLTPName, formdet, tabledet, Username, form, tables, tempMap);
            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name == "MainBackend")
                {
                    Application.OpenForms[index].WindowState = FormWindowState.Maximized;
                }                
            }
            loadProcessing(p, false);
            return true;
        }

        public void loadProcessing(Processing l,bool flag)
        {
            if (flag == true)
            {
                l.ShowDialog();
            }
            else
            {
                try
                {
                    l.Close();
                }
                catch
                {
                    if (l.InvokeRequired)
                    {
                        SetCallback d = new SetCallback(loadProcessing);
                        this.Invoke(d, new object[] { l, false });
                    }
                }
            }
        }

        
    }
}

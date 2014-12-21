using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conglomerate.Classes;

namespace Conglomerate
{
    public partial class DynamicForm : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;

        public string Username = "", OLTPName = "",tempformname="";
        public object[] OLTPDetails;
        public string[,] formDetails;
        public string[,] tableDetails;
        public string[,] MapDetails;
        public string[,] thisMap;
        public string[,] newMap;
        public int no_of_tables = 0, no_of_forms = 0,no_of_maps=0,no_of_thisMap=0;
        public DynamicForm(string tempUsername,string tempOLTPName,object[] tempOLTPDetails,string formName)
        {
            InitializeComponent();
            Username = tempUsername;
            OLTPName = tempOLTPName;
            tempformname = formName;
            OLTPDetails = tempOLTPDetails;            
            formDetails = q.getFormDetails(OLTPDetails[3].ToString());
            tableDetails = q.getTableDetails(OLTPDetails[4].ToString());
            MapDetails = q.getMappingDetails(OLTPDetails[5].ToString());

            no_of_forms=formDetails.Length/4;
            no_of_tables=tableDetails.Length/3;
            no_of_maps=MapDetails.Length/2;

            thisMap =new string[no_of_maps,2];
            int count=0;
            for (int j = 0; j < no_of_maps;j++)
            {
                string[] temp=MapDetails[j,1].Split('@');
                if(formName==temp[0])
                {
                    thisMap[count, 0] = MapDetails[j, 0];
                    thisMap[count++, 1] = MapDetails[j, 1];
                }
            }

            newMap=new string[count,2];
            for (int j = 0; j < count; j++)
            { 
                newMap[j,0]=thisMap[j,0];
                newMap[j, 1] = thisMap[j, 1];

            }
            thisMap = newMap;
            no_of_thisMap=thisMap.Length/2;

            count=0;
            for (int j = 0; j < no_of_thisMap; j++)
            { 
                string[] temp1=newMap[j,0].Split('@');
                string[] temp2 = newMap[j, 1].Split('@');
                if (temp1[0] != temp2[0])
                {
                    string primarykey = findPrimaryKey(temp1[0]);
                    if (!findkey(newMap[j,0],primarykey))
                    {
                        ComboBox cmb = new ComboBox();
                        cmb.Name = temp1[0];
                        string[] prefix = Username.Split('_');
                        object[] obj = q.getPrimaryValues(prefix[0]+"_"+OLTPName+"_"+temp1[0],primarykey);
                        if (obj == null)
                        {
                            MessageBox.Show("Please note that no data is present in one of the dependent table. So this form cannot be loaded");
                            this.Close();
                            return;
                        }
                        foreach (object[] obj1 in obj)
                        {
                            cmb.Items.Add(obj1[0].ToString());
                        }
                        cmb.Location = new Point(300,j*30);
                        cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                        cmb.SelectedIndex = 0;
                        panel1.Controls.Add(cmb);
                    }

                }
            }

            label1.Text = formName;
            int i = 0;
            for (i = 0; i < formDetails.Length / 3; i++)
            {
                if (formDetails[i, 0] == formName)
                {
                    break;   
                }
            }
            string[] arr = formDetails[i, 1].Split('@');

            for (int j = 0; j < arr.Length; j++)
            {
                Label lbl = new Label();
                lbl.AutoSize = true;
                string[] temp = arr[j].Split('_');
                lbl.Text = temp[0];
                lbl.Location = new Point(30,30*j);
                panel1.Controls.Add(lbl);

                TextBox tb = new TextBox();
                tb.Name = "Item@" + j.ToString();
                tb.Location = new Point(100,30*j);
                panel1.Controls.Add(tb);
           }

            this.ShowDialog();

        }

        public bool findkey(string form, string key)
        {
            string[] temp = form.Split('@');
            for (int i = 0; i < temp.Length; i++)
            { 
                string[] arr=temp[i].Split('_');
                if (arr[0] == key)
                {
                    return true;
                }
            }
            return false;
        }

        public string findPrimaryKey(string tableName)
        {
            string primarykey = "";
            for (int i = 0; i < no_of_tables; i++)
            {
                if (tableDetails[i, 0] == tableName)
                {
                    primarykey = tableDetails[i, 2];
                }

            }
            return primarykey;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            int maximumQueriesCount=100;
            string[] queries=new string[maximumQueriesCount];
            int queriescount = 0;
            bool b=false;
            int i=0;
            for (i = 0; i < formDetails.Length / 3; i++)
            {
                if (formDetails[i, 0] == tempformname)
                {
                    if(formDetails[i,2]=="True")
                    {
                        b=true;
                    }
                    break;
                }
            }

            string[] arr=formDetails[i,1].Split('@');
            string DirectPrimaryKey=formDetails[i,3];

            //Code for Direct Mapping
            if(b==true)
            {
                string[] values=new string[arr.Length];
                for(int j=0;j<values.Length;j++)
                {
                    TextBox tb=(TextBox)panel1.Controls["Item@"+j.ToString()];
                    values[j]="'"+ tb.Text+"'";
                }
                string finalvalues=String.Join(",",values);
                string[] fields=new string[values.Length];
                string param="";
                for(int j=0;j<fields.Length;j++)
                {
                    string[] temp=arr[j].Split('_');
                    fields[j]=temp[0];

                }
                param=String.Join(",",fields);
                string[] prefix=Username.Split('_');
                string query="Insert into dbo."+prefix[0]+"_"+OLTPName+"_"+tempformname+"("+param+") Values ("+finalvalues+")";
                //q.executeOLTPQuery(query);
                queries[queriescount++]=query;
                
                
            }

            //Code for Indirect Mapping
            for (int j = 0; j < no_of_thisMap; j++)
            {
                string[] temp1 = newMap[j, 0].Split('@');
                string[] temp2 = newMap[j, 1].Split('@');
                if (temp1[0] != temp2[0])
                {
                    string primarykey = findPrimaryKey(temp1[0]);
                    if (!findkey(newMap[j, 0], primarykey))
                    {

                        ComboBox cmb = (ComboBox)panel1.Controls[temp1[0]];
                        string[] temparr = newMap[j, 0].Split('@');
                        string[] param = new string[temparr.Length];
                        int paranum = 0;
                        for (int k = 1; k < temparr.Length; k++)
                        {
                            string[] attr = temparr[k].Split('_');
                            param[paranum++] = attr[0];
                        }

                        temparr = newMap[j, 1].Split('@');
                        string[] value = new string[temparr.Length];
                        for (int k = 1; k < temparr.Length; k++)
                        {
                            value[k - 1] = "'" + getvalue(temparr[k], arr) + "'";
                        }

                        string[] prefix = Username.Split('_');
                        string[] subquery = new string[temparr.Length];
                        for (int k = 0; k < temparr.Length; k++)
                        {
                            if (param[k] != null)
                                subquery[k] = param[k] + "=" + value[k];
                        }

                        List<string> lis1 = subquery.ToList<string>();
                        lis1.RemoveAll(p => string.IsNullOrEmpty(p));
                        subquery = lis1.ToArray();

                        string finalsubquery = " Set " + String.Join(",", subquery);
                        string query = "Update dbo." + prefix[0] + "_" + OLTPName + "_" + temp1[0] + finalsubquery + " Where " + primarykey + "='" + cmb.Text + "'";
                        //q.executeOLTPQuery(query);
                        queries[queriescount++] = query;
                    }
                    else
                    {
                        string[] temparr = newMap[j, 0].Split('@');
                        string[] param = new string[temparr.Length];
                        int paranum = 0,primAt=0;
                        for (int k = 1; k < temparr.Length; k++)
                        {
                            string[] attr = temparr[k].Split('_');
                            if (attr[0] == primarykey)
                            {
                                primAt = k;
                            }
                            param[paranum++] = attr[0];
                        }

                        List<string> lis = param.ToList<string>();
                        lis.RemoveAll(p => string.IsNullOrEmpty(p));
                        param = lis.ToArray();

                        string finalParam = String.Join(",",param);
                        temparr = newMap[j, 1].Split('@');
                        string[] value = new string[temparr.Length];
                        

                        for (int k = 1; k < temparr.Length; k++)
                        {
                            value[k - 1] = "'" + getvalue(temparr[k], arr) + "'";
                        }

                        List<string> lis2 = value.ToList<string>();
                        lis2.RemoveAll(p => string.IsNullOrEmpty(p));
                        value = lis2.ToArray();

                        string finalValue = String.Join(",",value);
                        string primValue=value[primAt-1];

                        string[] prefix = Username.Split('_');
                        

                       
                        string tablename=prefix[0]+"_"+OLTPName+"_"+temp1[0];

                        if (q.checkForExsistRecords(tablename, primValue, primarykey))
                        {
                            if (MessageBox.Show("The Value you entered(" + primValue + ") Already Exists do want to update it.If no Please change the value and then click Submit", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                string[] subquery = new string[temparr.Length];
                                for (int k = 0; k < param.Length; k++)
                                {
                                    if (param[k] != null)
                                        subquery[k] = param[k] + "=" + value[k];
                                }

                                List<string> lis1 = subquery.ToList<string>();
                                lis1.RemoveAll(p => string.IsNullOrEmpty(p));
                                subquery = lis1.ToArray();

                                string finalsubquery = " Set " + String.Join(",", subquery);
                                string query = "Update dbo." + prefix[0] + "_" + OLTPName + "_" + temp1[0] + finalsubquery + " Where " + primarykey + "="+primValue;
                                //q.executeOLTPQuery(query);
                                queries[queriescount++] = query;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            string query = "Insert into dbo."+prefix[0]+"_"+OLTPName+"_"+temp1[0]+" ("+finalParam+") Values ("+finalValue+")";
                            queries[queriescount++] = query;
                        }
                    }

                }
            }

            string result = q.executeOLTPTransaction(queries,"OLTP");
            //foreach (string str in queries)
            //{
            //    if(str != null)
            //        q.executeOLTPQuery(str);
            //}
            if (result == "")
                MessageBox.Show("Record inserted successfully");
            else
                MessageBox.Show(result);
        }

        public string getvalue(string attr,string[] attrs)
        {
            int i=0;
            for (i = 0; i < attrs.Length; i++)
            {
                string[] value = attrs[i].Split('_');
                if (value[0] == attr)
                {
                    break;
                }
            }
            TextBox tb=(TextBox)panel1.Controls["Item@"+i.ToString()];
            return tb.Text;
        }
    }
}

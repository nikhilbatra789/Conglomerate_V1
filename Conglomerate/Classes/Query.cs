using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Conglomerate.Classes;

namespace Conglomerate.Classes
{
     public partial class Query
    {
        private GenDatabase GENdb = new GenDatabase();
        private DWDatabase DWdb = new DWDatabase();
        private OLTPDatabase OLTPdb = new OLTPDatabase();
        private General gn = new General();

        public void closeDb()
        {
            GENdb.connection.Close();
        }

        public bool createCompany(string tablename)
        {
            string query = "CREATE TABLE dbo." + tablename + " (Username varchar(50) NOT NULL,Password varchar(50) NOT NULL,Role varchar(20) NOT NULL,ProjName varchar(100),ProjID varchar(10) NOT NULL,FirstLogin bit NOT NULL,Email varchar(100) NOT NULL)";
            return GENdb.setData(query);
        }

        public bool addFirstUser(string tablename,string username, string password,string email)
        {
            string query = "Insert into dbo."+tablename+" Values('"+username+"','"+password+"','SuperUser','ALL','0','1','"+email+"')";
            return GENdb.setData(query);
        }

        public bool addComapny(string prefix, string Cname)
        {
            string query = "Insert into dbo.Company_details Values('"+prefix+"','"+Cname+"')";
            return GENdb.setData(query);
        }

        public bool ChangeInitialPassword(string tablename, string username, string password)
        {
            string query = "Update dbo."+tablename+" SET Password='"+password+"',FirstLogin='0' where Username='"+username+"'";
            return GENdb.setData(query);
        }

        public bool checkFirstLogin(string tablename,string username)
        {
            string query = "Select FirstLogin from dbo." + tablename + " where Username='" + username + "'";
            string value= GENdb.getFirstCell(query);
            if (value.ToString() == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checklogin(string username, string password,string tablename)
        {
            string query = "Select * from dbo."+tablename+" where Username='"+username+"' and Password='"+password+"'";
            object obj = GENdb.getFirstRow(query);

            if (obj != null)
                return true;
            else
                return false;
        }
        public object[] getallrequest()
        {
            string query = "Select * from dbo.Request";
           return GENdb.getData(query);    
        
        }

        public string getOLTPName(string projectID)
        {
            string query = "select OLTPName from dbo.OLTPDetails where ID='"+projectID+"'";
            return OLTPdb.getFirstCell(query);
        }

        public string[,] getTableDetails(string tablename)
        {
            string query = "Select * from dbo."+tablename;
            object[] tableDeatils = OLTPdb.getData(query);
            if (tableDeatils == null)
            {
                string[,] temp = new string[,] { { "", "" } };
                return temp;
            }
            string[,] table = new string[tableDeatils.Length, 3];
            int i=0;
            foreach(object[] obj in tableDeatils)
            {
                table[i,0]=obj[0].ToString();
                table[i,1]=obj[1].ToString();
                table[i, 2] = obj[2].ToString();
                i++;
            }
            return table;
        }

        public string[,] getMappingDetails(string tablename)
        {
            string query = "Select * from dbo." + tablename;
            object[] MappingDetails = OLTPdb.getData(query);
            if (MappingDetails == null)
            {
                string[,] temp = new string[,] { {"",""}};
                return temp;
            }
            string[,] Map = new string[MappingDetails.Length, 2];
            int i = 0;
            foreach (object[] obj in MappingDetails)
            {
                Map[i, 0] = obj[0].ToString();
                Map[i, 1] = obj[1].ToString();
                i++;
            }
            return Map;
        }

        public string[,] getFormDetails(string tablename)
        {
            string query = "Select * from dbo."+tablename;
            object[] formDetails= OLTPdb.getData(query);
            if (formDetails == null)
            {
                string[,] temp = new string[,] { { "", "" } };
                return temp;
            }
            string[,] form = new string[formDetails.Length, 4];
            int i = 0;
            foreach (object[] obj in formDetails)
            {
                form[i, 0] = obj[0].ToString();
                form[i, 1] = obj[1].ToString();
                form[i, 2] = obj[2].ToString();
                form[i, 3] = obj[3].ToString();
                i++;
            }
            return form;
        }

        public object[] getOLTPDetails(string OLTPName)
        {
            string query = "Select * from dbo.OLTPDetails where OLTPName='"+OLTPName+"'";
            return OLTPdb.getFirstRow(query);
        }

        public string getProjID(string username)
        {
            string[] arr = username.Split('_');
            string query = "select ProjID from dbo."+arr[0]+" where Username='"+username+"'";
            return GENdb.getFirstCell(query);
        }

        public bool executeOLTPQuery(string query)
        {
            return OLTPdb.setData(query);
        }

        public object[] getPrimaryValues(string tablename, string primarykey)
        {
            string query = "Select "+primarykey+" from dbo."+tablename;
            return OLTPdb.getData(query);
        }

        public string getuser(string username, string Prefix)
        {
            string query = "Select Username from dbo." + Prefix + " where Username='" + username + "'";
            return GENdb.getFirstCell(query);
        }
        
        public int getrole(string Username, string tablename)
        {
            string query = "Select Role from dbo." + tablename + " where Username='" + Username + "'";
            string role = GENdb.getFirstCell(query);
            if (role == "DBA")
                return 0;
            else if (role == "Admin")
                return 1;
            else if (role == "User")
                return 2;
            else if (role == "SuperUser") { return 3; }
            else { return 4; }

        }
        public bool deleterequest(string companyname)
        {
            string query = "Delete from dbo.Request where CompanyName='" + companyname + "'";
            return GENdb.setData(query);
        }

        public bool checkPrefix(string prefix)
        {
            string query = "select * from Company_details where Prefix='" + prefix + "'";
            object[] obj = GENdb.getData(query);
            try
            {
                int length = obj.Length;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insertSchema(string ProjectID, string TableName, string Prefix, string schema)
        {
            string query = "Insert into dbo.Struct Values('"+ProjectID+"','"+TableName+"','"+Prefix+"','"+schema+"')";
            return DWdb.setData(query);
        }

        public bool generatetables(string query)
        {
            return DWdb.setData(query);
        }
        public string getCompany(string prefix)
        {
            string query = "select Company_name from Company_details where Prefix='" + prefix + "'";
            return GENdb.getFirstCell(query);
        
        }
        public bool insertProj(string CompanyPrefix)
        {
            string query = "Insert into dbo.Project_details Values('" + CompanyPrefix + "','Default','Default','0')";
            return DWdb.setData(query);
        }
        public bool addProj(string warehousename, string no_of_tables,string prefix)
        {
            string query = "Update dbo.Project_details Set WarehouseName='" + warehousename + "',No_of_tables='" + no_of_tables + "' where CompanyPrefix='" + prefix + "'";
            return DWdb.setData(query);
        }

        public bool createOLTPTables(string[] queries)
        {
            foreach (string query in queries)
            {
                if (query != null)
                {
                    OLTPdb.setData(query);
                    DWdb.setData(query);
                }
            }
            return true;
        }
        public bool addOLTP_Details(string ID,string interval,string CmpPrefix,string OLTPName,string Forms,string Tables,string Users,string[,] formdetails,string[,] tabledetails,string[,] map)
        {

            int no_of_tables = (formdetails.Length / 4) + (tabledetails.Length / 3);
            string[] queries=new string[no_of_tables];
            for (int i = 0; i < formdetails.Length/4; i++)
            {
                if (formdetails[i, 2] != "False")
                {
                    string[] arr = formdetails[i, 1].Split('@');
                    for (int k = 0; k < arr.Length; k++)
                    {
                        arr[k] = arr[k].Replace("_", " ");
                       // arr[k] = "'" + arr[k] + "'";
                    }
                    string final = String.Join(",",arr);
                    string tempquery = "Create Table dbo." + CmpPrefix + "_" + OLTPName + "_" + formdetails[i,0] + " ("+final+" Primary key("+formdetails[i,3]+"))";
                    queries[i] = tempquery;
                }
            }
            int count = formdetails.Length / 4;
            for (int i = 0; i < tabledetails.Length/3; i++)
            {
                if (tabledetails[i, 0] == "" || tabledetails[i, 0] == null)
                    continue;
                string[] arr = tabledetails[i, 1].Split('@');
                for (int k = 0; k < arr.Length; k++)
                {
                    arr[k] = arr[k].Replace("_", " ");
                    //arr[k] = "'" + arr[k] + "'";
                }
                string final = String.Join(",", arr);
                string tempquery = "Create Table dbo." + CmpPrefix + "_" + OLTPName + "_" + tabledetails[i, 0] + " (" + final + " Primary key("+tabledetails[i,2]+"))";
                queries[count++] = tempquery;
            }

            createOLTPTables(queries);

            string FormDetails =CmpPrefix+"_"+ OLTPName + "Form";
            string TableDetails = CmpPrefix + "_" + OLTPName + "Table";
            string Mapping = CmpPrefix + "_" + OLTPName + "Map";
            string setting=CmpPrefix + "_" + OLTPName + "Setting";
            string query = "Insert into dbo.OLTPDetails(OLTPName,Forms,Tables,FormDetails,TableDetails,Mapping,Users,Interval,ID) Values ('" + OLTPName + "','" + Forms + "','" + Tables + "','"+FormDetails+"','"+TableDetails+"','"+Mapping+"','" + Users + "','"+interval+"','"+ID+"')";
            string query1="Create table dbo."+FormDetails+"(FormName varchar(50) not null,Attributes varchar(500) not null,Flag varchar(30) not null,PrimKey varchar(50) not null)";
            OLTPdb.setData(query1);
            OLTPdb.setdata2(formdetails,4,FormDetails);
            string query2 = "Create table dbo." + TableDetails + "(TableName varchar(50) not null,Attributes varchar(500) not null,PrimKey varchar(50) not null)";
            OLTPdb.setData(query2);
            OLTPdb.setdata2(tabledetails, 3, TableDetails);
            string query3 = "Create table dbo." +Mapping + "(TableAttr varchar(5000) not null,FormAttr varchar(5000) not null)";
            OLTPdb.setData(query3);
            OLTPdb.setdata2(map, 2, Mapping);
            string titles = "MR @MRS @MS @MISS @DR @CAPT @CAPTAIN @COL @COLONEL @COMMISSIONER @DEAN @DR @DRS @MASTER @PROF @SIR @SR @MR. @MRS. @MS. @MISS. @DR. @CAPT. @CAPTAIN. @COL. @COLONEL. @COMMISSIONER. @DEAN. @DR. @DRS. @MASTER. @PROF. @SIR. @SR. ";
            string AbbValue = "Kg,Kilogram@Km,Kilometre@Uk,United Kingdom@Usa,United States Of America@Who,World Health Organisation";
            string query4 = "Create Table dbo." + setting + "(CamelCase int,Spaces int,Titles int,TitleValue varchar(500),Abbreviation int,AbbreviationValue varchar(500),Timer int)";
            OLTPdb.setData(query4);
            query4 = "Insert dbo." + setting + "(CamelCase,Spaces,Titles,TitleValue,Abbreviation,AbbreviationValue,Timer) Values('1','1','1','"+titles+"','1','"+AbbValue+"','1')";
            OLTPdb.setData(query4);
            return  OLTPdb.setData(query);
        
         }

        public bool projectConfigured(string prefix)
        { 
            string query="Update dbo.Project_details Set configured='TRUE' where CompanyPrefix='"+prefix+"'";
            return DWdb.setData(query);
        }

        public string checkprojectConfigured(string prefix)
        {
            string query = "Select Configured from dbo.Project_details where CompanyPrefix='"+prefix+"'";
            return DWdb.getFirstCell(query);
        }
        public object[] getProjID(string username, string tablename)
        {
            string query = "Select ProjName,ProjID  from dbo." + tablename + " where Username='" + username + "'";
            return GENdb.getFirstRow(query);
        }

        public object[] getAllProjNames(string tablename)
        {
            string query = "Select Distinct ProjName from dbo." + tablename;
            return GENdb.getData(query);
        }
        public string getProjID1(string ProjectName, string tablename)
        {
            string query = "Select ProjID from dbo." + tablename + " where ProjName='" + ProjectName + "'";
            return GENdb.getFirstCell(query);

        }
        public bool addUser(string tablename,string Username, string Password, string role, string OLTPname, string OLTPid, bool FirstLogin,string Email)
        {
            string query = "Insert into dbo." + tablename + " Values('" + Username + "','" + Password + "','" + role + "','" + OLTPname + "','" + OLTPid + "','" + FirstLogin + "','"+Email+"')";
            return GENdb.setData(query);
        
        }

        public bool addUser_To_OLTP(string username,string projID)
        {
            string query = "Select Users from dbo.OLTPDetails where ID='"+projID+"'";
            string users = OLTPdb.getFirstCell(query);
            users += "@" + username;
            query = "Update dbo.OLTPDetails set Users='"+users+"'";
            return OLTPdb.setData(query);

        }

        public bool checkForExsistRecords(string tablename,string key,string attr)
        {
            
            string query = "Select * from dbo."+tablename+ " where "+attr+"="+key;
            object[] obj= OLTPdb.getData(query);
            if (obj != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool CheckTableExsists(string tablename)
        {
            try
            {
                string query = "Select * from dbo." + tablename;
                OLTPdb.getData(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string[] getOLTPSetting(string tablename)
        {
            string query = "Select * from dbo."+tablename;
            object[] obj = OLTPdb.getFirstRow(query);
            string[] str=new string[obj.Length];
            int i = 0;
            foreach (object tempobj in obj)
            {
                str[i] = obj[i].ToString();
                i++;
            }
            return str;
        }

        public DataTable pulldata(string tablename)
        {
            string query = "select * from dbo."+tablename; 
            DataTable dt= OLTPdb.PullData(query);
            query="Truncate table dbo."+tablename;
            OLTPdb.setData(query);
            return dt;
        }

        public bool copyBulkDataDW(DataTable dt, string tablename)
        {
            return DWdb.CopyData(dt,tablename);
        }

        public string getOLTPTables(string OLTPName)
        {
            string query = "Select Tables from dbo.OLTPDetails where OLTPName='"+OLTPName+"'";
            return OLTPdb.getFirstCell(query);
        }

        public object[] getAllOLTPusers(string oltpname, string prefix)
        {
            string query = "Select Username from dbo." + prefix + " Where ProjName='" + oltpname + "'";
            return GENdb.getData(query);
        }
        public string getPass(string Username, string prefix)
        {
            string query = "Select Password from dbo." + prefix + " Where Username='" + Username + "'";
            return GENdb.getFirstCell(query);
        }

        public object[] getAllUsers(string companyname, string oltpname)
        {
            string query = "Select Username from dbo." + companyname + " where ProjName='" + oltpname + "' and Role='User'";
            return GENdb.getData(query);
        }
        public object[] getAllAdmins(string companyname, string oltpname)
        {
            string query = "Select Username from dbo." + companyname + " where ProjName='" + oltpname + "' and Role='Admin'";
            return GENdb.getData(query);
        }
        public bool deluser(string companyname, string username)
        {
            string query = "Delete from dbo." + companyname + " where Username='" + username + "'";
            string ID = getProjID(username);
            string query1 = "Select Users from dbo.OLTPDetails where ID='"+ID+"'";
            try
            {
                string[] arr = OLTPdb.getFirstCell(query1).Split('@');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == username)
                    {
                        if (arr.Length > 1)
                            arr[i] = null;
                    }
                }
                string final;
                if (arr[0] != null)
                {
                    final = arr[0];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if (arr[1] != null)
                        {
                            final += "@" + arr[i];
                        }
                    }
                }
                else
                {
                    final = arr[1];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if (arr[1] != null)
                        {
                            final += "@" + arr[i];
                        }
                    }
                }
                query1 = "Update dbo.OLTPDetails set Users='" + final + "' where ID='" + ID + "'";
                OLTPdb.setData(query1);
            }
            catch
            {

            }      
            return GENdb.setData(query);
        }

        public bool setRecord(string tablename,string Param,string value)
        {
            string query = "Update dbo." + tablename + " set "+Param+"='"+value+"'";
            
            return OLTPdb.setData(query);
        }

        public string[] getTimerInfo(string OLTPName)
        {
            string query = "Select Interval,LastSetInterval from dbo.OLTPDetails where OLTPName='" + OLTPName + "'";
            object[] obj= OLTPdb.getFirstRow(query);
            string[] temp = new string[obj.Length];
            for (int i = 0; i < obj.Length;i++ )
            {
                temp[i] = obj[i].ToString();
            }
            return temp;
        }

        public bool setLastTimer(string OLTPName)
        {
            string query="Update dbo.OLTPDetails set LastSetInterval='"+DateTime.Now.ToString()+"' where OLTPName='"+OLTPName+"'";
            return OLTPdb.setData(query);
        }

        public bool checkInsert(string tablename, string Primeatt, string Primeval)
        {
            string query = "Select * from dbo." + tablename + "Where" + Primeatt + "='" + Primeval + "'";
            object[] data = OLTPdb.getFirstRow(query);
            if (data != null)
                return true;
            else
                return false;
        }

        public bool resetTimer(string OLTPName)
        {
            string query = "Update dbo.OLTPDetails set LastSetInterval=NULL where OLTPName='"+OLTPName+"'";
            return OLTPdb.setData(query);
        }

        public bool changeinterval(string OLTPName, string interval)
        {
            string query = "Update dbo.OLTPDetails set Interval='"+interval+"' where OLTPName='" + OLTPName + "'";
            return OLTPdb.setData(query);
        }

        public string getProjName(string username)
        {
            string[] arr = username.Split('_');
            string query = "select ProjName from dbo." + arr[0] + " where Username='" + username + "'";
            return GENdb.getFirstCell(query);
        }

        public DataTable getTableData(string tablename, string prefix)
        {
            if (tablename.Contains("Cleansed"))
            {
                string tablename1 = tablename.Replace("Cleansed_", "");
                string query = "Select * from dbo." + tablename1;
                return DWdb.PullData(query);
            }
            else if (tablename == prefix)
            {
                string query = "Select * from dbo." + tablename;
                return GENdb.PullData(query);
            }
            else
            {
                string query = "Select * from dbo." + tablename;
                return OLTPdb.PullData(query);
            }


        }

        public DataTable executeSelectQuery(string query, string tb)
        {
            if (tb == "GEN")
                return GENdb.PullData(query);
            if (tb == "DW")
                return DWdb.PullData(query);
            else
                return OLTPdb.PullData(query);
        }

        public bool executequery(string query, string tb)
        {
            if (tb == "GEN")
                return GENdb.setData(query);
            if (tb == "DW")
                return DWdb.setData(query);
            else
                return OLTPdb.setData(query);
        }

        public object[] getUserEmail(string username, string Prefix)
        {
            string query = "Select Username,Email from dbo." + Prefix + " where Username='" + username + "'";
            return GENdb.getFirstRow(query);
        }

        public bool setFirstLogin(string username, string prefix)
        {
            string query = "Update dbo." + prefix + " set FirstLogin='True' where Username='" + username + "'";
            return GENdb.setData(query);
        }

        public bool setPassword(string password,string username,string prefix)
        {
            string query = "Update dbo." + prefix + " set Password='" + password + "' where Username='"+username+"'";
            return GENdb.setData(query);
        }

        public string executeOLTPTransaction(string[] queries,string tb)
        {
            if(tb=="OLTP")
                return OLTPdb.ExecuteSqlTransaction(queries);
            if (tb == "DW")
                return DWdb.ExecuteSqlTransaction(queries);
            return GENdb.ExecuteSqlTransaction(queries);
        }

        public bool createLog(string Prefix)
        {
            string query = "Create table dbo."+Prefix+"_Logs(Username varchar(50) not null,Action varchar(500),Page varchar(50) not null,DT datetime not null)";
            return GENdb.setData(query);
        }

        public bool ExecuteGenQuery(string query)
        {
            return GENdb.setData(query);
        }

        public bool isOLTPConfigured(string OLTPName)
        { 
            string query="Select * from dbo.OLTPDetails where OLTPName='"+OLTPName+"'";
            object[] obj = OLTPdb.getData(query);
            if (obj == null)
                return false;
            else
                return true;
        }

        public DataTable getComapnayLogs(string prefix)
        {
            string query = "Select * from dbo."+prefix+"_Logs";
            return GENdb.PullData(query);
        }

        public DataTable getIndivisualLogs(string Username)
        {
            string[] prefix = Username.Split('_');
            string query = "Select Action,Page,DT from dbo."+prefix[0]+"_Logs where Username='"+Username+"'";
            return GENdb.PullData(query);
        }

        public DataTable getTopIndivisualLogs(string Username)
        {
            string[] prefix = Username.Split('_');
            string query = "Select TOP 2 Action,Page,DT from dbo." + prefix[0] + "_Logs where Username='" + Username + "' order by DT DESC";
            return GENdb.PullData(query);
        }
    }
}
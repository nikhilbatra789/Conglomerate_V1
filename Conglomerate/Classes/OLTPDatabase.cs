using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace Conglomerate.Classes
{
    class OLTPDatabase
    {
        //static string connectionString = @"Data Source=.;Initial Catalog=Gen_Conglomerate;Integrated Security=True";
        static string connectionString = "SERVER=184.168.47.19;" + "DATABASE=OLTP_Conglomerate;" + "UID=OLTP_User_Conglo;" + "PASSWORD=123@Abc;";

        public SqlConnection connection = new SqlConnection(connectionString);
        private DataTable dataTable;

        public OLTPDatabase()
        {
            connection.Open();
        }

        public object[] getData(string queryString)
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                ArrayList list = new ArrayList();

                while (reader.Read())
                {
                    object[] row = new object[reader.FieldCount];
                    reader.GetValues(row);
                    list.Add(row);
                }
                reader.Close();

                return list.ToArray(typeof(Array)) as object[];
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public object[] getFirstRow(string queryString)
        {
            object[] records = getData(queryString);
            return records[0] as object[];
        }

        public string getFirstCell(string queryString)
        {
            try
            {
                object[] records = getData(queryString);
                object[] data = records[0] as object[];
                return data[0].ToString();
            }
            catch
            {
                return null;
            }
        }

        public bool setData(string queryString)
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            if (command.ExecuteNonQuery() > 0)
            {
                //connection.Close();
                return true;
            }
            else
            {
                //connection.Close();
                return false;
            }
        }
        public bool setdata2(string[,] arr,int column,string table_name)
        {
            bool b = true; ;
            string[] clmn=new string[column];
            
            for (int i = 0; i < arr.Length / column; i++)
            {
                for(int j=0;j<column;j++)
                {
                     clmn[j]="'"+arr[i,j]+"'";
                }
                string final=String.Join(",",clmn);
                string query = "Insert into dbo." + table_name + " Values(" + final + ")";
                b=setData(query);
                if (b == false)
                    return false;

            }
            return true;
        
        }

        public DataTable PullData(string query)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            dataTable = new DataTable();
            conn.Open();

            // create data adapter
            // SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(dataTable);
            }
            return dataTable;
        }

        public string ExecuteSqlTransaction(string[] queries)      
        {
            string error = "";
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    for (int i = 0; i < queries.Length; i++)
                    {
                        if (queries[i] == null)
                            continue;
                        command.CommandText = queries[i];
                        command.ExecuteNonQuery();
                    }
                    
                    // Attempt to commit the transaction.
                    transaction.Commit();
                    return error;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    // Attempt to roll back the transaction. 
                    try
                    {
                        transaction.Rollback();
                        return error;
                    }
                    catch (Exception ex2)
                    {
                        error=ex.Message;
                        return error;
                    }
                }
            
        }
    }
}

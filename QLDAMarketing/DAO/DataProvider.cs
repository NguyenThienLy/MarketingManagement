using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ProjectManagement.CO;
using System.Data.SqlClient;

namespace ProjectManagement.DAO
{
    public class DataProvider
    {
        private static DataProvider instance; // ctrl + r + e;

        public static DataProvider Instance
        {
            get { if (DataProvider.instance == null) DataProvider.instance = new DataProvider(); return DataProvider.instance; }

            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        // private string StrConnect = @"Data Source = " + StaticVarClass.server_ConnectSQLServer + ";Initial Catalog=" + StaticVarClass.server_ConnectSQLServerCatalog + ";User ID=" + StaticVarClass.server_ConnectSQLServerUser + ";Password=" + StaticVarClass.server_ConnectSQLServerPass + "";

        private string StrConnect = @"Data Source = 127.0.0.1;initial catalog=ProjectManagement;integrated security=True;";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(StrConnect))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');

                        int i = 0;

                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);

                    return data;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(StrConnect))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');

                        int i = 0;

                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }

                    data = command.ExecuteNonQuery();

                    return data;
                }
                catch
                {
                    return -1;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(StrConnect))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');

                        int i = 0;

                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }

                    data = command.ExecuteScalar();

                    return data;
                }
                catch
                {
                    return -1;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

using Challenge02.DAL.MODELS;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge02.DAL
{
    public class Repo
    {
        private static string _database = "postgres";

        private static string CONNECTION_STRING = @"
            Host=HOST_NAME;
            Port=5432;
            Username=postgres;
            Password=PASSWORD;
            Database=postgres;
            ";

        public static List<TableTest> ExecuteQuery(string command)
        {
            var connection = new NpgsqlConnection(string.Format(CONNECTION_STRING, _database));

            try
            {
                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
            List <TableTest> tests = new();
            try
            {
                using (var cmd = new NpgsqlCommand(command, connection))
                {
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            tests.Add(new TableTest
                            {                                
                                id = int.Parse(reader["id"].ToString()),
                                text_value = reader["text_value"].ToString()                           
                            });
                        }
                    }                  
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
            return tests;
        }

        public static List<TableInfo> GetTableDetails(string v)
        {
            var connection = new NpgsqlConnection(string.Format(CONNECTION_STRING, _database));


            try
            {
                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
            string query = $@"
            SELECT column_name, data_type, is_nullable, column_default
            FROM information_schema.columns
            WHERE table_name = '{v}'";

            List<TableInfo> tables = new();
            var cmd = new NpgsqlCommand(query, connection);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    tables.Add(new TableInfo
                    {
                        Name = reader["column_name"].ToString(),
                        DataType = reader["data_type"].ToString(),
                        IsNullable = reader["is_nullable"].ToString(),
                        Default = reader["column_default"]?.ToString()
                    });
                }
            }
            return tables;
        }

        public static List<string> GetTableNames()
        {
            var connection = new NpgsqlConnection(string.Format(CONNECTION_STRING, _database));


            try
            {
                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }

            string query = $@"
                            SELECT table_name 
                            FROM information_schema.tables 
                            WHERE table_schema = 'public'";

            List<string> names = new();
            using (var cmd = new NpgsqlCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                
                while (reader.Read())
                {
                    names.Add(reader.GetString(0));
                }
            }
            return names;
        }

        internal static int ExecuteNonSelectQuery(string command)
        {
            var connection = new NpgsqlConnection(string.Format(CONNECTION_STRING, _database));
            try
            {
                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }

            try
            {
                using (var cmd = new NpgsqlCommand(command, connection))
                {

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }
    }
}

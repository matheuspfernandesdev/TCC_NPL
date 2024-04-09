using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_TutelaProvisoria.DbConnect
{
    public abstract class BaseDB
    {
        public static void RunSQLScript(string script)
        {
            var connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnectionStringBuilder SqlSB = new SqlConnectionStringBuilder(connection);


            using (SqlConnection SqlC = new SqlConnection(SqlSB.ConnectionString))
            {
                SqlC.Open();

                using (SqlCommand dbCommand = new SqlCommand(script, SqlC))
                {
                    dbCommand.CommandText = script;
                    dbCommand.ExecuteNonQuery();
                }

                SqlC.Close();
            }

            Console.WriteLine("Rodou script SQL");
        }

        public static int RunScriptAndReturnIntValue(string script)
        {
            int Value;
            var connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnectionStringBuilder SqlSB = new SqlConnectionStringBuilder(connection);


            using (SqlConnection SqlC = new SqlConnection(SqlSB.ConnectionString))
            {
                SqlC.Open();

                using (SqlCommand dbCommand = new SqlCommand(script, SqlC))
                {
                    dbCommand.CommandText = script;
                    SqlDataReader reader = dbCommand.ExecuteReader();

                    if (reader.Read())
                        Value = reader.GetInt32(0);
                    else
                        Value = -1;
                    
                }

                SqlC.Close();
            }

            Console.WriteLine("Rodou script SQL");

            return Value;
        }

        public static List<string> RetornaResultadoQueryDeUmaLinha(string ConsultaASerExecutada)
        {
            SqlConnectionStringBuilder SqlSB = new SqlConnectionStringBuilder();

            List<string> QueryResults = new List<string>();
            int NumberOfColumns;

            using (SqlConnection SqlC = new SqlConnection(SqlSB.ConnectionString))
            {
                SqlC.Open();

                using (SqlCommand dbCommand = new SqlCommand(ConsultaASerExecutada, SqlC))
                {
                    using (SqlDataReader reader = dbCommand.ExecuteReader())
                    {
                        NumberOfColumns = reader.FieldCount;

                        while (reader.Read())
                        {
                            for (int i = 0; i < NumberOfColumns; i++)
                            {
                                QueryResults.Add(reader.GetString(i));
                            }
                        }

                    }
                }

                SqlC.Close();
            }

            return QueryResults;
        }

    }
}

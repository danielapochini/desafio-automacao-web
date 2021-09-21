using Dapper;
using DesafioAutomacaoWeb.Utils.Settings;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DesafioAutomacaoWeb.Utils.Helpers
{
    public static class DatabaseHelper
    {
        private static readonly AppSettings appSettings = new();

        public static IEnumerable<T> ExecuteDbCommand<T>(string query)
        {
            string connectionString = appSettings.DbConnection;
             
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DefaultTypeMap.MatchNamesWithUnderscores = true;

                return connection.Query<T>(query);
            }
        }

        public static void ResetMantisDatabase()
        {
            string file = "Utils/Database/Resources/mantis_dump.sql";

            string connectionString = appSettings.DbConnection;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = connection;
                        connection.Open();
                        mb.ImportFromFile(file);
                        connection.Close();
                    }
                }
            }
        }
    }
}
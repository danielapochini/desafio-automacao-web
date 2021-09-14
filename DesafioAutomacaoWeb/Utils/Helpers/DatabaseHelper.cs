using Dapper;
using DesafioAutomacaoWeb.Utils.Settings;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Helpers
{
    public class DatabaseHelper
    {
        private static readonly AppSettings appSettings = new AppSettings();

        public static IEnumerable<T> ExecuteDbCommand<T>(string query)
        {
            string connectionString = appSettings.DbConnection;

            //utilizando "using" para abrir e fechar a conexao
            using (var connection = new MySqlConnection(connectionString))
            {
                DefaultTypeMap.MatchNamesWithUnderscores = true;

                return connection.Query<T>(query);
            }
        }

        public static void ResetMantisDatabase()
        {
            string file = "Utils/Resources/Database/mantis_dump.sql";

            string connectionString = appSettings.DbConnection;

            using (var connection = new MySqlConnection(connectionString))
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

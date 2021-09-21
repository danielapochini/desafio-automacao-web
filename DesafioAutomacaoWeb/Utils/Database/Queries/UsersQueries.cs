using DesafioAutomacaoWeb.Utils.Entities;
using DesafioAutomacaoWeb.Utils.Helpers;
using System.Linq;

namespace DesafioAutomacaoWeb.Utils.Database.Queries
{
    public static class UsersQueries
    {
        public static UsersEntities ListLastUserCreated()
        {
            string query = "SELECT * bugtracker.FROM mantis_user_table ORDER BY ID DESC LIMIT 1";
            return DatabaseHelper.ExecuteDbCommand<UsersEntities>(query).FirstOrDefault();
        }

        public static UsersEntities ListRandomUsers()
        {
            string query = "SELECT * bugtracker.FROM mantis_user_table  WHERE access_level != 90 " +
                "AND enabled != 0 ORDER BY RAND() DESC LIMIT 1  ";
            return DatabaseHelper.ExecuteDbCommand<UsersEntities>(query).FirstOrDefault();
        }

        public static UsersEntities ListUserInfo(string userName)
        {
            string query = "SELECT * FROM bugtracker.mantis_user_table " +
                        "WHERE username = '$USERNAME'".Replace("$USERNAME", userName);

            //FirstOrDefault pois o método chamado retorna um Inumerable
            return DatabaseHelper.ExecuteDbCommand<UsersEntities>(query).FirstOrDefault();
        }
    }
}
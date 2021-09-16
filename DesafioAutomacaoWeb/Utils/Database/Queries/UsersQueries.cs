using DesafioAutomacaoWeb.Utils.Entities;
using DesafioAutomacaoWeb.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Database.Queries
{
    public class UsersQueries
    {
        public static UsersEntities ListLastUserCreated()
        {
            var query = "SELECT * FROM mantis_user_table ORDER BY ID DESC LIMIT 1";
            return DatabaseHelper.ExecuteDbCommand<UsersEntities>(query).FirstOrDefault();
        }

        public static UsersEntities ListRandomUsers()
        {
            var query = "SELECT * FROM mantis_user_table " +
                "WHERE username != 'administrator' ORDER BY RAND() DESC LIMIT 1";
            return DatabaseHelper.ExecuteDbCommand<UsersEntities>(query).FirstOrDefault();
        }

        public static UsersEntities ListLastInactiveUser()
        {
            var query = "SELECT * FROM mantis_user_table WHERE enabled = '0' ORDER BY ID DESC LIMIT 1";
            return DatabaseHelper.ExecuteDbCommand<UsersEntities>(query).FirstOrDefault();
        }
    }
}

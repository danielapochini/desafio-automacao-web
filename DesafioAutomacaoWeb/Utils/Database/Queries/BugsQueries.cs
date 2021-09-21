using DesafioAutomacaoWeb.Utils.Database.Entities;
using DesafioAutomacaoWeb.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Database.Queries
{
    public static class BugsQueries
    {
        public static BugsEntities ListLastBugAdded()
        {
            string query = "SELECT * FROM bugtracker.mantis_bug_table ORDER BY ID DESC LIMIT 1";
            return DatabaseHelper.ExecuteDbCommand<BugsEntities>(query).FirstOrDefault();
        }
    }
}

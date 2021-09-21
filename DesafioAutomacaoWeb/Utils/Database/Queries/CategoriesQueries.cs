using DesafioAutomacaoWeb.Utils.Database.Entities;
using DesafioAutomacaoWeb.Utils.Helpers;
using System.Linq;

namespace DesafioAutomacaoWeb.Utils.Database.Queries
{
    public static class CategoriesQueries
    {
        public static CategoriesEntities ListLastCategoryAdded()
        {
            string query = "SELECT * FROM bugtracker.mantis_category_table ORDER BY ID DESC LIMIT 1";
            return DatabaseHelper.ExecuteDbCommand<CategoriesEntities>(query).FirstOrDefault();
        }

        public static ProjectsEntities ListCategoryInfo(string nomeCategoria)
        {
            string query = "SELECT * FROM bugtracker.mantis_category_table " +
                        "WHERE name = '$NAME'".Replace("$NAME", nomeCategoria);

            return DatabaseHelper.ExecuteDbCommand<ProjectsEntities>(query).FirstOrDefault();
        }
    }
}
using DesafioAutomacaoWeb.Utils.Database.Entities;
using DesafioAutomacaoWeb.Utils.Helpers;
using System.Linq;

namespace DesafioAutomacaoWeb.Utils.Database.Queries
{
    public static class ProjectsQueries
    {
        public static ProjectsEntities ListLastProjectAdded()
        {
            string query = "SELECT * FROM mantis_project_table ORDER BY ID DESC LIMIT 1";
            return DatabaseHelper.ExecuteDbCommand<ProjectsEntities>(query).FirstOrDefault();
        }

        public static ProjectsEntities ListProjectInfo(string nomeProjeto)
        {
            string query = "SELECT * FROM mantis_project_table " +
                        "WHERE name = '$NAME'".Replace("$NAME", nomeProjeto);

            return DatabaseHelper.ExecuteDbCommand<ProjectsEntities>(query).FirstOrDefault();
        }

        public static ProjectsEntities ListRandomProjects()
        {
            string query = "SELECT * FROM mantis_project_table ORDER BY RAND() DESC LIMIT 1";
            return DatabaseHelper.ExecuteDbCommand<ProjectsEntities>(query).FirstOrDefault();
        }
    }
}
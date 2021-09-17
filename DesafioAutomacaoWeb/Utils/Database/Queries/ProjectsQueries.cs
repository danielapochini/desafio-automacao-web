using DesafioAutomacaoWeb.Utils.Database.Entities;
using DesafioAutomacaoWeb.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Database.Queries
{
    public class ProjectsQueries
    {
        public static ProjectsEntities ListarUltimoProjetoCadastrado()
        {
            var query = "SELECT * FROM bugtracker.mantis_project_table ORDER BY ID DESC LIMIT 1";
            return DatabaseHelper.ExecuteDbCommand<ProjectsEntities>(query).FirstOrDefault();
        }

        public static ProjectsEntities ListarInformacoesProjeto(string nomeProjeto)
        {
            var query = "SELECT * FROM bugtracker.mantis_project_table " +
                "WHERE name = '$NAME'".Replace("$NAME", nomeProjeto);

            return DatabaseHelper.ExecuteDbCommand<ProjectsEntities>(query).FirstOrDefault();
        }

        public static ProjectsEntities ListRandomProjects()
        {
            var query = "SELECT * FROM mantis_project_table ORDER BY RAND() DESC LIMIT 1";
            return DatabaseHelper.ExecuteDbCommand<ProjectsEntities>(query).FirstOrDefault();
        }

    }
}

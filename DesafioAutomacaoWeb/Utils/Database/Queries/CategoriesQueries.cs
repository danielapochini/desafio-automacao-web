using DesafioAutomacaoWeb.Utils.Database.Entities;
using DesafioAutomacaoWeb.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Database.Queries
{
    public class CategoriesQueries
    {
        public static CategoriesEntities ListarUltimaCategoriaCadastrada()
        {
            var query = "SELECT * FROM bugtracker.mantis_category_table ORDER BY ID DESC LIMIT 1";
            return DatabaseHelper.ExecuteDbCommand<CategoriesEntities>(query).FirstOrDefault();
        }

        public static ProjectsEntities ListarInformacoesCategoria(string nomeCategoria)
        {
            var query = "SELECT * FROM bugtracker.mantis_category_table " +
                "WHERE name = '$NAME'".Replace("$NAME", nomeCategoria);

            return DatabaseHelper.ExecuteDbCommand<ProjectsEntities>(query).FirstOrDefault();
        }
    }
}

using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Manage.Projects;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Projects
{
    [Binding]
    public class EditProjectsSteps
    { 
        private readonly ManageProjectCreatePage projectCreatePage;

        private string projectName;
        private string projectStatus;
        private string projectViewStatus;
        private bool projectInherit;
        private string projectDescription;

        public EditProjectsSteps()
        {  
            projectCreatePage = new ManageProjectCreatePage();
        }

         
        [When(@"alterar todos os campos com novos dados")]
        public void QuandoAlterarTodosOsCamposComNovosDados()
        {
            projectName = "Teste Web";
            projectStatus = "obsolete";
            projectViewStatus = "private";
            projectInherit = false;
            projectDescription = "Projeto Teste Automação Web";

            projectCreatePage.UpdateExistingProject(projectName, projectStatus, projectInherit, projectViewStatus, projectDescription);
        }

        [When(@"clicar no botão de Update Project")]
        public void QuandoClicarNoBotaoDeUpdateProject()
        {
            projectCreatePage.ClickUpdateProjectButton();
        }
         
        [Then(@"os dados do projeto serão atualizados com sucesso no banco de dados")]
        public void EntaoOsDadosDoProjetoSeraoAtualizadosComSucessoNoBancoDeDados()
        {
            var projectDb = ProjectsQueries.ListarInformacoesProjeto(projectName);
            Assert.Equal(projectName, projectDb.Name);
            Assert.Equal(projectStatus, projectDb.Status.ToString().ToLower());
            Assert.Equal(projectInherit, projectDb.InheritGlobal);
            Assert.Equal(projectViewStatus, projectDb.ViewState.ToString().ToLower());
            Assert.Equal(projectDescription, projectDb.Description); 
        }
    }
}

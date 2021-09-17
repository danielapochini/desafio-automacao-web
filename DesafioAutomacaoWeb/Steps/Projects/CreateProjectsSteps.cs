using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Manage.Projects;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Projects
{
    [Binding]
    public class CreateProjectsSteps
    {
        private readonly ManagePage managePage;
        private readonly ManageProjectsPage projectPage;
        private readonly ManageProjectCreatePage projectCreatePage;

        private string projectName;
        private string projectStatus;
        private string projectViewStatus;
        private bool projectInherit;
        private string projectDescription;

        public CreateProjectsSteps()
        {
            managePage = new ManagePage();
            projectPage = new ManageProjectsPage();
            projectCreatePage = new ManageProjectCreatePage();
        } 

        [Given(@"selecione a aba Manage Projects")]
        public void DadoSelecioneAAbaManageProjects()
        {
            managePage.NavigateToManageProjectsTab();
        }

        [When(@"clicar no botão de criar novo projeto")]
        public void QuandoClicarNoBotaoDeCriarNovoProjeto()
        {
            projectPage.ClickCreateNewProjectButton();
        }

        [When(@"preencher os dados dos campos (.*), (.*), (.*), (.*), (.*) do novo projeto")]
        public void QuandoPreencherOsDadosDosCamposDoNovoProjeto(string name, string status, bool globalCategory, string viewStatus, string description)
        {
            projectName = name;
            projectStatus = status;
            projectInherit = globalCategory;
            projectViewStatus = viewStatus;
            projectDescription = description;

            projectCreatePage.CreateNewProject(name, status, globalCategory, viewStatus, description);
        }

        [Then(@"o projeto deverá ser criado com sucesso no banco de dados")]
        public void EntaoOProjetoDeveraSerCriadoComSucessoNoBancoDeDados()
        {
            var projectDb = ProjectsQueries.ListarUltimoProjetoCadastrado();
            Assert.Equal(projectName, projectDb.Name);
            Assert.Equal(projectStatus, projectDb.Status.ToString().ToLower());
            Assert.Equal(projectInherit, projectDb.InheritGlobal);
            Assert.Equal(projectViewStatus, projectDb.ViewState.ToString().ToLower());
            Assert.Equal(projectDescription, projectDb.Description);
        }

    }
}

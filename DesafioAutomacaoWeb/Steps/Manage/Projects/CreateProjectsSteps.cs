using DesafioAutomacaoWeb.Pages.Manage.Projects;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using DesafioAutomacaoWeb.Utils.Drivers;
using DesafioAutomacaoWeb.Utils.Settings;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Projects
{
    [Binding]
    public class CreateProjectsSteps
    {
        private readonly ManageProjectCreatePage projectCreatePage;
        private readonly ManageProjectsPage projectPage;
        private string projectDescription;
        private bool projectInherit;

        private string projectName;
        private string projectStatus;
        private string projectViewStatus;

        public CreateProjectsSteps()
        {
            projectPage = new ManageProjectsPage();
            projectCreatePage = new ManageProjectCreatePage();
        }

        [When(@"clicar no botão de criar novo projeto")]
        public void QuandoClicarNoBotaoDeCriarNovoProjeto()
        {
            projectPage.ClickCreateNewProjectButton();
        }

        [When(@"preencher os dados dos campos (.*), (.*), (.*), (.*), (.*) do novo projeto")]
        public void QuandoPreencherOsDadosDosCamposDoNovoProjeto(string name, string status, bool globalCategory,
            string viewStatus, string description)
        {
            projectName = name;
            projectStatus = status;
            projectInherit = globalCategory;
            projectViewStatus = viewStatus;
            projectDescription = description;

            projectCreatePage.CreateNewProject(name, status, globalCategory, viewStatus, description);
        }

        [When(@"não preencher o campo de nome do projeto")]
        public void QuandoNaoPreencherOCampoDeNomeDoProjeto()
        {
            projectCreatePage.CheckRequiredField();
        }

        [When(@"clicar no botão de Create Project")]
        public void QuandoClicarNoBotaoDeCreateProject()
        {
            projectCreatePage.ClickAddProjectButton();
        }

        [Then(@"o projeto deverá ser criado com sucesso no banco de dados")]
        public void EntaoOProjetoDeveraSerCriadoComSucessoNoBancoDeDados()
        {
            Utils.Database.Entities.ProjectsEntities projectDb = ProjectsQueries.ListLastProjectAdded();
            Assert.Equal(projectName, projectDb.Name);
            Assert.Equal(projectStatus, projectDb.Status.ToString().ToLower());
            Assert.Equal(projectInherit, projectDb.InheritGlobal);
            Assert.Equal(projectViewStatus, projectDb.ViewState.ToString().ToLower());
            Assert.Equal(projectDescription, projectDb.Description);
        }

        [Then(@"deverá retornar a mensagem de campo obrigatório ""(.*)""")]
        public void EntaoDeveraRetornarAMensagemDeCampoObrigatorio(string expectedMessage)
        {
            string actualMessage = projectCreatePage.ReturnRequiredMessage();
            if (ObjectRepository.Config.GetBrowser() == BrowserType.Firefox &&
                !ObjectRepository.Config.GetRemoteDriverExecution())
            {
                Assert.Equal("Preencha este campo.", actualMessage);
            }
            else
            {
                Assert.Equal(expectedMessage, actualMessage);
            }
        }
    }
}
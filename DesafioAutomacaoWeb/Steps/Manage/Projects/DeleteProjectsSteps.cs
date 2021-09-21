using DesafioAutomacaoWeb.Pages.Manage.Projects;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Projects
{
    [Binding]
    public class DeleteProjectsSteps
    {
        private readonly ManageProjectCreatePage projectCreatePage;
        private string projectName;

        public DeleteProjectsSteps()
        {
            projectCreatePage = new ManageProjectCreatePage();
        }

        [When(@"clicar no botão de Delete Project")]
        public void QuandoClicarNoBotaoDeDeleteProject()
        {
            projectCreatePage.ClickDeleteProjectButton();
        }

        [Then(@"a operação de remoção de projeto deverá ser confirmada")]
        public void EntaoAOperacaoDeRemocaoDeProjetoDeveraSerConfirmada()
        {
            projectName = projectCreatePage.ReturnProjectWarningBox();
            projectCreatePage.ClickDeleteProjectButton();
        }

        [Then(@"os dados do projeto deverão ser removidos do banco de dados com sucesso")]
        public void EntaoOsDadosDoProjetoDeveraoSerRemovidosDoBancoDeDadosComSucesso()
        {
            Utils.Database.Entities.ProjectsEntities projectDb = ProjectsQueries.ListProjectInfo(projectName);
            Assert.Null(projectDb);
        }
    }
}
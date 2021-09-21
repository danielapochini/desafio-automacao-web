using DesafioAutomacaoWeb.Pages.Manage.Projects;
using TechTalk.SpecFlow;

namespace DesafioAutomacaoWeb.Steps.Projects
{
    [Binding]
    public class DeleteGlobalCategoriesSteps
    {
        private readonly ManageProjectCategoryPage categoryPage;
        private readonly ManageProjectsPage projectPage;

        public DeleteGlobalCategoriesSteps()
        {
            projectPage = new ManageProjectsPage();
            categoryPage = new ManageProjectCategoryPage();
        }

        [When(@"selecionar a categoria")]
        public void QuandoSelecionarACategoria()
        {
            projectPage.ClickEditCategoryLink();
        }

        [When(@"clicar no botão de Delete Category")]
        public void QuandoClicarNoBotaoDeDeleteCategory()
        {
            categoryPage.ClickDeleteCategoryButton();
        }
    }
}
using DesafioAutomacaoWeb.Pages.Manage.Projects;
using System;
using TechTalk.SpecFlow;

namespace DesafioAutomacaoWeb.Steps.Projects
{
    [Binding]
    public class DeleteGlobalCategoriesSteps
    {
        private readonly ManageProjectsPage projectPage;
        private readonly ManageProjectCategoryPage categoryPage;
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

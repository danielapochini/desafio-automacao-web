using DesafioAutomacaoWeb.Pages.Manage.Projects;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Projects
{
    [Binding]
    public class EditGlobalCategoriesSteps
    {
        private readonly ManageProjectCategoryPage categoryPage;
        private readonly ManageProjectsPage projectPage;
        private string categoryName;

        public EditGlobalCategoriesSteps()
        {
            projectPage = new ManageProjectsPage();
            categoryPage = new ManageProjectCategoryPage();
        }

        [When(@"selecionar uma categoria")]
        public void QuandoSelecionarUmaCategoria()
        {
            Utils.Database.Entities.CategoriesEntities categoryDb = CategoriesQueries.ListLastCategoryAdded();
            categoryName = categoryDb.Name;
            projectPage.ClickEditCategoryLink();
        }

        [When(@"editar os campos")]
        public void QuandoEditarOsCampos()
        {
            categoryName = "Teste Auto";
            categoryPage.FillCategoryInputs(categoryName, "administrator");
        }

        [When(@"não preencher o campo de nome")]
        public void QuandoNaoPreencherOCampoDeNome()
        {
            categoryPage.CheckRequiredField();
        }

        [Then(@"a categoria deverá ser atualizada com sucesso")]
        public void EntaoACategoriaDeveraSerAtualizadaComSucesso()
        {
            Utils.Database.Entities.ProjectsEntities categoryDb = CategoriesQueries.ListCategoryInfo(categoryName);
            Assert.Equal(categoryName, categoryDb.Name);
        }
    }
}
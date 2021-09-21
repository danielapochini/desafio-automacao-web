using DesafioAutomacaoWeb.Pages.Manage.Projects;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Projects
{
    [Binding]
    public class EditGlobalCategoriesSteps
    {
        private readonly ManageProjectsPage projectPage;
        private readonly ManageProjectCategoryPage categoryPage;
        private string categoryName;

        public EditGlobalCategoriesSteps()
        {
            projectPage = new ManageProjectsPage();
            categoryPage = new ManageProjectCategoryPage();
        }

        [When(@"selecionar uma categoria")]
        public void QuandoSelecionarUmaCategoria()
        {
            var categoryDb = CategoriesQueries.ListarUltimaCategoriaCadastrada();
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
            var categoryDb = CategoriesQueries.ListarInformacoesCategoria(categoryName);
            Assert.Equal(categoryName, categoryDb.Name);
        }
    }
}

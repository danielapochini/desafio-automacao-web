using DesafioAutomacaoWeb.Pages.Manage.Projects;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Projects
{
    [Binding]
    public class CreateGlobalCategoriesSteps
    {
        private readonly ManageProjectsPage projectPage;

        public CreateGlobalCategoriesSteps()
        {
            projectPage = new ManageProjectsPage();
        }

        [When(@"não preencher o campo de nome da categoria")]
        public void QuandoNaoPreencherOCampoDeNomeDaCategoria()
        {
            projectPage.FillCategoryBox("");
        }

        [When(@"preencher o campo de nome da categoria")]
        public void QuandoPreencherOCampoDeNomeDaCategoria()
        {
            projectPage.FillCategoryBox("Teste Automação");
        }

        [When(@"clicar no botão de Add Category")]
        public void QuandoClicarNoBotaoDeAddCategory()
        {
            projectPage.ClickCreateNewCategoryButton();
        }

        [When(@"preencher o campo de nome da categoria com um valor já existente no banco de dados")]
        public void QuandoPreencherOCampoDeNomeDaCategoriaComUmValorJaExistenteNoBancoDeDados()
        {
            Utils.Database.Entities.CategoriesEntities categoryDb = CategoriesQueries.ListLastCategoryAdded();
            projectPage.FillCategoryBox(categoryDb.Name);
        }

        [Then(@"a categoria deverá ser criada com sucesso")]
        public void EntaoACategoriaDeveraSerCriadaComSucesso()
        {
            Assert.True(projectPage.CheckCategoryTable("Teste Automação"));
        }
    }
}
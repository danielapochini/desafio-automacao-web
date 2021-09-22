using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Issues;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Issues
{
    [Binding]
    public class SearchIssueSteps
    {
        private readonly HomePage homePage;
        private readonly ViewIssuesPage viewIssuesPage;
        private string bugId;

        public SearchIssueSteps()
        {
            homePage = new HomePage();
            viewIssuesPage = new ViewIssuesPage();
        }

        [When(@"preencher o campo de busca com um id existente no banco de dados")]
        public void QuandoPreencherOCampoDeBuscaComUmIdExistenteNoBancoDeDados()
        {
            var bugDb = BugsQueries.ListLastBugAdded().Id;
            bugId = string.Format("{0:D7}", bugDb);
            homePage.SearchIssueId(bugId);
        }

        [When(@"preencher o campo de busca com um id que não exista no banco de dados")]
        public void QuandoPreencherOCampoDeBuscaComUmIdQueNaoExistaNoBancoDeDados()
        {
            var bugDb = BugsQueries.ListLastBugAdded().Id+1;
            bugId = string.Format("{0:D7}", bugDb);
            homePage.SearchIssueId(bugId);
        }

        [When(@"preencher o campo de busca com um valor não numérico")]
        public void QuandoPreencherOCampoDeBuscaComUmValorNaoNumerico()
        {
            homePage.SearchIssueId("Teste");
        } 

        [Then(@"deverá retornar a página com a issue desejada")]
        public void EntaoDeveraRetornarAPaginaComAIssueDesejada()
        {
            Assert.Equal(bugId, viewIssuesPage.ReturnBugId());
        } 
    }
}

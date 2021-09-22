using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Issues;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using DesafioAutomacaoWeb.Utils.Drivers;
using DesafioAutomacaoWeb.Utils.Settings; 
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Issues
{
    [Binding]
    public class ReportNewIssueSteps
    {
        private readonly HomePage homePage;
        private readonly ReportIssuePage reportIssuePage;

        public ReportNewIssueSteps()
        {
            homePage = new HomePage();
            reportIssuePage = new ReportIssuePage();
        }

        [Given(@"que o usuário acesse a página de Reportar Issue")]
        public void DadoQueOUsuarioAcesseAPaginaDeReportarIssue()
        {
            homePage.NavigateToReportIssues();
        }
        
        [When(@"preencher todos os campos")]
        public void QuandoPreencherTodosOsCampos()
        {
            reportIssuePage.ReportNewIssue("[All Projects] Selenium", "always", "major", "high", "Windows 10 x64",
               "Automação", "Criado via Selenium", "Desafio Web", "Teste", "Sprint 1", "C:\\testdata.csv"); 
        }
        
        [When(@"clicar no botão de Submit Issue")]
        public void QuandoClicarNoBotaoDeSubmitIssue()
        {
            reportIssuePage.SubmitIssue();
        }

        [When(@"não preencher o campo de Summary")]
        public void QuandoNaoPreencherOCampoDeSummary()
        {
            reportIssuePage.CheckSummaryRequiredField();
        }

        [When(@"não selecionar o campo de Category")]
        public void QuandoNaoSelecionarOCampoDeCategory()
        {
            reportIssuePage.ReportBasicIssue(0, "Teste", "Teste");
        }

        [Then(@"o bug deverá ser criado com sucesso no banco de dados")]
        public void EntaoOBugDeveraSerCriadoComSucesso()
        {
            var bugDb  = BugsQueries.ListLastBugAdded();
            Assert.Equal("Automação", bugDb.Summary);
        }

        [Then(@"deverá retornar a mensagem de validação de campo obrigatório ""(.*)""")]
        public void EntaoDeveraRetornarOErroDeCampoObrigatorio(string expectedMessage)
        {
            string actualMessage = reportIssuePage.ReturnRequiredMessage();
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

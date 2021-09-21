using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Login
{
    [Binding]
    public class LoginSteps
    {
        private readonly HomePage homePage;
        private readonly LoginPage loginPage;

        public LoginSteps()
        {
            loginPage = new LoginPage();
            homePage = new HomePage();
        }

        [Given(@"que o usuário acesse a página de login")]
        public void DadoQueOUsuarioAcesseAPaginaDeLogin()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetBaseUrl());
        }

        [When(@"preencher com os dados incorretos de login e senha")]
        public void QuandoPreencherComOsDadosIncorretosDeLoginESenha()
        {
            loginPage.Login("teste", "12345");
        }

        [When(@"preencher com os dados corretos de login e senha")]
        public void QuandoPreencherComOsDadosCorretosDeLoginESenha()
        {
            loginPage.Login("administrator", "administrator");
        }

        [When(@"preencher com os dados")]
        public void QuandoPreencherComOsDados(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                loginPage.Login(row["username"], row["password"]);
            }
        }

        [When(@"não preencher com os dados de login")]
        public void QuandoNaoPreencherComOsDadosDeLogin()
        {
            loginPage.FillLogin("");
        }

        [When(@"não preencher com os dados de senha")]
        public void QuandoNaoPreencherComOsDadosDeSenha()
        {
            loginPage.FillLogin("teste");
            loginPage.FillPassword("");
        }

        [Then(@"o login deverá ser realizado com sucesso")]
        public void EntaoOLoginDeveraSerRealizadoComSucesso()
        {
            string actualUser = homePage.ReturnUser();
            Assert.Equal("administrator", actualUser);
        }

        [Then(@"deverá exibir a mensagem ""(.*)""")]
        public void EntaoDeveraExibirAMensagem(string expectedMessage)
        {
            string actuaMessage = loginPage.ReturnErrorMessage();
            Assert.Equal(expectedMessage, actuaMessage);
        }
    }
}
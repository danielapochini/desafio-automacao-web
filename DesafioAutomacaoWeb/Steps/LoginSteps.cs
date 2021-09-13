using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Xunit;

namespace DesafioAutomacaoWeb.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;

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

        [When(@"preencher com os dados corretos de login e senha")]
        public void QuandoPreencherComOsDadosCorretosDeLoginESenha()
        {
            loginPage.Login("administrator","administrator");
        }
         
        [Then(@"o login deverá ser realizado com sucesso")]
        public void EntaoOLoginDeveraSerRealizadoComSucesso()
        {
            var actualUser = homePage.ReturnUser();
            Assert.Equal("administrator", actualUser);
        }
    }
}

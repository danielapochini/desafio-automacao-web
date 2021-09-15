using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps
{
    [Binding]
    public class InviteUsersSteps
    {
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;
        private readonly ManageUserCreatePage manageUserCreatePage;

        private string createdUsername;
        private string createdAcessLevel;

        public InviteUsersSteps()
        {
            loginPage = new LoginPage();
            homePage = new HomePage();
            manageUserCreatePage = new ManageUserCreatePage();
        }

        [Given(@"que o usuário acesse o Mantis")]
        public void DadoQueOUsuarioAcesseOMantis()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetBaseUrl());
        }
        
        [Given(@"que o usuário acesse a página de criar novos usuários")]
        public void DadoQueOUsuarioAcesseAPaginaDeCriarNovosUsuarios()
        {
            homePage.NavigateToInviteUsers();
        }
        
        [When(@"efetuar o login como administrador")]
        public void QuandoEfetuarOLoginComoAdministrador()
        {
            loginPage.Login("administrator", "administrator");
        }
        
        [When(@"preencher os dados da nova conta")]
        public void QuandoPreencherOsDadosDaNovaConta()
        {
            manageUserCreatePage.CreateNewUser("pessoa.teste", "Teste", "teste@1teste1.com.br", "viewer");
        }

        [When(@"preencher os dados de (.*), (.*), (.*), (.*) da nova conta")]
        public void QuandoPreencherOsDadosDeDaNovaConta(string username, string realname, string email, string accessLevel)
        {
            createdUsername = username;
            createdAcessLevel = accessLevel;
            manageUserCreatePage.CreateNewUser(username, realname, email, accessLevel);
        }

        [When(@"preencher os dados utilizando um username que já exista")]
        public void QuandoPreencherOsDadosUtilizandoUmUsernameQueJaExista()
        {
            manageUserCreatePage.FillUsername("test.updater");
            manageUserCreatePage.SubmitForm();
        }

        [When(@"não preencher o campo de username")]
        public void QuandoNaoPreencherOCampoDeUsername()
        {
            manageUserCreatePage.FillUsername("");
            manageUserCreatePage.SubmitForm();
        }

        [When(@"preencher o campo de username com caracteres inválidos")]
        public void QuandoPreencherOCampoDeUsernameComCaracteresInvalidos()
        {
            manageUserCreatePage.FillUsername("_teste_");
            manageUserCreatePage.SubmitForm();
        }


        [Then(@"será direcionado a página inicial")]
        public void EntaoSeraDirecionadoAPaginaInicial()
        {
            Assert.Equal("http://host.docker.internal:8989/my_view_page.php", ObjectRepository.Driver.Url);
        }
        
        [Then(@"o usuário será criado com sucesso")]
        public void EntaoOUsuarioSeraCriadoComSucesso()
        {
            var expectedMessage = manageUserCreatePage.ReturnSuccessCode();
            Assert.Equal("Created user pessoa.teste with an access level of viewer", expectedMessage);
        }

        [Then(@"será exibida a mensagem de sucesso ""(.*)""")]
        public void EntaoSeraExibidaAMensagemDeSucesso(string p0)
        {
            var expectedMessage = manageUserCreatePage.ReturnSuccessCode();
            var actualMessage = $"Created user {createdUsername} with an access level of {createdAcessLevel}";
            Assert.Equal(expectedMessage, actualMessage);

        }


    }
}

using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Login;
using DesafioAutomacaoWeb.Pages.Manage.Users;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Users
{
    [Binding]
    public class CommonSteps
    {
        private readonly HomePage homePage;
        private readonly LoginPage loginPage;
        private readonly ManagePage managePage;
        private readonly ManageUsersPage manageUserPage;

        public CommonSteps()
        {
            loginPage = new LoginPage();
            homePage = new HomePage();
            managePage = new ManagePage();
            manageUserPage = new ManageUsersPage();
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

        [Given(@"selecione a aba Manage Users")]
        public void DadoSelecioneAAbaManageUsers()
        {
            managePage.NavigateToManageUsersTab();
        }

        [Given(@"que o usuário acesse a página de gerenciamento")]
        public void DadoQueOUsuarioAcesseAPaginaDeGerenciamento()
        {
            homePage.NavigateToManage();
        }

        [When(@"selecionar um usuário existente na lista")]
        public void QuandoSelecionarUmUsuarioExistenteNaLista()
        {
            Utils.Entities.UsersEntities userRandomDb = UsersQueries.ListRandomUsers();

            manageUserPage.ClickUserLink(userRandomDb.UserName);
        }

        [When(@"efetuar o login como administrador")]
        public void QuandoEfetuarOLoginComoAdministrador()
        {
            loginPage.DoLogin("administrator", "administrator");
        }

        [Then(@"deverá retornar o código de erro ""(.*)""")]
        public void EntaoDeveraRetornarOCodigoDeErro(string expectedCode)
        {
            string actualCode = manageUserPage.ReturnErrorCode();
            Assert.Equal(expectedCode, actualCode);
        }

        [Then(@"a mensagem ""(.*)""")]
        public void EntaoAMensagem(string expectedMessage)
        {
            string actualMessage = manageUserPage.ReturnErrorDescription();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"deverá retornar a mensagem ""(.*)""")]
        public void EntaoDeveraRetornarAMensagem(string expectedMessage)
        {
            string actualMessage = manageUserPage.ReturnSuccessCode();
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}
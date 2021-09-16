using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Manage.Users;
using DesafioAutomacaoWeb.Utils.Helpers;
using DesafioAutomacaoWeb.Utils.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Users
{
    [Binding]
    public class CommonSteps
    {
        private readonly LoginPage loginPage;
        private readonly HomePage homePage; 
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
            manageUserPage.ClickUserLink();
        }

        [When(@"efetuar o login como administrador")]
        public void QuandoEfetuarOLoginComoAdministrador()
        {
            loginPage.Login("administrator", "administrator");
        }

        [Then(@"deverá retornar o código de erro ""(.*)""")]
        public void EntaoDeveraRetornarOCodigoDeErro(string expectedCode)
        {
            var actualCode = manageUserPage.ReturnErrorCode();
            Assert.Equal(expectedCode, actualCode);
        }

        [Then(@"a mensagem ""(.*)""")]
        public void EntaoAMensagem(string expectedMessage)
        {
            var actualMessage = manageUserPage.ReturnErrorDescription();
            Assert.Equal(expectedMessage, actualMessage);
        }
         
        [Then(@"deverá retornar a mensagem ""(.*)""")]
        public void EntaoDeveraRetornarAMensagem(string expectedMessage)
        {
            var actualMessage = manageUserPage.ReturnSuccessCode();
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}

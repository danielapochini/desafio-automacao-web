using DesafioAutomacaoWeb.Pages.Manage.Users;
using DesafioAutomacaoWeb.Utils.Database.Entities;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using DesafioAutomacaoWeb.Utils.Settings;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Users
{
    [Binding]
    public class InviteUsersSteps
    { 
        private readonly ManageUserCreatePage manageUserCreatePage;
        private readonly ManageUsersPage manageUsersPage;

        private string createdUsername;
        private string createdAcessLevel;
        private string createdRealName;
        private string createdEmail;
        private bool createdEnabledStatus;
        private bool createdProtectedStatus;

        public InviteUsersSteps()
        { 
            manageUserCreatePage = new ManageUserCreatePage();
            manageUsersPage = new ManageUsersPage();
        }
         
        [When(@"preencher os dados da nova conta")]
        public void QuandoPreencherOsDadosDaNovaConta()
        { 
            createdUsername = "pessoa.teste"; 
            createdAcessLevel = "viewer";
            createdRealName = "Teste";
            createdEmail = "teste@1teste1.com.br";
            createdEnabledStatus = false;
            createdProtectedStatus = true;
            manageUserCreatePage.CreateNewUser(createdUsername, createdRealName, createdEmail, createdAcessLevel, createdEnabledStatus, createdProtectedStatus);
        }

        [When(@"preencher os dados de (.*), (.*), (.*), (.*), (.*), (.*) da nova conta")]
        public void QuandoPreencherOsDadosDeDaNovaConta(string username, string realname, string email, string accessLevel, bool enabled, bool _protected)
        {
            createdUsername = username;
            createdAcessLevel = accessLevel; 
            createdRealName = realname;
            createdEmail = email;
            createdEnabledStatus = enabled;
            createdProtectedStatus = _protected;
            manageUserCreatePage.CreateNewUser(username, realname, email, accessLevel, enabled, _protected);
        }

        [When(@"preencher os dados utilizando um username que já exista no banco de dados")]
        public void QuandoPreencherOsDadosUtilizandoUmUsernameQueJaExista()
        {
            var databaseUsername = UsersQueries.ListRandomUsers().UserName;
            manageUserCreatePage.FillOnlyUsername(databaseUsername); 
        }

        [When(@"não preencher o campo de username")]
        public void QuandoNaoPreencherOCampoDeUsername()
        {
            manageUserCreatePage.FillOnlyUsername(""); 
        }

        [When(@"preencher o campo de username com caracteres inválidos")]
        public void QuandoPreencherOCampoDeUsernameComCaracteresInvalidos()
        {
            manageUserCreatePage.FillOnlyUsername("teste*&"); 
        }


        [Then(@"será direcionado a página inicial")]
        public void EntaoSeraDirecionadoAPaginaInicial()
        {
            Assert.Equal("http://host.docker.internal:8989/my_view_page.php", ObjectRepository.Driver.Url);
        }

        [Then(@"será exibido a mensagem de sucesso")]
        public void EntaoSeraExibidoAMensagemDeSucesso()
        {
            var expectedMessage = manageUsersPage.ReturnSuccessCode();
            Assert.Equal("Created user pessoa.teste with an access level of viewer", expectedMessage);
        }


        [Then(@"o usuário será criado com sucesso no banco de dados")]
        public void EntaoOUsuarioSeraCriadoComSucesso()
        {
            var userBD = UsersQueries.ListLastUserCreated();
            Assert.Equal(createdUsername, userBD.UserName);
            Assert.Equal(createdRealName, userBD.RealName);
            Assert.Equal(createdAcessLevel, userBD.AccessLevel.ToString().ToLower());
            Assert.Equal(createdEnabledStatus, userBD.Enabled); 
            Assert.Equal(createdEmail, userBD.Email); 
        }

        [Then(@"será exibida a mensagem de sucesso ""(.*)""")]
        public void EntaoSeraExibidaAMensagemDeSucesso(string p0)
        {
            var expectedMessage = manageUsersPage.ReturnSuccessCode();
            var actualMessage = $"Created user {createdUsername} with an access level of {createdAcessLevel}";
            Assert.Equal(expectedMessage, actualMessage); 
        } 

    }
}

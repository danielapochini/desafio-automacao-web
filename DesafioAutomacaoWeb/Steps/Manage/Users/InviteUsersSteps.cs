using DesafioAutomacaoWeb.Pages.Manage.Users;
using DesafioAutomacaoWeb.Utils.Database.Enum;
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
        private UserAccessLevel createdAcessLevel;
        private string createdEmail;
        private bool createdEnabledStatus;
        private bool createdProtectedStatus;
        private string createdRealName;

        private string createdUsername;

        public InviteUsersSteps()
        {
            manageUserCreatePage = new ManageUserCreatePage();
            manageUsersPage = new ManageUsersPage();
        }

        [When(@"preencher os dados da nova conta")]
        public void QuandoPreencherOsDadosDaNovaConta()
        {
            createdUsername = "pessoa.teste";
            createdAcessLevel = UserAccessLevel.Viewer;
            createdRealName = "Teste";
            createdEmail = "teste@1teste1.com.br";
            createdEnabledStatus = false;
            createdProtectedStatus = true;
            manageUserCreatePage.CreateNewUser(createdUsername, createdRealName, createdEmail,
                createdAcessLevel.ToString().ToLower(), createdEnabledStatus, createdProtectedStatus);
        }

        [When(@"preencher os dados da nova conta via javascript")]
        public void QuandoPreencherOsDadosDaNovaContaViaJavascript()
        {
            createdUsername = "pessoa.teste.javascript";
            createdRealName = "Teste Js";
            createdEmail = "teste@js.com.br";
            createdEnabledStatus = true;
            createdProtectedStatus = false;
            createdAcessLevel = UserAccessLevel.Viewer;
            manageUserCreatePage.FillFieldsViaJavascript(createdUsername, createdRealName, createdEmail,
                createdAcessLevel, createdEnabledStatus, createdProtectedStatus);
        }

        [When(@"preencher os dados de (.*), (.*), (.*), (.*), (.*), (.*) da nova conta")]
        public void QuandoPreencherOsDadosDeDaNovaConta(string username, string realname, string email,
            string accessLevel, bool enabled, bool _protected)
        {
            UserAccessLevel parseEnumAcessLevel = (UserAccessLevel)Enum.Parse(typeof(UserAccessLevel), accessLevel, true);

            createdUsername = username;
            createdAcessLevel = parseEnumAcessLevel;
            createdRealName = realname;
            createdEmail = email;
            createdEnabledStatus = enabled;
            createdProtectedStatus = _protected;
            manageUserCreatePage.CreateNewUser(username, realname, email, accessLevel.ToLower(), enabled, _protected);
        }

        [When(@"preencher os dados utilizando um username que já exista no banco de dados")]
        public void QuandoPreencherOsDadosUtilizandoUmUsernameQueJaExista()
        {
            string databaseUsername = UsersQueries.ListRandomUsers().UserName;
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
            string expectedMessage = manageUsersPage.ReturnSuccessCode();
            Assert.Equal(
                $"Created user {createdUsername} with an access level of {createdAcessLevel.ToString().ToLower()}",
                expectedMessage);
        }

        [Then(@"o usuário será criado com sucesso no banco de dados")]
        public void EntaoOUsuarioSeraCriadoComSucesso()
        {
            Utils.Entities.UsersEntities userBD = UsersQueries.ListLastUserCreated();
            Assert.Equal(createdUsername, userBD.UserName);
            Assert.Equal(createdRealName, userBD.RealName);
            Assert.Equal(createdAcessLevel, userBD.AccessLevel);
            Assert.Equal(createdEnabledStatus, userBD.Enabled);
            Assert.Equal(createdEmail, userBD.Email);
        }

        [Then(@"será exibida a mensagem de sucesso ""(.*)""")]
        public void EntaoSeraExibidaAMensagemDeSucesso(string p0)
        {
            string expectedMessage = manageUsersPage.ReturnSuccessCode();
            string actualMessage =
                $"Created user {createdUsername} with an access level of {createdAcessLevel.ToString().ToLower()}";
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}
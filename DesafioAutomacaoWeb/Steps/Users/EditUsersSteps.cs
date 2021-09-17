using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Manage.Users;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Users
{
    [Binding]
    public class EditUsersSteps
    { 
        private readonly ManageUserEditPage manageUserEditPage;
        private string editedUsername;
        private string editedRealName;
        private string editedEmail;
        private string editedAccessLevel;

        public EditUsersSteps()
        { 
            manageUserEditPage = new ManageUserEditPage();
        }

        [When(@"alterar os campos com novos dados")]
        public void QuandoAlterarOsCamposComNovosDados()
        {
            editedUsername = "teste.username";
            editedRealName = "Nome Alterado";
            editedEmail = "email05@valid.com";
            editedAccessLevel = "viewer";
            manageUserEditPage.EditExistingUser(editedUsername, editedRealName, editedEmail, editedAccessLevel);
        }

        [When(@"apagar os dados do campo username")]
        public void QuandoApagarOsDadosDoCampoUsername()
        {
            manageUserEditPage.FillUsername("");
        }

        [When(@"alterar o username para um valor que já exista no banco de dados")]
        public void QuandoAlterarOUsernameParaUmValorQueJaExistaNoBancoDeDados()
        {
            var databaseUsername = UsersQueries.ListRandomUsers().UserName;
            manageUserEditPage.FillUsername(databaseUsername);
        }

        [Then(@"os dados serão atualizados com sucesso no banco de dados")]
        public void EntaoOsDadosSeraoAtualizadosComSucessoNoBancoDeDados()
        {
            var userUpdatedDb = UsersQueries.ListarInformacoesUsuario(editedUsername);
            Assert.Equal(editedUsername, userUpdatedDb.UserName);
            Assert.Equal(editedRealName, userUpdatedDb.RealName);
            Assert.Equal(editedEmail, userUpdatedDb.Email);
            Assert.Equal(editedAccessLevel, userUpdatedDb.AccessLevel.ToString().ToLower());
        } 
    }
}

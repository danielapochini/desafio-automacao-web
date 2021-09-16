using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Manage.Users;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using System;
using TechTalk.SpecFlow;

namespace DesafioAutomacaoWeb.Steps.Users
{
    [Binding]
    public class EditUsersSteps
    { 
        private readonly ManageUserEditPage manageUserEditPage;

        public EditUsersSteps()
        { 
            manageUserEditPage = new ManageUserEditPage();
        }

        [When(@"alterar os campos com novos dados")]
        public void QuandoAlterarOsCamposComNovosDados()
        {
            manageUserEditPage.EditExistingUser();
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


    }
}

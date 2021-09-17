using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Manage.Users;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace DesafioAutomacaoWeb.Steps.Users
{
    [Binding]
    public class DeleteUsersSteps
    {   
        private readonly ManageUsersPage manageUserPage;
        private readonly ManageUserEditPage manageUserEditPage;
        private string deletedUsername;

        public DeleteUsersSteps()
        {   
            manageUserPage = new ManageUsersPage();
            manageUserEditPage = new ManageUserEditPage(); 
        }
         
        [When(@"clicar no botão de Delete User")]
        public void QuandoClicarNoBotaoDeDeleteUser()
        {
            manageUserEditPage.ClickDeleteUserButton();
        }
         
        [When(@"selecionar ele próprio na lista")]
        public void QuandoSelecionarEleProprioNaLista()
        {
            manageUserPage.ClickAdminLink();
        }
         
        [Then(@"a operação deverá ser confirmada")]
        public void EntaoAOperacaoDeveraSerConfirmada()
        { 
            deletedUsername = manageUserEditPage.ReturnUsernameWarningBox();

            manageUserEditPage.ClickDeleteAccountButton();
        }
         
        [Then(@"o botão de Delete User não deverá ser exibido")]
        public void EntaoOBotaoDeDeleteUserNaoDeveraSerExibido()
        { 
            Assert.False(manageUserEditPage.CheckDeleteAccountButton());
        }

        [Then(@"os dados deverão ser removidos do banco de dados com sucesso")]
        public void EntaoOsDadosDeveraoSerRemovidosDoBancoDeDadosComSucesso()
        {
            var userUpdatedDb = UsersQueries.ListarInformacoesUsuario(deletedUsername);
            Assert.Null(userUpdatedDb);
        }
         
    }
}

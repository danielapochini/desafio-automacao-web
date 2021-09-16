using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Manage.Users;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Users
{
    [Binding]
    public class DeleteUsersSteps
    {   
        private readonly ManageUsersPage manageUserPage;
        private readonly ManageUserEditPage manageUserEditPage;

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
            manageUserEditPage.ClickDeleteAccountButton();
        }
         
        [Then(@"o botão de Delete User não deverá ser exibido")]
        public void EntaoOBotaoDeDeleteUserNaoDeveraSerExibido()
        { 
            Assert.False(manageUserEditPage.CheckDeleteAccountButton());
        }

    }
}

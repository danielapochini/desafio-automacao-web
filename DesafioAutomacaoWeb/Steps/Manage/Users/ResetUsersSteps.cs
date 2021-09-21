using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Manage.Users;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Users
{
    [Binding]
    public class ResetUsersSteps
    { 
        private readonly ManageUsersPage manageUserPage;
        private readonly ManageUserEditPage manageUserEditPage;

        public ResetUsersSteps()
        { 
            manageUserPage = new ManageUsersPage();
            manageUserEditPage = new ManageUserEditPage();
        }

        [When(@"clicar no botão de Reset Password")]
        public void QuandoClicarNoBotaoDeResetPassword()
        {
            manageUserEditPage.ClickResetPasswordButton();
        }
        
        [Then(@"deverá retornar ""(.*)""")]
        public void EntaoDeveraRetornar(string expectedMessage)
        {
            var actualMessage = manageUserPage.ReturnSuccessCode();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"o botão de Reset User não deverá ser exibido")]
        public void EntaoOBotaoDeResetUserNaoDeveraSerExibido()
        {
            Assert.False(manageUserEditPage.CheckResetPasswordButton());
        }

    }
}

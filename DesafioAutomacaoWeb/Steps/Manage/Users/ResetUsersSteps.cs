using DesafioAutomacaoWeb.Pages.Manage.Users;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Users
{
    [Binding]
    public class ResetUsersSteps
    {
        private readonly ManageUserEditPage manageUserEditPage;
        private readonly ManageUsersPage manageUserPage;

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
            string actualMessage = manageUserPage.ReturnSuccessCode();
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"o botão de Reset User não deverá ser exibido")]
        public void EntaoOBotaoDeResetUserNaoDeveraSerExibido()
        {
            Assert.False(manageUserEditPage.CheckResetPasswordButton());
        }
    }
}
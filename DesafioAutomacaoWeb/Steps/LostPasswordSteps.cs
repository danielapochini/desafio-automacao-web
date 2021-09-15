using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Utils.Settings;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps
{
    [Binding]
    public class LostPasswordSteps
    {
        private readonly LoginPage loginPage;
        private readonly LostPasswordPage lostPwdPage;

        public LostPasswordSteps()
        {
            loginPage = new LoginPage();
            lostPwdPage = new LostPasswordPage();
        }


        [When(@"preencher com os dados corretos de login")]
        public void QuandoPreencherComOsDadosCorretosDeLogin()
        {
            loginPage.FillLogin("test.updater");
        }
        
        [When(@"clicar no botão de Esqueci minha Senha")]
        public void QuandoClicarNoBotaoDeEsqueciMinhaSenha()
        {
            loginPage.LostPassword();
        }
        
        [When(@"preencher os dados de e-mail no formato inválido")]
        public void QuandoPreencherOsDadosDeE_MailNoFormatoInvalido()
        {
            lostPwdPage.FillEmail("31232");
        }

        [When(@"não preencher os dados de e-mail")]
        public void QuandoNaoPreencherOsDadosDeE_Mail()
        {
            lostPwdPage.FillEmail("");
        }


        [When(@"preencher os dados de e-mail corretamente")]
        public void QuandoPreencherOsDadosDeE_MailCorretamente()
        {
            lostPwdPage.FillEmail("email01@valid.com");
        }

        [When(@"preencher os dados com um e-mail que não esteja atribuido ao usuário")]
        public void QuandoPreencherOsDadosComUmE_MailQueNaoEstejaAtribuidoAoUsuario()
        {
            lostPwdPage.FillEmail("email02@valid.com");
        }

        [When(@"apagar os dados do campo de username")]
        public void QuandoApagarOsDadosDoCampoDeUsername()
        {
            lostPwdPage.ClearUsername();
        }


        [Then(@"deverá retornar o código de erro ""(.*)""")]
        public void EntaoDeveraRetornarOCodigoDeErro(string expectedCode)
        {
            var actualCode = lostPwdPage.ReturnErrorCode();
            Assert.Equal(expectedCode, actualCode);
        }
        
        [Then(@"a mensagem ""(.*)""")]
        public void EntaoAMensagem(string expectedMessage)
        {
            var actualMessage = lostPwdPage.ReturnErrorDescription();
            Assert.Equal(expectedMessage, actualMessage);
        }


        [Then(@"deverá retornar para a página de login")]
        public void EntaoDeveraRetornarParaAPaginaDeLogin()
        {
            Assert.Equal("http://kubernetes.docker.internal:8989/login_page.php?return=lost_pwd.php", ObjectRepository.Driver.Url);
        }

    }
}

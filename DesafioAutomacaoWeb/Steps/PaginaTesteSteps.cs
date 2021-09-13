using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace DesafioAutomacaoWeb.Steps
{
    [Binding]
    public class PaginaTesteSteps
    {
        [Given(@"que o usuário informe os dados de login")]
        public void DadoQueOUsuarioInformeOsDadosDeLogin()
        {
            ObjectRepository.Driver.Navigate().GoToUrl("https://br.yahoo.com/");
        }
        
        [When(@"clicar no botão para logar")]
        public void QuandoClicarNoBotaoParaLogar()
        {
            ObjectRepository.Driver.FindElement(By.XPath("//input[@id='ybar-sbq']")).SendKeys("#C");
        }
        
        [Then(@"seu acesso deverá ser permitido")]
        public void EntaoSeuAcessoDeveraSerPermitido()
        {
            ObjectRepository.Driver.FindElement(By.CssSelector("#ybar-search")).Submit();
        }
    }
}

using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Manage.Tags;
using DesafioAutomacaoWeb.Utils.Drivers;
using DesafioAutomacaoWeb.Utils.Settings;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps.Tags
{
    [Binding]
    public class CreateTagsSteps
    {
        private readonly ManagePage managePage;
        private readonly ManageTagsPage manageTags;
        private readonly string tagDescription = "Tag Script Automação";
        private readonly string tagName = "Teste Tag";

        public CreateTagsSteps()
        {
            managePage = new ManagePage();
            manageTags = new ManageTagsPage();
        }

        [Given(@"selecione a aba Manage Tags")]
        public void DadoSelecioneAAbaManageTags()
        {
            managePage.NavigateToManageTagsTab();
        }

        [When(@"preencher os campos")]
        public void QuandoPreencherOsCampos()
        {
            manageTags.FillTagFields(tagName, tagDescription);
        }

        [When(@"clicar no botão de Create Tag")]
        public void QuandoClicarNoBotaoDeCreateTag()
        {
            manageTags.ClickCreateTagButton();
        }

        [When(@"não preencher o campo de nome obrigatório")]
        public void QuandoNaoPreencherOCampoDeNomeObrigatorio()
        {
            manageTags.CheckRequiredField();
        }

        [Then(@"a tag deverá ser criada com sucesso")]
        public void EntaoATagDeveraSerCriadaComSucesso()
        {
            Assert.True(manageTags.CheckTagTable(tagName));
        }

        [Then(@"deverá retornar a mensagem obrigatória ""(.*)""")]
        public void EntaoDeveraRetornarAMensagemObrigatoria(string expectedMessage)
        {
            string actualMessage = manageTags.ReturnRequiredMessage();
            if (ObjectRepository.Config.GetBrowser() == BrowserType.Firefox &&
                ObjectRepository.Config.GetRemoteDriverExecution() == "false")
            {
                Assert.Equal("Preencha este campo.", actualMessage);
            }
            else
            {
                Assert.Equal(expectedMessage, actualMessage);
            }
        }
    }
}
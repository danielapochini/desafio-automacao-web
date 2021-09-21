using DesafioAutomacaoWeb.Pages;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioAutomacaoWeb.Steps
{ 
    [Binding]
    public class ManagePermissionsSteps
    {
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;
        private readonly ManagePage managePage;
        private readonly ViewIssuesPage viewIssuesPage;
        private readonly ReportIssuePage reportIssuePage;

        public ManagePermissionsSteps()
        {
            loginPage = new LoginPage();
            homePage = new HomePage();
            managePage = new ManagePage();
            viewIssuesPage = new ViewIssuesPage();
            reportIssuePage = new ReportIssuePage();
        }
         
        [When(@"efetuar o login como manager")]
        public void QuandoEfetuarOLoginComoManager()
        {
            loginPage.Login("test.manager", "teste123");
        }

        [When(@"efetuar o login como developer")]
        public void QuandoEfetuarOLoginComoDeveloper()
        {
            loginPage.Login("test.developer", "teste123");
        }

        [When(@"efetuar o login como updater")]
        public void QuandoEfetuarOLoginComoUpdater()
        {
            loginPage.Login("test.updater", "teste123");
        }

        [When(@"efetuar o login como reporter")]
        public void QuandoEfetuarOLoginComoReporter()
        {
            loginPage.Login("test.reporter", "teste123");
        }

        [When(@"efetuar o login como viewer")]
        public void QuandoEfetuarOLoginComoViewer()
        {
            loginPage.Login("test.viewer", "teste123");
        }


        [When(@"acessar a página de gerenciamento")]
        public void QuandoAcessarAPaginaDeGerenciamento()
        {
            homePage.NavigateToManage();
        }
         
        [Then(@"possuirá acesso completo ao gerenciamento do sistema")]
        public void EntaoPossuiraAcessoCompletoAoGerenciamentoDoSistema()
        {
            Assert.True(managePage.CheckManageUsersTabDisplayed());
            Assert.True(managePage.CheckManageProjectsTabDisplayed());
            Assert.True(managePage.CheckManageTagsTabDisplayed());
            Assert.True(managePage.CheckManageCustomFieldsTabDisplayed());
            Assert.True(managePage.CheckManageGlobalProfilesTabDisplayed());
            Assert.True(managePage.CheckManagePluginsTabDisplayed());
            Assert.True(managePage.CheckManageConfigurationTabDisplayed());
        }

        [Then(@"não possuirá acesso completo ao gerenciamento do sistema")]
        public void EntaoNaoPossuiraAcessoCompletoAoGerenciamentoDoSistema()
        {
            Assert.False(managePage.CheckManagePluginsTabDisplayed());
            Assert.False(managePage.CheckManageCustomFieldsTabDisplayed());
            Assert.False(managePage.CheckManageUsersTabDisplayed());
        }
         
        [Then(@"possuirá acesso a area de gerenciamento de projetos")]
        public void EntaoPossuiraAcessoAAreaDeGerenciamentoDeProjetos()
        {
            Assert.True(managePage.CheckManageProjectsTabDisplayed());
            Assert.True(managePage.CheckManageTagsTabDisplayed());
            Assert.True(managePage.CheckManageGlobalProfilesTabDisplayed());
            Assert.True(managePage.CheckManageConfigurationTabDisplayed());
        } 

        [Then(@"possuirá acesso para assignar tarefas")]
        public void EntaoPossuiraAcessoParaAssignarTarefas()
        {
            homePage.NavigateToViewIssues();
            viewIssuesPage.AssignBug();  
            Assert.Equal("test.developer", viewIssuesPage.ReturnAssigneeName());
            Assert.Equal("test.developer", viewIssuesPage.ReturnUserInfo());
        }
         
        [Then(@"possuirá acesso para atualizar as tarefas")]
        public void EntaoPossuiraAcessoParaAtualizarAsTarefas()
        {
            homePage.NavigateToViewIssues();
            viewIssuesPage.UpdateBug(); 
            Assert.Equal("feature", viewIssuesPage.ReturnSeverityValue());
            Assert.Equal("test.updater", viewIssuesPage.ReturnUserInfo());
        }

        [Then(@"possuirá acesso para reportar tarefas")]
        public void EntaoPossuiraAcessoParaReportarTarefas()
        {
            homePage.NavigateToReportIssues();
            reportIssuePage.ReportNewIssue("[All Projects] Selenium", "always", "major", "high", "Windows 10 x64", "Automação", "Criado via Selenium", "Desafio Web", "Teste");
            Assert.Equal("test.reporter", reportIssuePage.ReturnUserInfo());
        }

        [Then(@"possuirá acesso apenas para visualizar tarefas")]
        public void EntaoPossuiraAcessoApenasParaVisualizarTarefas()
        {
            homePage.NavigateToViewIssues();
            viewIssuesPage.ViewBug();
            Assert.Equal("test.viewer", viewIssuesPage.ReturnUserInfo());
        } 

    }
}

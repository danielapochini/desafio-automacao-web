using DesafioAutomacaoWeb.Pages;
using DesafioAutomacaoWeb.Pages.Manage.Projects;
using DesafioAutomacaoWeb.Utils.Database.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DesafioAutomacaoWeb.Steps.Projects
{
    [Binding]
    public class CommonProjectSteps
    {
        private readonly ManagePage managePage; 
        private readonly ManageProjectsPage projectPage;

        public CommonProjectSteps()
        {
            managePage = new ManagePage();
            projectPage = new ManageProjectsPage();
        }

        [Given(@"selecione a aba Manage Projects")]
        public void DadoSelecioneAAbaManageProjects()
        {
            managePage.NavigateToManageProjectsTab();
        }

        [When(@"selecionar um projeto existente na lista")]
        public void QuandoSelecionarUmProjetoExistenteNaLista()
        {
            var selectRandomProject = ProjectsQueries.ListRandomProjects();
            projectPage.ClickProjectLink(selectRandomProject.Name);
        }
    }
}

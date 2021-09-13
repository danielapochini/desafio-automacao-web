using DesafioAutomacaoWeb.Utils.Settings;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Bases
{
    public class PageBase
    { 

        public PageBase()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

        public string PageTitle
        {
            get { return (ObjectRepository.Driver.Title); }
        }
    }
}

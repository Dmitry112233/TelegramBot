using OpenQA.Selenium.Support.PageObjects;
using TrainingProject.DriverPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TrainingProject.Pages
{
    class HomePage
    {
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#page-17 > header > h1")]
        private IWebElement Headline { get; }

    }
}


using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TrainingProject
{
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Initialize()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("http://testing.todvachev.com/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        
        [TearDown]
        public void Quite()
        {
            Driver.Quit();
        }
    }
}
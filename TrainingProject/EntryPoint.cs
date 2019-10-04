
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using TrainingProject.Data;
using TrainingProject.DriverPackage;
using TrainingProject.Pages;
using TrainingProject.Pages.Elements;

class EntryPoint
{
    static void Main()
    {
        Menu menu = new Menu();

        Driver.driver.Navigate().GoToUrl("http://testing.todvachev.com/");

        menu.Selectors.Click();

    }

    [SetUp]
    public void initialize() {
        Driver.driver = new ChromeDriver();
        Driver.driver.Navigate().GoToUrl("http://testing.todvachev.com/");
    }

    [Test]
    public void TestOne() {
        HomePage homePage = new HomePage();

        Screenshot homePageScreen = ((ITakesScreenshot)Driver.driver).GetScreenshot();

        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\screenshots");

        string fileName = string.Format(AppDomain.CurrentDomain.BaseDirectory) +
                      @"\screenshots\screen" + "_" +
                      DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") + ".png";

        homePageScreen.SaveAsFile(fileName, ScreenshotImageFormat.Png);

        Assert.AreEqual(TestData.Titles.HomePageTitle, "Introduction");
    }

    [TearDown]
    public void Quite() {
        Driver.driver.Quit();
    }
}


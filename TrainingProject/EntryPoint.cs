using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using TrainingProject.Dao;
using TrainingProject.Dao.BookmakerPackage;
using TrainingProject.Data;
using TrainingProject.Pages;

namespace TrainingProject
{
    [Parallelizable]
    class EntryPoint : BaseTest
    {
        public static void Main()
        {
        }

        [Test]
        public void TestOne()
        {
            HomePage homePage = new HomePage(Driver);

            Screenshot homePageScreen = ((ITakesScreenshot) Driver).GetScreenshot();

            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\screenshots");

            string fileName = string.Format(AppDomain.CurrentDomain.BaseDirectory) +
                              @"\screenshots\screen" + "_" +
                              DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") + ".png";

            homePageScreen.SaveAsFile(fileName, ScreenshotImageFormat.Png);

            Assert.AreEqual(TestData.Titles.HomePageTitle, "Introduction");
        }
        
        [Test]
        public void TestDataBase()
        {
            List<Bookmaker> bookmakers = DaoFactory.getBookmakerMySqlDao().getAllBookmakers();
            foreach (Bookmaker bookmaker in bookmakers)
            {
                Console.WriteLine(bookmaker.Name);
                Console.WriteLine(bookmaker.Link);
            }
        }
        
        [Test]
        public void EntityFrameTest()
        {
            using(BookmakerContext db = new BookmakerContext())
            {
                // получаем объекты из бд и выводим на консоль
                var bookmakers = db.Bookmakers;
                Console.WriteLine("Список объектов:");
                foreach(Bookmaker b in bookmakers)
                {
                    Console.WriteLine(b.Name);
                }
            }
        }
    }
}
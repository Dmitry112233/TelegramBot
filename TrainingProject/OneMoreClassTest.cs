using System;
using System.IO;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using OpenQA.Selenium;
using TrainingProject.Data;
using TrainingProject.DataBase;
using TrainingProject.Pages;

namespace TrainingProject
{
    [Parallelizable]
    public class OneMoreClassTest : BaseTest
    {
        [Test]
        public void TestTwo()
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
        public void TestDataBaseTwo()
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM BOOKMAKERS";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string bookmakerName = reader.GetString("Name");
                    Console.WriteLine(bookmakerName);
                }
                dbCon.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingProject.Data
{
    class TestData
    {
        public static String BaseUrl = "http://testing.todvachev.com";

        public static class Credentials
        {
            public static class Valid
            {

                public static String login = "asd";
                public static String email = "asd";
                public static String password = "asd";
            }

            public static class Invalid
            {

            }

        }

        public static class Titles
        {
            public static String HomePageTitle = "Introduction";
        }

    }
}

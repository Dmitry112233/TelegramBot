using System;

namespace TrainingProject.Dao.Bookmaker
{
    public class Bookmaker
    {
        private string name;
        private string link;

        public string Name
        {
            get
            {
                return name;
            }
 
             set
            {
                name = value;
            }
        }
        public string Link 
        {
            get
            {
                return link;
            }
 
             set
            {
                link = value;
            }
        }
    }
}
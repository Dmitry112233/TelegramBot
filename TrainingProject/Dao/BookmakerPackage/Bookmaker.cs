using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingProject.Dao.BookmakerPackage
{
    [Table("BOOKMAKERS")]
    public class Bookmaker
    {
        private string name;
        private string link;


        public int Id { get; set; }

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
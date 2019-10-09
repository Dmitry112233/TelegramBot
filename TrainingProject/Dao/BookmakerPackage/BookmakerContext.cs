using System;
using System.Collections.Generic;
using System.Data.Entity;
using MySql.Data.Entity;

namespace TrainingProject.Dao.BookmakerPackage
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BookmakerContext : DbContext
    {
        public BookmakerContext()
            : base("DbConnection")
        {
        }

        public DbSet<Bookmaker> Bookmakers { get; set; }
    }
}
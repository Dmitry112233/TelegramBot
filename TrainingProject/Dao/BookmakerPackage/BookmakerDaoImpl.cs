using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TrainingProject.DataBase;

namespace TrainingProject.Dao.BookmakerPackage
{
    public class BookmakerDaoImpl : IBookmakerDao
    {

        public const string GET_ALL_BOOKMAKER = "SELECT * FROM BOOKMAKERS";

        public List<Bookmaker> getAllBookmakers()
        {
            List<Bookmaker> bookmakers = new List<Bookmaker>();
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand(GET_ALL_BOOKMAKER, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Bookmaker bookmaker = new Bookmaker();
                    bookmaker.Name = reader.GetString("Name");
                    bookmaker.Link = reader.GetString("Link");
                    bookmakers.Add(bookmaker);
                }
                dbCon.Close();
                return bookmakers;
            }
            throw new System.Exception("Problems with connection");
        }
    }
}
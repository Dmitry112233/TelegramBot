using TrainingProject.Dao.Bookmaker;

namespace TrainingProject.Dao
{
    public class DaoFactory
    {
        public static BookmakerDaoImpl getBookmakerMySqlDao()
        {
            return new BookmakerDaoImpl();
        }
    }
}
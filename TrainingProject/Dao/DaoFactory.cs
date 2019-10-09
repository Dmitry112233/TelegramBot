using TrainingProject.Dao.BookmakerPackage;

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
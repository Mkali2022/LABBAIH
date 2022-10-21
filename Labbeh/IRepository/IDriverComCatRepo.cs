using Labbeh.Models;

namespace Labbeh.IRepository
{
    public interface IDriverComCatRepo
    {
        List<DriversCompaniesCat> GitAllDriverComCat();
        public DriversCompaniesCat GitDriverComCatByID(int id);
        bool Create(DriversCompaniesCat driversCompaniesCat);
        bool Edit(DriversCompaniesCat driversCompaniesCat);
        //bool Delete(DriversCompaniesCat driversCompaniesCat);
        public bool IsDriversCompaniesCatExists(string name);
        public string GetErrors();

    }
}

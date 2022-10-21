using Labbeh.Models;

namespace Labbeh.IRepository
{
    public interface IDriverCompanyRepo
    {
        List<DriverCompany> GitAllDriverCom();
        public DriverCompany GitDriverComByID(int id);
        bool Create(DriverCompany driversCompany);
        bool Edit(DriverCompany driversCompany);
        //bool Delete(DriverCompany driversCompany);
        public bool IsDriversCompanyExists(string name);
        public string GetErrors();
    }
}

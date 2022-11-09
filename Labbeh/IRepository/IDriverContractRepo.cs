using Labbeh.Models;

namespace Labbeh.IRepository
{
    public interface IDriverContractRepo
    {
        List<DriversContract> GitAllDriver();
        public DriversContract GitDriversContractById(int id);
        bool Create(DriversContract driversContract);
        bool Edit(DriversContract driversContract);
        public string GetErrors();
    }
}

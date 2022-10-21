using Labbeh.Models;

namespace Labbeh.IRepository
{
    public interface IDriverCompContractRepo
    {
        List<DriverCompContract> GitAllDriverCompContract();
        public DriverCompContract GitDriverCompContractByID(int id);
        bool Create(DriverCompContract driverCompContract);
        bool Edit(DriverCompContract driverCompContract);
        public bool IsDriversCompContractExists(int driverCom);
        public string GetErrors();
    }
}

using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;

namespace Labbeh.Repository
{
    public class DriverContractRepo : IDriverContractRepo
    {
        private readonly DBContext context;
        private string _errors = "";
        public DriverContractRepo(DBContext context)
        {
            this.context = context;
        }

        public bool Create(DriversContract driversContract)
        {
            throw new NotImplementedException();
        }

        public bool Edit(DriversContract driversContract)
        {
            throw new NotImplementedException();
        }

        public string GetErrors()
        {
            throw new NotImplementedException();
        }

        public List<DriversContract> GitAllDriver()
        {
            throw new NotImplementedException();
        }

        public DriversContract GitDriversContractById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

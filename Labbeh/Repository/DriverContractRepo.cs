using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.ViewModel;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                    context.DriversContracts.Add(driversContract);
                    context.SaveChanges();
                    return true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public bool Edit(DriversContract driversContract)
        {
            try
            {
                    context.DriversContracts.Attach(driversContract);
                    context.Entry(driversContract).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
            }
            catch (Exception ex)
            {
                _errors = "Updatej Failed - sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public string GetErrors()
        {
            return _errors;
        }

        public List<DriversContract> GitAllDriverContract()
        {
            var driversContract = context.DriversContracts.ToList();
            return driversContract;
        }

        public DriversContract GitDriversContractById(int id)
        {
            DriversContract driversContract = context.DriversContracts.Where(x => x.ID == id).FirstOrDefault();
            return driversContract;
        }
    }
}

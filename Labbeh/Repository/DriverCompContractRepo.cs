using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Microsoft.EntityFrameworkCore;

namespace Labbeh.Repository
{
    public class DriverCompContractRepo : IDriverCompContractRepo
    {
        private readonly DriverCompContract driverCompContract;
        private readonly DBContext context;
        private string _errors = "";
        public DriverCompContractRepo(DBContext context)
        {
            this.context = context;
        }
        public bool Create(DriverCompContract driverCompContract)
        {
            try
            {
                if (Test.PhoneNumber(driverCompContract.Phone1) && (Test.PhoneNumber(driverCompContract.Phone2)))
                {
                    if (IsDriversCompContractExists(driverCompContract.ID)) return false;
                    //if (IsValid(driverCompContract)) return false;
                    context.DriverCompContracts.Add(driverCompContract);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
            
        }

        public bool Edit(DriverCompContract driverCompContract)
        {
            try
            {
                if (Test.PhoneNumber(driverCompContract.Phone1) && (Test.PhoneNumber(driverCompContract.Phone2)))
                {
                    if (IsDriversCompContractExists(driverCompContract.ID)) return false;
                    context.DriverCompContracts.Attach(driverCompContract);
                    context.Entry(driverCompContract).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
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

        public List<DriverCompContract> GitAllDriverCompContract()
        {
            var companyCon = context.DriverCompContracts.ToList();
            return companyCon.ToList();
        }

        public DriverCompContract GitDriverCompContractByID(int id)
        {
            DriverCompContract companyCon = context.DriverCompContracts.Where(x => x.ID == id).FirstOrDefault();
            return companyCon;
        }

        public bool IsDriversCompContractExists(int drivercompId)
        {
            int ct = context.DriverCompContracts.Where(x => x.DriverCompID == drivercompId).Count();
            if (ct > 0)
            {
                _errors = "Driver" + drivercompId + " Exists Alredy";
                return true;
            }
            else
            {
                return false;
            };
        }
        private bool IsValid(DriverCompContract driverCompContract)
        {
            if (driverCompContract.Phone1.Length < 10 || driverCompContract.Phone1 == null)//phone must add many of validation
            {
                _errors = "...";
                return false;

            }
            return true;

        }
    }
}

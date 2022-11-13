using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Microsoft.EntityFrameworkCore;

namespace Labbeh.Repository
{
    public class DriverRepo : IDriverRepo
    {
        private readonly DBContext context;
        private string _errors = "";
        public DriverRepo(DBContext context)
        {
            this.context = context;
        }
        public bool Create(Drivers drivers)
        {
            try
            {
                //if (IsDriversExists(drivers.DriverName)) { return false; }
                if (Test.PhoneNumber(drivers.DriverPhone))
                {
                    context.Drivers.Add(drivers);
                    context.SaveChanges();
                    return true;
                }
                { return false; }
            }
            catch (Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public bool Edit(Drivers drivers)
        {
            try
            {
                if (Test.PhoneNumber(drivers.DriverPhone))
                {
                    context.Drivers.Attach(drivers);
                    context.Entry(drivers).State = EntityState.Modified;
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

        public List<Drivers> GitAllDriver()
        {
            var drivers = context.Drivers.ToList();
            return drivers;
        }

        public Drivers GitDriver(int id)
        {
            Drivers driver = context.Drivers.Where(x => x.ID == id).FirstOrDefault();
            return driver;
        }
    }
}

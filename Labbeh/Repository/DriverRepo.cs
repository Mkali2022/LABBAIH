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
                if (IsDriversExists(drivers.DriverName)) return false;
                context.Drivers.Add(drivers);
                context.SaveChanges();
                return true;
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
                if (IsDriversExists(drivers.DriverName)) return false;
                context.Drivers.Attach(drivers);
                context.Entry(drivers).State = EntityState.Modified;
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

        public List<Drivers> GitAllDriver()
        {
            var driver = context.Drivers.ToList();
            return driver.ToList();
        }

        public Drivers GitDriver(int id)
        {
            Drivers driver = context.Drivers.Where(x => x.ID == id).FirstOrDefault();
            return driver;
        }

        public bool IsDriversExists(string name)
        {
            int ct = context.Drivers.Where(x => x.DriverName == name).Count();
            if (ct > 0)
            {
                _errors = "Name" + name + " Exists Alredy";
                return true;
            }
            else
            {
                return false;
            };
        }
    }
}

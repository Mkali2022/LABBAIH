using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Microsoft.EntityFrameworkCore;

namespace Labbeh.Repository
{
    public class DriverVehicleRepo: IDriverVehicleseRepo
    {
        private readonly DBContext context;
        private string _errors = "";
        public DriverVehicleRepo(DBContext context)
        {
            this.context = context;
        }
        public bool Create(DriverVehicle driverVehicle)
        {
            try
            {
               
                context.DriverVehicles.Add(driverVehicle);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }
        public bool Edit(DriverVehicle driverVehicle)
        {
            try
            {
                
                context.DriverVehicles.Attach(driverVehicle);
                context.Entry(driverVehicle).State = EntityState.Modified;
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
        public List<DriverVehicle> GitAllDriverVehicle()
        {
            var driverVehicle = context.DriverVehicles.ToList();
            return driverVehicle.ToList();
        }
        public DriverVehicle GitDriverVehicleID(int id)
        {
            DriverVehicle driverVehicles = context.DriverVehicles.Where(x => x.ID == id).FirstOrDefault();
            return driverVehicles;
        }

       
    }
}

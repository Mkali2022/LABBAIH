using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Microsoft.EntityFrameworkCore;

namespace Labbeh.Repository
{
    public class VehiclesRepo : IVehiclesRepo
    {
        private readonly DBContext context;
        private string _errors = "";
        public VehiclesRepo(DBContext context)
        {
            this.context = context;
        }
        public bool Create(Vehicles vehicles)
        {
            try
            {
                if (IsVehiclesExists(vehicles.VehicleName)) { return false; } 

                if (IsValid(vehicles)) { return false; }

                context.Vehicles.Add(vehicles);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public bool Edit(Vehicles vehicles)
        {
            try
            {
                if (IsValid(vehicles)) { return false; }
                context.Vehicles.Attach(vehicles);
                context.Entry(vehicles).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Update Failed - sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public string GetErrors()
        {
            return _errors;
        }

        public List<Vehicles> GitAllVehicles()
        {

            var vehicles = context.Vehicles.ToList();
            return vehicles;
        }

        public Vehicles GitVehiclesByID(int id)
        {
            Vehicles vehicles = context.Vehicles.Where(x => x.ID == id).FirstOrDefault();
            return vehicles;
        }

        public bool IsVehiclesExists(string name)
        {
            int ct = context.Vehicles.Where(x => x.VehicleName == name).Count();
            if (ct > 0)
            {
                _errors = "Name" + name + " Exists Alredy";
                return true;
            }
            else
            {
                return false;
            }


        }

        private bool IsValid(Vehicles vehicles)
        {
            if (vehicles.VehicleName.Length < 3 || vehicles.VehicleName == null)
            {
                _errors = "VehiclesName Must be atleast 3 Characters";
                return true;

            }
            return false;

        }
    }
}

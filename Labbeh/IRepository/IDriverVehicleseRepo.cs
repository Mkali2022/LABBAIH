using Labbeh.Models;

namespace Labbeh.IRepository
{
    public interface IDriverVehicleseRepo
    {
        List<DriverVehicle> GitAllDriverVehicle();
        public DriverVehicle GitDriverVehicleID(int id);
        bool Create(DriverVehicle driverVehicle);
        bool Edit(DriverVehicle driverVehicle);
        //bool Delete(DriverVehicle driverVehicle);
        //public bool IsDriverVehicleExists(string name);
        public string GetErrors();
    }
}

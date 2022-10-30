using Labbeh.Models;

namespace Labbeh.IRepository
{
    public interface IVehiclesRepo
    {
        List<Vehicles> GitAllVehicles();
        public Vehicles GitVehiclesByID(int id);
        bool Create(Vehicles vehicles);
        bool Edit(Vehicles vehicles);
        //bool Delete(Vehicles vehicles);
        public bool IsVehiclesExists(string name);
        public string GetErrors();
    }
}

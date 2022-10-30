using Labbeh.Models;

namespace Labbeh.ViewModel
{
    public class DriverVehiclesVm
    {
        public List<Drivers> drivers { get; set; }
        public List<Vehicles> vehicles { get; set; }
        public int ID { set; get; }
        public int Code { set; get; }
        public int DriverID { set; get; }
        public int VehicleID { get; set; }
        public string? UsingDate { get; set; }

    }
}

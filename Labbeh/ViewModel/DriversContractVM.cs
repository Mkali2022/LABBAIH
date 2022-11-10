using Labbeh.Models;

namespace Labbeh.ViewModel
{
    public class DriversContractVM
    {
        public List<Drivers> drivers { get; set; }
        public int ID { get; set; }
        public int Code { get; set; }
        public string? ContractDetaill { get; set; }
        public string? DateFrom { get; set; }
        public string? DateTo { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }

    }
}

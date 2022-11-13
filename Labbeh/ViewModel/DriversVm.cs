using Labbeh.Models;

namespace Labbeh.ViewModel
{
    public class DriversVm
    {
        public List<DriversCompaniesCat> driversCompaniesCats { get; set; }
        public List<DriverCompany> driverCompanies { get; set; }
        public int ID { get; set; }
        public string? DriverCode { get; set; } = "";
        public string? DriverName { get; set; } = "";
        public string? DriverPhone { get; set; } = "";
        public string LatitudeDefault { get; set; }
        public string LongtitudeDefault { get; set; }
        public string DriverEmail { get; set; }
        public int DriverTTypeId { get; set; }
        public int DriverCompanyId { get; set; }
        //public int Status { get; set; }

    }
}

using Labbeh.Models;

namespace Labbeh.ViewModel
{
    public class CompanyContractcs
    {
        public List<DriverCompany> driverCompanies { get; set; }
        public int Code { get; set; }
        public string OwnerName { get; set; }
        public string OrganizationAddress { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public int DriverCompID { get; set; }

    }
}

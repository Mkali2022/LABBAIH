using Labbeh.Models;

namespace Labbeh.ViewModel
{
    public class CompanyAll
    {
        public List<DriverCompany> driverCompanies { get; set; }
        public int CodeCom { get; set; }
        public string OwnerName { get; set; }
        public string OrganizationAddress { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string Phonecom1 { get; set; }
        public string PhoneCom2 { get; set; }
        public int DriverCompID { get; set; }



        public List<DriversCompaniesCat> driversCompaniesCats { get; set; }
        public int ID { get; set; }
        public int CodeCon { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string PhoneCon1 { get; set; }
        public string PhoneCon2 { get; set; }
        public int DriverCompCatID { get; set; }




        public int IDCat { get; set; }
        public int CodeCat { get; set; }
        public string? CompaniesType { get; set; }

    }
}

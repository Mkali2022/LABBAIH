using Labbeh.Models;

namespace Labbeh.ViewModel
{
    public class CompanyCategory
    {
        public List<DriversCompaniesCat> driversCompaniesCats{ get; set; }
        public int ID { get; set; }
        public int Code { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public int DriverCompCatID { get; set; }

    }
}

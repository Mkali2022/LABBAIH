using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("DriversCompany", Schema = "LabbehDB")]
    public class DriverCompany
    { 

        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]

        [Column(TypeName = "int")]
        public int Code { get; set; }

        [Display(Name = "Company Name")]

        [Column(TypeName = "nvarchar(max)")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Address")]

        [Column(TypeName = "nvarchar(max)")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Phone No1")]

        [Column(TypeName = "nvarchar(max)")]
        public string Phone1 { get; set; }
        [Display(Name = "Phone No2")]

        [Column(TypeName = "nvarchar(max)")]
        public string Phone2 { get; set; }

        public int DriverCompCatID { get; set; }
        [ForeignKey("DriverCompCatID")]
        public DriversCompaniesCat? DriversCompaniesCats { get; set; }

    }
}

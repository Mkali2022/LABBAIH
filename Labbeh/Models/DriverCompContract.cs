using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{

    [Table("DriversCompContract", Schema = "LabbehDB")]

    public class DriverCompContract
    {
        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]

        [Column(TypeName = "int")]
        public int Code { get; set; }
        [Display(Name = "Owner Name")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string OwnerName { get; set; }
        [Display(Name = "Organization Address")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string OrganizationAddress { get; set; }
        [Display(Name = "Start Date")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string DateFrom { get; set; }
        [Display(Name = "End Date")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string DateTo { get; set; }
        [Display(Name = "Phone No1")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string Phone1 { get; set; }
        [Display(Name = "Phone No2")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string Phone2 { get; set; }
        public int DriverCompID { get; set; }
        [ForeignKey("DriverCompID")]
        public DriverCompany? DriverCompany { get; set; }

    }

      


    
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{

    [Table("Driver", Schema = "LabbehDB")]
    public class Drivers //sub
    {
        [Key]
        [Display(Name = "ID")]
        [Column(TypeName = "int")]
        public int ID { get; set; }


        [Display(Name = "Driver Code")]
        [Column(TypeName = "nvarchar(max)")]
        public string? DriverCode { get; set; } = "";


        [Display(Name = "Driver Name")]
        [Column(TypeName = "nvarchar(max)")]
        public string? DriverName { get; set; } = "";


        [Display(Name = "Driver Phone")]
        [Column(TypeName = "nvarrchar(max)")]
        public string? DriverPhone { get; set; } = "";



        [Display(Name = "Latitude Default")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string LatitudeDefault { get; set; }


        [Display(Name = "LongTitude Default")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string LongtitudeDefault { get; set; }

        [Display(Name = "Email ..")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string DriverEmail { get; set; }


        public int DriverTTypeId { get; set; }
        [ForeignKey("DriverTTypeId")]
        public DriversCompaniesCat? DriversCompaniesCat { get; set; }

        public int DriverCompanyId { get; set; }
        [ForeignKey("DriverCompanyId")]
        public DriverCompany? DriverCompany { get; set; }

        //public int Status { get; set; }

        /*
        [Key]
        [Display(Name = "ID")]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int DriverCode { get; set; }

        [Display(Name = "Driver Name")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string DriverName { get; set; }

        [Display(Name = "Driver Name")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string DriverPhone { get; set; }
        [Display(Name = "Latitude Default")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string LatitudeDefault { get; set; }
        [Display(Name = "LongTitude Default")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string LongtitudeDefault { get; set; }
        [Display(Name = "Email ..")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string DriverEmail { get; set; }
        public int DriverTTypeId { get; set; }
        [ForeignKey("DriverTTypeId")]
        public DriversCompaniesCat? DriversCompaniesCat { get; set; }
        public int DriverCompanyId { get; set; }
        [ForeignKey("DriverCompanyId")]
        public DriverCompany? DriverCompany { get; set; }

        */

    }
}

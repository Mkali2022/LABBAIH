using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("DriverContract", Schema = "LabbehDB")]

    public class DriversContract
    {

        [Key]
        [Display(Name = "ID")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Display(Name = "Code")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int Code { get; set; }
        [Display(Name = "Details")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ContractDetaill { get; set; } 
        [Display(Name = "Star Date")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DateFrom { get; set; }
        [Display(Name = "End Date")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DateTo { get; set; }

        public int DriverId { get; set; }

        [ForeignKey("DriverId")]
        public Drivers? drivers { get; set; }

        [Display(Name = "Name")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string DriverName { get; set; } = "";



    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{

    [Table("DriversVehicle", Schema = "LabbehDB")]

    public class DriverVehicle
    {
        [Key]
        [Display(Name = "ID")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int ID { set; get; }
         [Display(Name = "Code")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int Code { set; get; }

        public int DriverID { set; get; }
        [ForeignKey("DriverID")]
        public Drivers? Drivers { get; set; }

        public int VehicleID { get; set; }
        [ForeignKey("VehicleID")]
        public Vehicles? Vehicles { get; set; }


        [Display(Name = "Used Date")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? UsingDate { get; set; }


    }
}

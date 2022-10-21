using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{

    [Table("DriversTracking", Schema = "LabbehDB")]

    public class DriverTracking
    {
        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]

        [Column(TypeName = "int")]
        public int DriverCode { get; set; }
        [Display(Name = "Latitude")]

        [Column(TypeName = "nvarchar(MAX)")]
        public int Latitude { get; set; }
        [Display(Name = "Longtitude")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Longtitude { get; set; }
        [Display(Name = "Current Date")]

        [Column(TypeName = "nvarchar(MAX)")]
        public  string? CurentDTime { get; set; }

        [Display(Name = "Current Hour")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string? CurrentHour { get; set; }
        public int DriverID { get; set; }
        [ForeignKey("DriverID")]
        public Drivers? Drivers { get; set; }
        //   public DateTime  Longtitude { get; set; }
    }
}

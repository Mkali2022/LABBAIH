using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("DriversTrackingOrder", Schema = "LabbehDB")]


    public class DriverTrackingOrder //sub
    {
        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int Code { get; set; }
        [Display(Name = "Laitude")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Latitude { get; set; }

        [Display(Name = "Longtitude")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Longtitude { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
        public int DriverTrackingId { get; set; }
        [ForeignKey("DriverTrackingId")]
        public DriverTracking? DriverTracking { get; set; }



    }
}

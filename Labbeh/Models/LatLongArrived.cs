using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("LatLongArrived", Schema = "LabbehDB")]

    public class LatLongArrived
    {
        [Key]
        [Display(Name = "ID")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Latitude")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Latitude { set; get; }
        [Display(Name = "LongTitude")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string LongTitude { set; get; }
        public int OrderRef { set; get; }
        [ForeignKey("OrderRef")]
        public Order? Order { get; set; }

    }
}

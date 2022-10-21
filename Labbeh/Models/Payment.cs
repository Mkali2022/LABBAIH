using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("Payments", Schema = "LabbehDB")]

    public class Payment
    {

        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]

        [Column(TypeName = "int")]
        public int Code { get; set; }
        [Display(Name = "Payment Way")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string? PaymentWay { get; set; }



    }
}

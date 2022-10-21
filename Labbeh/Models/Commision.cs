using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("Commisions", Schema = "LabbehDB")]

    public class Commision
    {

        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]
        public int Code { get; set; }
        [Display(Name = "Payment Way ")]
        public int PaymentWayID { get; set; }
        [ForeignKey("PaymentWayID")]
        public Payment? payment { get; set; }
        [Display(Name = "Contract")]
        public int ContactID { get; set; }
        [ForeignKey ("ContactID")]
        public Contract? contract { get; set; }

        [Required]
        [Display(Name = "Commision Amount")]
        [Column(TypeName = "decimal(13,2)")]
        public double Commisionamount { get; set; }


    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("Offer", Schema = "LabbehDB")]

    public class Offers
    {
        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }   
        [Display(Name = "Code")]

        [Column(TypeName = "int")]
        public int OffersCode { get; set; }
         [Display(Name = "Details")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string? OffersDetails { get; set; }
      

        [Display(Name = "Price")]

        [Column(TypeName = "decimal(13,2)")]
        public decimal OffersPrice { get; set; }


        public int BranchesIDRef { get; set; }
        [ForeignKey("BranchesIDRef")]
        public Branches? Branches { get; set; }
    }
}

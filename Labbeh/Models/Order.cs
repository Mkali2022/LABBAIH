using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("Orders", Schema = "LabbehDB")]

    public class Order
    {
        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; } 
        
        [Display(Name = "Code")]

        [Column(TypeName = "int")]
        public int Code { get; set; }

        [Display(Name = "Current Date")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string? CurrentDate { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customers? Customers { get; set; }
        public int BranchID { get; set; }
        
        [ForeignKey("BranchID")]
        public Branches? Branches { get; set; }

    }
}

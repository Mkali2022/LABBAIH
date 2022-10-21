using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("CustomersCusCat", Schema = "LabbehDB")]

    public class CustomerCusCat
    {

        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customers? Cus  { get; set; }
        public int CustomerCatID { get; set; }
        [ForeignKey("CustomerCatID")]
        public CustomerCategory? CusCat { get; set; }

        [Display(Name = "Current Date")]

        [Column(TypeName = "nvarchar(max)")]
        public string CurrentDate { get; set; } = "";
         



    }
}

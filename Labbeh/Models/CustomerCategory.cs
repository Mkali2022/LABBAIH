using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Labbeh.Models
{
    [Table("CustomersCategory", Schema = "LabbehDB")]

    public class CustomerCategory
    {
     
        [Key]
        [Display(Name = "ID")]
   
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Cattegoy Name")]
      
        [Column(TypeName = "nvarchar(max)")]
        public string? CategoyName { get; set; } 
        

    }
}

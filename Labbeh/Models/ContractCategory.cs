using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("ContractCategorie", Schema = "LabbehDB")]

    public class ContractCategory
    {

        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Category")]

        [Column(TypeName = "nvarchar(max)")]
        public string ConractCategory { get; set; } = "";

    }
}

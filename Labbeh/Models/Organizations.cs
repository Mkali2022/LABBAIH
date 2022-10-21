using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("Organizatio", Schema = "LabbehDB")]

    public class Organizations //sub
    {
        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]

        [Column(TypeName = "int")]
        public int OrganizeCode { get; set; }
        [Display(Name = "Name")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string? OrganizeName { get; set; }

    }
}

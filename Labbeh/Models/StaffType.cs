using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("StaffsType", Schema = "LabbehDB")]

    public class StaffType
    {

        [Key]
        [Display(Name = "ID")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int Code { get; set; }
        [Display(Name = "Type Title")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? TypeName { get; set; }



    }
}

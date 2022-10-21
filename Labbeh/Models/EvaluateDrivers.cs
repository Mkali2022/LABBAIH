using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{

    [Table("EvaluateDriver", Schema = "LabbehDB")]

    public class EvaluateDrivers
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

        [Display(Name = "Question Title")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Questions { get; set; } = "";



    }
}

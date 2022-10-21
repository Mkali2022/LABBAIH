using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("Answers", Schema = "LabbehDB")]
    public class Answer
    {

        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Display(Name = "Answer title")]

        [Column(TypeName = "nvarchar(max)")]
        public string? AnswerTitle { get; set; } = "";
       
        public int? QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public EvaluateDrivers? questionId { get; set; }

    }
}

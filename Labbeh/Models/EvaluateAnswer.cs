using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("EvaluateAnswers", Schema = "LabbehDB")]
    public class EvaluateAnswer
    {
        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Display(Name = "ECode")]

        [Column(TypeName = "nvarchar(max)")]
        public string? ECode { get; set; } = "";

        public int? QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public EvaluateDrivers? questionId { get; set; }
        public int? AnsID { get; set; }
        [ForeignKey("AnsID")]
        public Answer? ansID { get; set; }
        public int? DriverContractId { get; set; }
        [ForeignKey("DriverContractId")]
        public DriversContract? driverContractId { get; set; }

        [Display(Name = "Current Date")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? CurrentDate { get; set; }
    }
}

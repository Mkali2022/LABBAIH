using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{

    [Table("DriversContractEvaluate", Schema = "LabbehDB")]

    public class DriverContractEvaluate
    {
        [Key]
        [Display(Name = "ID")]
    
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int Code { get; set; }

        public int DriveContractID { get; set; }
        [ForeignKey("DriveContractID")]
        public DriversContract? driverconttact { get; set; }
        public int QEvaluateID { get; set; }

        [ForeignKey("QEvaluateID")]
        public EvaluateDrivers? EvaluateDriver { get; set; }
        [Display(Name = "Date Now")]

        [Column(TypeName = "nvarchar(max)")]
        public string CurrentDate { get; set; } = "";

    }
}

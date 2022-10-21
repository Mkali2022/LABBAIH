using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{

    [Table("GeneralWalets", Schema = "LabbehDB")]

    public class GeneralWalet
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

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public Drivers? Drivers { get; set; }

        [Display(Name = "Flag")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int FlagID { get; set; }
        public int StaffId { get; set; }
        [ForeignKey("StaffId")]
        public Staff? Staff { get; set; }

        [Display(Name = "Balance")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "decimal(13,2)")]
        public decimal BalanceValue { get; set; }
    }
}

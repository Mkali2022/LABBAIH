using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("Staffs", Schema = "LabbehDB")]

    public class Staff
    {

        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]

        [Column(TypeName = "int")]
        public int? Code { get; set; }
        [Display(Name = "Full Name")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string? FullName { get; set; }
        [Display(Name = "UserName")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string UserName { get; set; }

        [Display(Name = "PassWord")]

        [Column(TypeName = "nvarchar(MAX)")]
        public string? PassWord { get; set; }

        public int StaffTypeID { get; set; }
        [ForeignKey("StaffTypeID")]
        public StaffType? StaffType { get; set; }
    }
}

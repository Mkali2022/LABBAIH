using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labbeh.Models
{
    [Table("Branche", Schema = "LabbehDB")]

    public class Branches
    {
        [Key]
        //[Key]
        [Display(Name = "ID")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Branch Code")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? BranchCode { get; set; } = "";
        [Display(Name = "Branch Name")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? BranchName { get; set; } = "";
        [Display(Name = "Branch Latittiude")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? latitude { get; set; } = "";
        [Display(Name = "Branch LongTitude ")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? longtitude { get; set; } = "";
        public int? OrgsSubID { get; set; }
        [ForeignKey("OrgsSubID")]
        public OrgsSub? orgsSub { get; set; }



    }
}

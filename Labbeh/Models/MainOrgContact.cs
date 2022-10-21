using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("MainOrgContacts", Schema = "LabbehDB")]

    public class MainOrgContact
    {

        [Key]
        [Display(Name = "ID")]
         
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]
         
        [Column(TypeName = "int")]
        public int Code { get; set; }
        [Display(Name = "Phone No")]
         
        [Column(TypeName = "nvarchar(MAX)")]
        public string? PhoneNo { get; set; }
        [Display(Name = "Email")]
         
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Email { get; set; }
     
        [Column(TypeName = "nvarchar(MAX)")]
        public int BranchesContact { get; set; }
        [ForeignKey("BranchesContact")]
        public Branches? Branches { get; set; }
        public int OrgsSubbIDRef { get; set; }
        [ForeignKey("OrgsSubbIDRef")]
        public OrgsSub? OrgsSub { get; set; }

    }
}

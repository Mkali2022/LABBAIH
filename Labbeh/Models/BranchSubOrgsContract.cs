using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("BranchsSubOrgsContract", Schema = "LabbehDB")]

    public class BranchSubOrgsContract
    {
        [Key]
        [Display(Name = "ID")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Display(Name = "Branch No")]
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branches? Branch { set; get; }

        [Display(Name = "Organization Name")]
        public int OrgsSubID { get; set; }
        [ForeignKey("OrgsSubID")]
        public OrgsSub? OrgsSub { set; get; }

        [Display(Name = "Contract No")]
        public int ContractID { get; set; }
        [ForeignKey("ContractID")]
        public Contract? Contracts { get; set; }

        [Display(Name = "Fees")]
        [Column(TypeName = "decimal(13,2)")]
        public double GenerationFees { get; set; }

        [Display(Name = "Current Status")]
        [Column(TypeName = "nvarchar(max)")]
        public char Status { get; set; }



    }
}

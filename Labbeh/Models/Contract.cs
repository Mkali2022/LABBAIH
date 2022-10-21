using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("Contracts", Schema = "LabbehDB")]

    public class Contract
    {
        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Column(TypeName = "int")]
        public int Code { get; set; }
        [Display(Name = "Owner Name")]
        [Column(TypeName = "nvarchar(max)")]
        public string OwnerName { get; set; }

        [Display(Name = "Organization Address")]
        [Column(TypeName = "nvarchar(max)")]
        public string OrganizationAddress { get; set; }
        [Display(Name = "Phone No 1")]
        [Column(TypeName = "nvarchar(max)")]
        public string Phone1 { get; set; }

        [Display(Name = "Phone No 2")]
        [Column(TypeName = "nvarchar(max)")]
        public string Phone2 { get; set; }

        [Display(Name = "Start Date")]
        [Column(TypeName = "nvarchar(max)")]
        public string DateFrom { get; set; }


        [Display(Name = "End Date")]
        [Column(TypeName = "nvarchar(max)")]
        public string DateTo { get; set; } = "";

        [Display(Name = "Cost")]
      //  [Column(TypeName = "nvarchar(max)")]
        [Column(TypeName = "decimal(13,2)")]
        public double Cost { get; set; }

        [Display(Name = "Organization Name")]
        [Column(TypeName = "nvarchar(max)")]
        public int OrgsSubIdRef { get; set; }
        [ForeignKey("OrgsSubIdRef")]
        public OrgsSub? orgsub { get; set; }
        //  [ForeignKey("OrgsSubIdRef")]
        //


    }
}

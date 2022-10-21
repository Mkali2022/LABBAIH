using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("Item", Schema = "LabbehDB")]

    public class Items
    {
        [Key]
        [Display(Name = "ID")]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ItemsCode { get; set; }

        [Display(Name = "Item Name")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ItemsName { get; set; }

        [Display(Name = "Cost")]
        [Column(TypeName = "decimal(13,2)")]
        public double ItemCost { get; set; }

        public int OrgsSubRef { get; set; }
        [ForeignKey("OrgsSubRef")]
        public OrgsSub? OrgsSub { get; set; }
        public int BranchesIDRef { get; set; }
        [ForeignKey("BranchesIDRef")]
        public Branches? Branches { get; set; }

        [Display(Name = "Flag")]
        [Column(TypeName = "int")]
        public int FlagType { get; set; } 
    }
}

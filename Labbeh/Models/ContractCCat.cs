using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("ContractsCCat", Schema = "LabbehDB")]

    public class ContractCCat
    {
        [Key]
        [Display(Name = "ID")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int ID { get; set; }


        [Display(Name = "Contract ID")]
        //[Column (TypeName ="nvarchar(max)")]
         
        public int ContractID { get; set; }
        [ForeignKey("ContractID")]
        public Contract? Contracts { get; set; }
        //[Column (TypeName ="nvarchar(max)")]

        public int ContactCatID { get; set; }
        [ForeignKey("ContactCatID")]
        public ContractCategory? ContCat { get; set; }


    }

}

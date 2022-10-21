using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("OrgSub", Schema = "LabbehDB")]

    public class OrgsSub
    {

        [Key]
        [Display(Name = "ID")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Display(Name = "Code")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int OrgsSubCode { get; set; }
        [Display(Name = "Name")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? OrgsSubName { get; set; }
        [Display(Name = "Latitude")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Latitiude { get; set; }
        [Display(Name = "LongTitude")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Logtitude { get; set; }

        public int OrganizationRef { get; set; }
        [ForeignKey("OrganizationRef")]
        public Organizations? Organizations { get; set; }


    }
}

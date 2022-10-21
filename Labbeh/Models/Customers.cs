using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("Custome", Schema = "LabbehDB")]

    public class Customers
    {
        [Key]
        [Display(Name = "ID")]

        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Display(Name = "Code")]

        [Column(TypeName = "int")]
        public int CustomerCode { get; set; }

        [Display(Name = "Customer Name")]

        [Column(TypeName = "nvarchar(max)")]
        public string CustomerName { get; set; } = "";

        [Display(Name = "User Name")]

        [Column(TypeName = "nvarchar(max)")]
        public string UserName { get; set; }

        [Display(Name = "PassWord")]

        [Column(TypeName = "nvarchar(max)")]
        public string PassWord { get; set; }

        [Display(Name = "Phone")]

        [Column(TypeName = "nvarchar(max)")]
        public string PhoneNumber { get; set; } = "";

        [Display(Name = "Default Latitude")]

        [Column(TypeName = "nvarchar(max)")]
        public string LatitudeDefault { get; set; }
        
        [Display(Name = "Default Longtitude")]

        [Column(TypeName = "nvarchar(max)")]
        public string LongtitudeDefault { get; set; }


    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labbeh.Models
{
    [Table("ItemsOrderOffer", Schema = "LabbehDB")]

    public class ItemOrderOffer
    {

        [Key]
        [Display(Name = "ID")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        public int ItemIDRef { get; set; }
        [ForeignKey("ItemIDRef")]
        public Items? Items { get; set; }
        public int OfferIDRef { get; set; }
        [ForeignKey("OfferIDRef")]
        public Offers? Offers { get; set; }

        public int OrderIDRef { get; set; }
        [ForeignKey("OrderIDRef")]
        public Order? Order { get; set; }

        [Display(Name = "Flag")]
        //[Column (TypeName ="nvarchar(max)")]
        [Column(TypeName = "int")]
        public int FlagOfferItem { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace Frameworks_ThatSneakerShop.Models {
    public class Shoe {
        [Key]
        public int ShoeId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ShoeName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ShoeDescription { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public float ShoePrice { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}

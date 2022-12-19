using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frameworks_ThatSneakerShop.Models {
    public class Payment {
        [Key]
        public int PaymentId { get; set; }


        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Amount")]
        public float TotalOrder { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Time of payment")]
        public DateTime TimeOfPayment { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Available")]
        public bool Hidden { get; set; }
    }
}

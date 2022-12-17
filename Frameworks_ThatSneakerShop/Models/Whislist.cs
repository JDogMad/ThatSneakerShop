using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frameworks_ThatSneakerShop.Models {
    public class Whislist {
        [Key]
        public int WhislistId { get; set; }

        [ForeignKey ("ShoeId")]
        public Shoe Shoe { get; set; }
        public int ShoeId { get; set; }
    }
}

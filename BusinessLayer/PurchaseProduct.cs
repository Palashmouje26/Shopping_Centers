using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessModel
{
    public class PurchaseProduct
    {
        [Key]
        public int PurchaseID { get; set; }

        public int UId { get; set; }
        [ForeignKey("UId")]
        public virtual Users Users { get; set; }
        public int PId { get; set; }
        [ForeignKey("PId")]
        public virtual Products Products { get; set; }

    }
}

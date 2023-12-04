using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Stock")]
        public int StockId { get; set; }

        [Required]
        [StringLength(20)]
        public string OrderType { get; set; } = "";

        [Required]
        [StringLength(20)]
        public string Direction { get; set; } = "";
            
        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column("Price", TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "";

        [Required]
        public DateTime OrderDate { get; set; }

        public virtual User User { get; set; }

        public virtual Stock Stock { get; set; }
    }
}

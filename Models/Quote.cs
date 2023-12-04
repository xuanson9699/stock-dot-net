using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.Models
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Stock")]
        public int StockId { get; set; }

        [Required]
        [Column("Price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column("Change", TypeName = "decimal(18,2)")]
        public decimal Change { get; set; }

        [Required]
        [Column("PercentChange", TypeName = "decimal(18,2)")]
        public decimal PercentChange { get; set; }

        [Required]
        public int Volume { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        public virtual Stock Stock { get; set; }
    }
}

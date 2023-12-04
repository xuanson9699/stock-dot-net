using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.Models
{
    public class EtfQuote
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Etf")]
        public int EtfId { get; set; }

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
        public int TotalVolume { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        public virtual Etf Etf { get; set; }
    }
}

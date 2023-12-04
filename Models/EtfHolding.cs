using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.Models
{
    public class EtfHolding
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ETF")]
        public int EtfId { get; set; }

        [Required]
        [ForeignKey("Stock")]
        public int StockId { get; set; }

        [Required]
        [Column("SharesHeld", TypeName = "decimal(18,4)")]
        public decimal SharesHeld { get; set; }

        [Required]
        [Column("Weight", TypeName = "decimal(18,4)")]
        public decimal Weight { get; set; }

        public virtual Etf Etf { get; set; }

        public virtual Stock Stock { get; set; }
    }
}

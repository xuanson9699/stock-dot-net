using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StockAppWebApi.Models
{
    public class Derivative
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = "";

        [ForeignKey("Stock")]
        public int? UnderlyingAssetId { get; set; }

        public int ContractSize { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal StrikePrice { get; set; }

        [Required]
        [Column("LastPrice", TypeName = "decimal(18,2)")]
        public decimal LastPrice { get; set; }

        [Required]
        [Column("Change", TypeName = "decimal(18,2)")]
        public decimal Change { get; set; }

        [Required]
        [Column("PercentChange", TypeName = "decimal(18,2)")]
        public decimal PercentChange { get; set; }

        [Required]
        [Column("OpenPrice", TypeName = "decimal(18,2)")]
        public decimal OpenPrice { get; set; }

        [Required]
        [Column("HighPrice", TypeName = "decimal(18,2)")]
        public decimal HighPrice { get; set; }

        [Required]
        [Column("LowPrice", TypeName = "decimal(18,2)")]
        public decimal LowPrice { get; set; }

        [Required]
        public int Volume { get; set; }

        [Required]
        public int OpenInterest { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        public virtual Stock Stock { get; set; }
    }
}

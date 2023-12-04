using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApi.Models
{
    [Table("stocks")]

    [Index(nameof(Symbol) ,IsUnique = true)]
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string Symbol { get; set; } = "";

        [Required]
        [StringLength(255)]
        public string CompanyName { get; set; } = "";

        public decimal? MarketCap { get; set; }

        [StringLength(200)]
        public string Sector { get; set; } = "";

        [StringLength(200)]
        public string Industry { get; set; } = "";

        [StringLength(200)]
        public string SectorEn { get; set; } = "";

        [StringLength(200)]
        public string IndustryEn { get; set; } = "";

        [StringLength(50)]
        public string StockType { get; set; } = "";

        public int Rank { get; set; }

        [StringLength(255)]
        public string Reason { get; set; } = "";
    }
}


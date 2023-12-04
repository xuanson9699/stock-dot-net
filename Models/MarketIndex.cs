
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace StockAppWebApi.Models
{
    [Index(nameof(Symbol), IsUnique = true)]
    public class MarketIndex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string Symbol { get; set; } = "";
    }
}

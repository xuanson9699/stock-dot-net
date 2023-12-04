using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.Models
{
    [Index(nameof(Symbol), IsUnique = true)]
    public class Etf
    {
        [Key]
        public int EtfId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string Symbol { get; set; } = "";

        [StringLength(255)]
        public string ManagementCompany { get; set; } = "";

        public DateTime? InceptionDate { get; set; }
    }
}

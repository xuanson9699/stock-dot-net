using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApi.Models
{
    public class CoveredWarrant
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = "";

        [ForeignKey("Stock")]
        public int? UnderlyingAssetId { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal StrikePrice { get; set; }

        [StringLength(50)]
        public string WarrantType { get; set; } = "";

        public virtual Stock Stock { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.Models
{
    public class IndexConstituent
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        [ForeignKey("MarketIndex")]
        public int IndexId { get; set; }

        [ForeignKey("Stock")]
        public int StockId { get; set; }

        public virtual MarketIndex MarketIndex { get; set; }

        public virtual Stock Stock { get; set; }
    }
}

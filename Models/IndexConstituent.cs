using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.Models
{
    public class IndexConstituent
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MarketIndex")]
        public int IndexId { get; set; }

        [ForeignKey("Stock")]
        public int StockId { get; set; }

        public virtual MarketIndex MarketIndex { get; set; }

        public virtual Stock Stock { get; set; }
    }
}

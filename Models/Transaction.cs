using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("LinkedBankAccount")]
        public int? LinkedAccountId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("transaction_type")]
        public string TransactionType { get; set; }

        [Required]
        [Column("Amount", TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public virtual User User { get; set; }

        public virtual LinkedBankAccount LinkedBankAccount { get; set; }
    }
}

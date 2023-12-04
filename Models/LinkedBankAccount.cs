using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.Models
{
    public class LinkedBankAccount
    {
        [Key]
       
        public int AccountId { get; set; }

        [Required]
        [ForeignKey("User")]
        
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        
        public string BankName { get; set; } = "";

        [Required]
        [StringLength(50)]
       
        public string AccountNumber { get; set; } = "";

        [StringLength(50)]
       
        public string RoutingNumber { get; set; } = "";

        [StringLength(50)]
        public string AccountType { get; set; } = "";

        public virtual User User { get; set; }
    }
}

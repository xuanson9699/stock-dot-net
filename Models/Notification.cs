using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
       
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
       
        public string NotificationType { get; set; } = "";

        [Required]
        
        public string Content { get; set; } = "";

        
        public bool IsRead { get; set; } = false;

        public virtual User User { get; set; }
    }
}

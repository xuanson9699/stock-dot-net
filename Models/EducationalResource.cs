using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.Models
{
    public class EducationalResource
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        [Required]
        [StringLength(255)]
        
        public string Title { get; set; }

        [Required]
        [Column("Content", TypeName = "TEXT")]
        public string Content { get; set; }

        [StringLength(100)]
        public string Category { get; set; }

        public DateTime DatePublished { get; set; }
    }
}

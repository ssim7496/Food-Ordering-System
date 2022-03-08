using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FOS_API.Data
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuItemId { get; set; }
        [Required]
        [ForeignKey("MenuCategoryId")]
        public int MenuCategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        [Required]
        public double Order { get; set; }

        [Required]
        public bool Visible { get; set; }

        public MenuCategory MenuCategory { get; set; }
    }
}

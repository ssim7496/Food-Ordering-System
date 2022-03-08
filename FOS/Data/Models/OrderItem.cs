using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FOS_API.Data
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [ForeignKey("OrderID")]
        public int OrderID { get; set; }

        [Required]
        [ForeignKey("MenuItemID")]
        public int MenuItemID { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Order Order { get; set; }

        public MenuItem MenuItem { get; set; }
    }
}

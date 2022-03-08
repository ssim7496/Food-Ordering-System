using FOS.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FOS_API.Data
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }

        [Required]
        [ForeignKey("OrderStatusID")]
        public int OrderStatusID { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime DateOrdered { get; set; }
        public DateTime DatePrepared { get; set; }
        public DateTime DateCompleted { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Customer Customer { get; set; }

    }
}

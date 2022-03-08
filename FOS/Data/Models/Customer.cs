using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FOS.Data
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(200)]
        public string Domain { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public static class CustomerRequestValidate
    {
        public static string Validate(this Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Domain)) return "Please enter your domain";
            else if (string.IsNullOrEmpty(customer.Username)) return "Please enter your username";
            else if (string.IsNullOrEmpty(customer.Password)) return "Please enter your password";
            else return string.Empty;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CourierManagementSystem.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

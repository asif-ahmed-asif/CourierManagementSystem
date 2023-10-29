using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourierManagementSystem.Models
{
    public class Courier
    {
        [Key]
        public Guid ConsignmentNo { get; set; }

        [Required]
        [DisplayName("Customer Name")]
        public string? CustomerName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Customer Email")]
        public string? CustomerEmail { get; set; }

        [Required]
        [DisplayName("Customer Address")]
        public string? CustomerAddress { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Phone number must not exceed 11 digits!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only digits are allowed!")]
        [DisplayName("Customer Mobile")]
        public string? CustomerMobile { get; set; }

        [Required]
        [DisplayName("Recipient Name")]
        public string? RecipientName { get; set; }

        [Required]
        [DisplayName("Recipient Address")]
        public string? RecipientAddress { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Phone number must not exceed 11 digits!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only digits are allowed!")]
        [DisplayName("Recipient Mobile")]
        public string? RecipientMobile { get; set; }

        [Required]
        [RegularExpression("^[0-9]*\\.?[0-9]+$", ErrorMessage = "Only positive numbers are allowed!")]
        [DisplayName("Courier Charge")]
        public string? CourierCharge { get; set; }

        [DisplayName("Date Of Place")]
        public DateTime? DateOfPlace { get; set; }

        public DateTime? DateOfDelivered { get; set; }

        [DisplayName("Status")]
        public int? StatusId { get; set; }


        //Navigation Properties
        public Status? Status { get; set; }
    }
}

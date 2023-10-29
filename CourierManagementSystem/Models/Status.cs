using System.ComponentModel.DataAnnotations;

namespace CourierManagementSystem.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }


        //Navigation Properties
        public ICollection<Courier>? Courier { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebApp.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Customer FirstName")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Customer LastName")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }

    }
}

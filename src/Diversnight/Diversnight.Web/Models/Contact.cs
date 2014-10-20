using System.ComponentModel.DataAnnotations;

namespace Diversnight.Web.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public virtual Organization Organizer { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public bool IsActive { get; set; }
    }
}
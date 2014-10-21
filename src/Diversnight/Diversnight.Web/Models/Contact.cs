using System;
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

        public string Name
        {
            get { return String.Format("{0} {1}", Firstname, Lastname); }
        }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public bool IsActive { get; set; }
    }
}
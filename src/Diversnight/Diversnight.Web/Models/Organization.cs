using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diversnight.Web.Models
{
    public class Organization
    {
        public Organization()
        {
            Sites = new List<Site>();
            Contacts = new List<Contact>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Site> Sites { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; } 
    }
}
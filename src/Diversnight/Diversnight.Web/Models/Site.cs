using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Diversnight.Web.Models
{
    public class RegisterSiteViewModel
    {
        public IEnumerable<SelectListItem> Organizations { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        [Required]
        [DisplayName("Organizer")]
        public Organization Organization { get; set; }

        [Required]
        [DisplayName("Site name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public Country Country { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Site
    {
        public int Id { get; set; }

        [Required]
        [Range(2000, 2100)]
        public int Year { get; set; }

        [Required]
        public virtual Organization Organization { get; set; }

        [Required]
        public int TimeZone { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual Country Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int Divers { get; set; }
    }
}
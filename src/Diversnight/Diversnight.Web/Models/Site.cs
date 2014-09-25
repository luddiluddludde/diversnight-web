using System;
using System.Collections.Generic;

namespace Diversnight.Web.Models
{
    public class Site
    {
        public Site()
        {
            Results = new List<SiteResult>();
        }

        public int Id { get; set; }

        public virtual Country Country { get; set; }
        public virtual TimeZone TimeZone { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string City { get; set; }
        public string Name { get; set; }

        public string Organization { get; set; }
        public string Webpage { get; set; }

        public string Description { get; set; }

        public virtual ICollection<SiteResult> Results { get; set; }
    }

    public class SiteResult
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Divers { get; set; }
        public bool HasCompleted { get; set; }
    }
}
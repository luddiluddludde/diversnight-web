using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Diversnight.Web.Models
{
    public class DiversnightDbContext : IdentityDbContext<ApplicationUser>
    {
        public DiversnightDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<TimeZone> TimeZones { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<SiteResult> Results { get; set; }

        public static DiversnightDbContext Create()
        {
            return new DiversnightDbContext();
        }
    }

    public static class CountryExtensions
    {
        public static int DiveSitesCount(this Country country)
        {
            return country.Sites.Count;
        }

        public static int DiversCount(this Country country, int year)
        {
            return
                country.Sites.Where(site => site.Results.Any(result => result.Year == year))
                    .Select(a => a.Results.FirstOrDefault(result => result.Year == year))
                    .Aggregate(0, (current, result) => current + (result != null ? result.Divers : 0));
        }
    }
}
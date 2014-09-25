using System.Collections;
using System.Collections.Generic;

namespace Diversnight.Web.Models
{
    public class Country
    {
        public Country()
        {
            Sites = new List<Site>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Site> Sites { get; set; }
    }
}
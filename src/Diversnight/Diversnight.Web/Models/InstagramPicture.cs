using System;

namespace Diversnight.Web.Models
{
    public class InstagramPicture
    {
        public int Id { get; set; }
        public string IgId { get; set; }
        public DateTime ImportedTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
        public string User { get; set; }
        public bool Deleted { get; set; }
    }
}
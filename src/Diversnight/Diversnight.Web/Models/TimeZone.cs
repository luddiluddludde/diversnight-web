namespace Diversnight.Web.Models
{
    public class TimeZone
    {
        public int Id { get; set; }
        public double Offset { get; set; }
        public bool UseDST { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Text { get; set; }
    }
}
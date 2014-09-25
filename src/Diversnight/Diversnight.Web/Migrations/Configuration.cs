using Diversnight.Web.Models;

namespace Diversnight.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TimeZone = Diversnight.Web.Models.TimeZone;

    internal sealed class Configuration : DbMigrationsConfiguration<Diversnight.Web.Models.DiversnightDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Diversnight.Web.Models.DiversnightDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            #region Add timezones
            context.TimeZones.AddOrUpdate(
                tz => tz.Name,
                new TimeZone()
                {
                    Name = "Dateline Standard Time",
                    Abbreviation = "DST",
                    Offset = -12,
                    UseDST = false,
                    Text = "(UTC-12:00) International Date Line West"
                },
                new TimeZone()
                {
                    Name = "UTC-11",
                    Abbreviation = "U",
                    Offset = -11,
                    UseDST = false,
                    Text = "(UTC-11:00) Coordinated Universal Time-11"
                },
                new TimeZone()
                {
                    Name = "Hawaiian Standard Time",
                    Abbreviation = "HST",
                    Offset = -10,
                    UseDST = false,
                    Text = "(UTC-10:00) Hawaii"
                },
                new TimeZone()
                {
                    Name = "Alaskan Standard Time",
                    Abbreviation = "AKDT",
                    Offset = -8,
                    UseDST = true,
                    Text = "(UTC-09:00) Alaska"
                },
                new TimeZone()
                {
                    Name = "Pacific Standard Time (Mexico)",
                    Abbreviation = "PDT",
                    Offset = -7,
                    UseDST = true,
                    Text = "(UTC-08:00) Baja California"
                },
                new TimeZone()
                {
                    Name = "Pacific Standard Time",
                    Abbreviation = "PDT",
                    Offset = -7,
                    UseDST = true,
                    Text = "(UTC-08:00) Pacific Time (US & Canada)"
                },
                new TimeZone()
                {
                    Name = "US Mountain Standard Time",
                    Abbreviation = "UMST",
                    Offset = -7,
                    UseDST = false,
                    Text = "(UTC-07:00) Arizona"
                },
                new TimeZone()
                {
                    Name = "Mountain Standard Time (Mexico)",
                    Abbreviation = "MDT",
                    Offset = -6,
                    UseDST = true,
                    Text = "(UTC-07:00) Chihuahua, La Paz, Mazatlan"
                },
                new TimeZone()
                {
                    Name = "Mountain Standard Time",
                    Abbreviation = "MDT",
                    Offset = -6,
                    UseDST = true,
                    Text = "(UTC-07:00) Mountain Time (US & Canada)"
                },
                new TimeZone()
                {
                    Name = "Central America Standard Time",
                    Abbreviation = "CAST",
                    Offset = -6,
                    UseDST = false,
                    Text = "(UTC-06:00) Central America"
                },
                new TimeZone()
                {
                    Name = "Central Standard Time",
                    Abbreviation = "CDT",
                    Offset = -5,
                    UseDST = true,
                    Text = "(UTC-06:00) Central Time (US & Canada)"
                },
                new TimeZone()
                {
                    Name = "Central Standard Time (Mexico)",
                    Abbreviation = "CDT",
                    Offset = -5,
                    UseDST = true,
                    Text = "(UTC-06:00) Guadalajara, Mexico City, Monterrey"
                },
                new TimeZone()
                {
                    Name = "Canada Central Standard Time",
                    Abbreviation = "CCST",
                    Offset = -6,
                    UseDST = false,
                    Text = "(UTC-06:00) Saskatchewan"
                },
                new TimeZone()
                {
                    Name = "SA Pacific Standard Time",
                    Abbreviation = "SPST",
                    Offset = -5,
                    UseDST = false,
                    Text = "(UTC-05:00) Bogota, Lima, Quito"
                },
                new TimeZone()
                {
                    Name = "Eastern Standard Time",
                    Abbreviation = "EDT",
                    Offset = -4,
                    UseDST = true,
                    Text = "(UTC-05:00) Eastern Time (US & Canada)"
                },
                new TimeZone()
                {
                    Name = "US Eastern Standard Time",
                    Abbreviation = "UEDT",
                    Offset = -4,
                    UseDST = true,
                    Text = "(UTC-05:00) Indiana (East)"
                },
                new TimeZone()
                {
                    Name = "Venezuela Standard Time",
                    Abbreviation = "VST",
                    Offset = -4.5,
                    UseDST = false,
                    Text = "(UTC-04:30) Caracas"
                },
                new TimeZone()
                {
                    Name = "Paraguay Standard Time",
                    Abbreviation = "PST",
                    Offset = -4,
                    UseDST = false,
                    Text = "(UTC-04:00) Asuncion"
                },
                new TimeZone()
                {
                    Name = "Atlantic Standard Time",
                    Abbreviation = "ADT",
                    Offset = -3,
                    UseDST = true,
                    Text = "(UTC-04:00) Atlantic Time (Canada)"
                },
                new TimeZone()
                {
                    Name = "Central Brazilian Standard Time",
                    Abbreviation = "CBST",
                    Offset = -4,
                    UseDST = false,
                    Text = "(UTC-04:00) Cuiaba"
                },
                new TimeZone()
                {
                    Name = "SA Western Standard Time",
                    Abbreviation = "SWST",
                    Offset = -4,
                    UseDST = false,
                    Text = "(UTC-04:00) Georgetown, La Paz, Manaus, San Juan"
                },
                new TimeZone()
                {
                    Name = "Pacific SA Standard Time",
                    Abbreviation = "PSST",
                    Offset = -4,
                    UseDST = false,
                    Text = "(UTC-04:00) Santiago"
                },
                new TimeZone()
                {
                    Name = "Newfoundland Standard Time",
                    Abbreviation = "NDT",
                    Offset = -2.5,
                    UseDST = true,
                    Text = "(UTC-03:30) Newfoundland"
                },
                new TimeZone()
                {
                    Name = "E. South America Standard Time",
                    Abbreviation = "ESAST",
                    Offset = -3,
                    UseDST = false,
                    Text = "(UTC-03:00) Brasilia"
                },
                new TimeZone()
                {
                    Name = "Argentina Standard Time",
                    Abbreviation = "AST",
                    Offset = -3,
                    UseDST = false,
                    Text = "(UTC-03:00) Buenos Aires"
                },
                new TimeZone()
                {
                    Name = "SA Eastern Standard Time",
                    Abbreviation = "SEST",
                    Offset = -3,
                    UseDST = false,
                    Text = "(UTC-03:00) Cayenne, Fortaleza"
                },
                new TimeZone()
                {
                    Name = "Greenland Standard Time",
                    Abbreviation = "GDT",
                    Offset = -2,
                    UseDST = true,
                    Text = "(UTC-03:00) Greenland"
                },
                new TimeZone()
                {
                    Name = "Montevideo Standard Time",
                    Abbreviation = "MST",
                    Offset = -3,
                    UseDST = false,
                    Text = "(UTC-03:00) Montevideo"
                },
                new TimeZone()
                {
                    Name = "Bahia Standard Time",
                    Abbreviation = "BST",
                    Offset = -3,
                    UseDST = false,
                    Text = "(UTC-03:00) Salvador"
                },
                new TimeZone()
                {
                    Name = "UTC-02",
                    Abbreviation = "U",
                    Offset = -2,
                    UseDST = false,
                    Text = "(UTC-02:00) Coordinated Universal Time-02"
                },
                new TimeZone()
                {
                    Name = "Mid-Atlantic Standard Time",
                    Abbreviation = "MDT",
                    Offset = -1,
                    UseDST = true,
                    Text = "(UTC-02:00) Mid-Atlantic - Old"
                },
                new TimeZone()
                {
                    Name = "Azores Standard Time",
                    Abbreviation = "ADT",
                    Offset = 0,
                    UseDST = true,
                    Text = "(UTC-01:00) Azores"
                },
                new TimeZone()
                {
                    Name = "Cape Verde Standard Time",
                    Abbreviation = "CVST",
                    Offset = -1,
                    UseDST = false,
                    Text = "(UTC-01:00) Cape Verde Is."
                },
                new TimeZone()
                {
                    Name = "Morocco Standard Time",
                    Abbreviation = "MDT",
                    Offset = 1,
                    UseDST = true,
                    Text = "(UTC) Casablanca"
                },
                new TimeZone()
                {
                    Name = "UTC",
                    Abbreviation = "CUT",
                    Offset = 0,
                    UseDST = false,
                    Text = "(UTC) Coordinated Universal Time"
                },
                new TimeZone()
                {
                    Name = "GMT Standard Time",
                    Abbreviation = "GDT",
                    Offset = 1,
                    UseDST = true,
                    Text = "(UTC) Dublin, Edinburgh, Lisbon, London"
                },
                new TimeZone()
                {
                    Name = "Greenwich Standard Time",
                    Abbreviation = "GST",
                    Offset = 0,
                    UseDST = false,
                    Text = "(UTC) Monrovia, Reykjavik"
                },
                new TimeZone()
                {
                    Name = "W. Europe Standard Time",
                    Abbreviation = "WEDT",
                    Offset = 2,
                    UseDST = true,
                    Text = "(UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna"
                },
                new TimeZone()
                {
                    Name = "Central Europe Standard Time",
                    Abbreviation = "CEDT",
                    Offset = 2,
                    UseDST = true,
                    Text = "(UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague"
                },
                new TimeZone()
                {
                    Name = "Romance Standard Time",
                    Abbreviation = "RDT",
                    Offset = 2,
                    UseDST = true,
                    Text = "(UTC+01:00) Brussels, Copenhagen, Madrid, Paris"
                },
                new TimeZone()
                {
                    Name = "Central European Standard Time",
                    Abbreviation = "CEDT",
                    Offset = 2,
                    UseDST = true,
                    Text = "(UTC+01:00) Sarajevo, Skopje, Warsaw, Zagreb"
                },
                new TimeZone()
                {
                    Name = "W. Central Africa Standard Time",
                    Abbreviation = "WCAST",
                    Offset = 1,
                    UseDST = false,
                    Text = "(UTC+01:00) West Central Africa"
                },
                new TimeZone()
                {
                    Name = "Namibia Standard Time",
                    Abbreviation = "NST",
                    Offset = 1,
                    UseDST = false,
                    Text = "(UTC+01:00) Windhoek"
                },
                new TimeZone()
                {
                    Name = "GTB Standard Time",
                    Abbreviation = "GDT",
                    Offset = 3,
                    UseDST = true,
                    Text = "(UTC+02:00) Athens, Bucharest"
                },
                new TimeZone()
                {
                    Name = "Middle East Standard Time",
                    Abbreviation = "MEDT",
                    Offset = 3,
                    UseDST = true,
                    Text = "(UTC+02:00) Beirut"
                },
                new TimeZone()
                {
                    Name = "Egypt Standard Time",
                    Abbreviation = "EST",
                    Offset = 2,
                    UseDST = false,
                    Text = "(UTC+02:00) Cairo"
                },
                new TimeZone()
                {
                    Name = "Syria Standard Time",
                    Abbreviation = "SDT",
                    Offset = 3,
                    UseDST = true,
                    Text = "(UTC+02:00) Damascus"
                },
                new TimeZone()
                {
                    Name = "E. Europe Standard Time",
                    Abbreviation = "EEDT",
                    Offset = 3,
                    UseDST = true,
                    Text = "(UTC+02:00) E. Europe"
                },
                new TimeZone()
                {
                    Name = "South Africa Standard Time",
                    Abbreviation = "SAST",
                    Offset = 2,
                    UseDST = false,
                    Text = "(UTC+02:00) Harare, Pretoria"
                },
                new TimeZone()
                {
                    Name = "FLE Standard Time",
                    Abbreviation = "FDT",
                    Offset = 3,
                    UseDST = true,
                    Text = "(UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius"
                },
                new TimeZone()
                {
                    Name = "Turkey Standard Time",
                    Abbreviation = "TDT",
                    Offset = 3,
                    UseDST = true,
                    Text = "(UTC+02:00) Istanbul"
                },
                new TimeZone()
                {
                    Name = "Israel Standard Time",
                    Abbreviation = "JDT",
                    Offset = 3,
                    UseDST = true,
                    Text = "(UTC+02:00) Jerusalem"
                },
                new TimeZone()
                {
                    Name = "Libya Standard Time",
                    Abbreviation = "LST",
                    Offset = 2,
                    UseDST = false,
                    Text = "(UTC+02:00) Tripoli"
                },
                new TimeZone()
                {
                    Name = "Jordan Standard Time",
                    Abbreviation = "JST",
                    Offset = 3,
                    UseDST = false,
                    Text = "(UTC+03:00) Amman"
                },
                new TimeZone()
                {
                    Name = "Arabic Standard Time",
                    Abbreviation = "AST",
                    Offset = 3,
                    UseDST = false,
                    Text = "(UTC+03:00) Baghdad"
                },
                new TimeZone()
                {
                    Name = "Kaliningrad Standard Time",
                    Abbreviation = "KST",
                    Offset = 3,
                    UseDST = false,
                    Text = "(UTC+03:00) Kaliningrad, Minsk"
                },
                new TimeZone()
                {
                    Name = "Arab Standard Time",
                    Abbreviation = "AST",
                    Offset = 3,
                    UseDST = false,
                    Text = "(UTC+03:00) Kuwait, Riyadh"
                },
                new TimeZone()
                {
                    Name = "E. Africa Standard Time",
                    Abbreviation = "EAST",
                    Offset = 3,
                    UseDST = false,
                    Text = "(UTC+03:00) Nairobi"
                },
                new TimeZone()
                {
                    Name = "Iran Standard Time",
                    Abbreviation = "IDT",
                    Offset = 4.5,
                    UseDST = true,
                    Text = "(UTC+03:30) Tehran"
                },
                new TimeZone()
                {
                    Name = "Arabian Standard Time",
                    Abbreviation = "AST",
                    Offset = 4,
                    UseDST = false,
                    Text = "(UTC+04:00) Abu Dhabi, Muscat"
                },
                new TimeZone()
                {
                    Name = "Azerbaijan Standard Time",
                    Abbreviation = "ADT",
                    Offset = 5,
                    UseDST = true,
                    Text = "(UTC+04:00) Baku"
                },
                new TimeZone()
                {
                    Name = "Russian Standard Time",
                    Abbreviation = "RST",
                    Offset = 4,
                    UseDST = false,
                    Text = "(UTC+04:00) Moscow, St. Petersburg, Volgograd"
                },
                new TimeZone()
                {
                    Name = "Mauritius Standard Time",
                    Abbreviation = "MST",
                    Offset = 4,
                    UseDST = false,
                    Text = "(UTC+04:00) Port Louis"
                },
                new TimeZone()
                {
                    Name = "Georgian Standard Time",
                    Abbreviation = "GST",
                    Offset = 4,
                    UseDST = false,
                    Text = "(UTC+04:00) Tbilisi"
                },
                new TimeZone()
                {
                    Name = "Caucasus Standard Time",
                    Abbreviation = "CST",
                    Offset = 4,
                    UseDST = false,
                    Text = "(UTC+04:00) Yerevan"
                },
                new TimeZone()
                {
                    Name = "Afghanistan Standard Time",
                    Abbreviation = "AST",
                    Offset = 4.5,
                    UseDST = false,
                    Text = "(UTC+04:30) Kabul"
                },
                new TimeZone()
                {
                    Name = "West Asia Standard Time",
                    Abbreviation = "WAST",
                    Offset = 5,
                    UseDST = false,
                    Text = "(UTC+05:00) Ashgabat, Tashkent"
                },
                new TimeZone()
                {
                    Name = "Pakistan Standard Time",
                    Abbreviation = "PST",
                    Offset = 5,
                    UseDST = false,
                    Text = "(UTC+05:00) Islamabad, Karachi"
                },
                new TimeZone()
                {
                    Name = "India Standard Time",
                    Abbreviation = "IST",
                    Offset = 5.5,
                    UseDST = false,
                    Text = "(UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi"
                },
                new TimeZone()
                {
                    Name = "Sri Lanka Standard Time",
                    Abbreviation = "SLST",
                    Offset = 5.5,
                    UseDST = false,
                    Text = "(UTC+05:30) Sri Jayawardenepura"
                },
                new TimeZone()
                {
                    Name = "Nepal Standard Time",
                    Abbreviation = "NST",
                    Offset = 5.75,
                    UseDST = false,
                    Text = "(UTC+05:45) Kathmandu"
                },
                new TimeZone()
                {
                    Name = "Central Asia Standard Time",
                    Abbreviation = "CAST",
                    Offset = 6,
                    UseDST = false,
                    Text = "(UTC+06:00) Astana"
                },
                new TimeZone()
                {
                    Name = "Bangladesh Standard Time",
                    Abbreviation = "BST",
                    Offset = 6,
                    UseDST = false,
                    Text = "(UTC+06:00) Dhaka"
                },
                new TimeZone()
                {
                    Name = "Ekaterinburg Standard Time",
                    Abbreviation = "EST",
                    Offset = 6,
                    UseDST = false,
                    Text = "(UTC+06:00) Ekaterinburg"
                },
                new TimeZone()
                {
                    Name = "Myanmar Standard Time",
                    Abbreviation = "MST",
                    Offset = 6.5,
                    UseDST = false,
                    Text = "(UTC+06:30) Yangon (Rangoon)"
                },
                new TimeZone()
                {
                    Name = "SE Asia Standard Time",
                    Abbreviation = "SAST",
                    Offset = 7,
                    UseDST = false,
                    Text = "(UTC+07:00) Bangkok, Hanoi, Jakarta"
                },
                new TimeZone()
                {
                    Name = "N. Central Asia Standard Time",
                    Abbreviation = "NCAST",
                    Offset = 7,
                    UseDST = false,
                    Text = "(UTC+07:00) Novosibirsk"
                },
                new TimeZone()
                {
                    Name = "China Standard Time",
                    Abbreviation = "CST",
                    Offset = 8,
                    UseDST = false,
                    Text = "(UTC+08:00) Beijing, Chongqing, Hong Kong, Urumqi"
                },
                new TimeZone()
                {
                    Name = "North Asia Standard Time",
                    Abbreviation = "NAST",
                    Offset = 8,
                    UseDST = false,
                    Text = "(UTC+08:00) Krasnoyarsk"
                },
                new TimeZone()
                {
                    Name = "Singapore Standard Time",
                    Abbreviation = "MPST",
                    Offset = 8,
                    UseDST = false,
                    Text = "(UTC+08:00) Kuala Lumpur, Singapore"
                },
                new TimeZone()
                {
                    Name = "W. Australia Standard Time",
                    Abbreviation = "WAST",
                    Offset = 8,
                    UseDST = false,
                    Text = "(UTC+08:00) Perth"
                },
                new TimeZone()
                {
                    Name = "Taipei Standard Time",
                    Abbreviation = "TST",
                    Offset = 8,
                    UseDST = false,
                    Text = "(UTC+08:00) Taipei"
                },
                new TimeZone()
                {
                    Name = "Ulaanbaatar Standard Time",
                    Abbreviation = "UST",
                    Offset = 8,
                    UseDST = false,
                    Text = "(UTC+08:00) Ulaanbaatar"
                },
                new TimeZone()
                {
                    Name = "North Asia East Standard Time",
                    Abbreviation = "NAEST",
                    Offset = 9,
                    UseDST = false,
                    Text = "(UTC+09:00) Irkutsk"
                },
                new TimeZone()
                {
                    Name = "Tokyo Standard Time",
                    Abbreviation = "TST",
                    Offset = 9,
                    UseDST = false,
                    Text = "(UTC+09:00) Osaka, Sapporo, Tokyo"
                },
                new TimeZone()
                {
                    Name = "Korea Standard Time",
                    Abbreviation = "KST",
                    Offset = 9,
                    UseDST = false,
                    Text = "(UTC+09:00) Seoul"
                },
                new TimeZone()
                {
                    Name = "Cen. Australia Standard Time",
                    Abbreviation = "CAST",
                    Offset = 9.5,
                    UseDST = false,
                    Text = "(UTC+09:30) Adelaide"
                },
                new TimeZone()
                {
                    Name = "AUS Central Standard Time",
                    Abbreviation = "ACST",
                    Offset = 9.5,
                    UseDST = false,
                    Text = "(UTC+09:30) Darwin"
                },
                new TimeZone()
                {
                    Name = "E. Australia Standard Time",
                    Abbreviation = "EAST",
                    Offset = 10,
                    UseDST = false,
                    Text = "(UTC+10:00) Brisbane"
                },
                new TimeZone()
                {
                    Name = "AUS Eastern Standard Time",
                    Abbreviation = "AEST",
                    Offset = 10,
                    UseDST = false,
                    Text = "(UTC+10:00) Canberra, Melbourne, Sydney"
                },
                new TimeZone()
                {
                    Name = "West Pacific Standard Time",
                    Abbreviation = "WPST",
                    Offset = 10,
                    UseDST = false,
                    Text = "(UTC+10:00) Guam, Port Moresby"
                },
                new TimeZone()
                {
                    Name = "Tasmania Standard Time",
                    Abbreviation = "TST",
                    Offset = 10,
                    UseDST = false,
                    Text = "(UTC+10:00) Hobart"
                },
                new TimeZone()
                {
                    Name = "Yakutsk Standard Time",
                    Abbreviation = "YST",
                    Offset = 10,
                    UseDST = false,
                    Text = "(UTC+10:00) Yakutsk"
                },
                new TimeZone()
                {
                    Name = "Central Pacific Standard Time",
                    Abbreviation = "CPST",
                    Offset = 11,
                    UseDST = false,
                    Text = "(UTC+11:00) Solomon Is., New Caledonia"
                },
                new TimeZone()
                {
                    Name = "Vladivostok Standard Time",
                    Abbreviation = "VST",
                    Offset = 11,
                    UseDST = false,
                    Text = "(UTC+11:00) Vladivostok"
                },
                new TimeZone()
                {
                    Name = "New Zealand Standard Time",
                    Abbreviation = "NZST",
                    Offset = 12,
                    UseDST = false,
                    Text = "(UTC+12:00) Auckland, Wellington"
                },
                new TimeZone()
                {
                    Name = "UTC+12",
                    Abbreviation = "U",
                    Offset = 12,
                    UseDST = false,
                    Text = "(UTC+12:00) Coordinated Universal Time+12"
                },
                new TimeZone()
                {
                    Name = "Fiji Standard Time",
                    Abbreviation = "FST",
                    Offset = 12,
                    UseDST = false,
                    Text = "(UTC+12:00) Fiji"
                },
                new TimeZone()
                {
                    Name = "Magadan Standard Time",
                    Abbreviation = "MST",
                    Offset = 12,
                    UseDST = false,
                    Text = "(UTC+12:00) Magadan"
                },
                new TimeZone()
                {
                    Name = "Kamchatka Standard Time",
                    Abbreviation = "KDT",
                    Offset = 13,
                    UseDST = true,
                    Text = "(UTC+12:00) Petropavlovsk-Kamchatsky - Old"
                },
                new TimeZone()
                {
                    Name = "Tonga Standard Time",
                    Abbreviation = "TST",
                    Offset = 13,
                    UseDST = false,
                    Text = "(UTC+13:00) Nuku'alofa"
                },
                new TimeZone()
                {
                    Name = "Samoa Standard Time",
                    Abbreviation = "SST",
                    Offset = 13,
                    UseDST = false,
                    Text = "(UTC+13:00) Samoa"
                });
            #endregion

            # region Add countries
            context.Countries.AddOrUpdate(
                c => c.Code,
                new Country() {Name = "Afghanistan", Code = "AF"},
                new Country() {Name = "Åland Islands", Code = "AX" },
                new Country() {Name = "Albania", Code = "AL"},
                new Country() {Name = "Algeria", Code = "DZ"},
                new Country() {Name = "American Samoa", Code = "AS"},
                new Country() {Name = "Andorra", Code = "AD"},
                new Country() {Name = "Angola", Code = "AO"},
                new Country() {Name = "Anguilla", Code = "AI"},
                new Country() {Name = "Antarctica", Code = "AQ"},
                new Country() {Name = "Antigua and Barbuda", Code = "AG"},
                new Country() {Name = "Argentina", Code = "AR"},
                new Country() {Name = "Armenia", Code = "AM"},
                new Country() {Name = "Aruba", Code = "AW"},
                new Country() {Name = "Australia", Code = "AU"},
                new Country() {Name = "Austria", Code = "AT"},
                new Country() {Name = "Azerbaijan", Code = "AZ"},
                new Country() {Name = "Bahamas", Code = "BS"},
                new Country() {Name = "Bahrain", Code = "BH"},
                new Country() {Name = "Bangladesh", Code = "BD"},
                new Country() {Name = "Barbados", Code = "BB"},
                new Country() {Name = "Belarus", Code = "BY"},
                new Country() {Name = "Belgium", Code = "BE"},
                new Country() {Name = "Belize", Code = "BZ"},
                new Country() {Name = "Benin", Code = "BJ"},
                new Country() {Name = "Bermuda", Code = "BM"},
                new Country() {Name = "Bhutan", Code = "BT"},
                new Country() {Name = "Bolivia", Code = "BO"},
                new Country() {Name = "Bosnia and Herzegovina", Code = "BA"},
                new Country() {Name = "Botswana", Code = "BW"},
                new Country() {Name = "Bouvet Island", Code = "BV"},
                new Country() {Name = "Brazil", Code = "BR"},
                new Country() {Name = "British Indian Ocean Territory", Code = "IO"},
                new Country() {Name = "Brunei Darussalam", Code = "BN"},
                new Country() {Name = "Bulgaria", Code = "BG"},
                new Country() {Name = "Burkina Faso", Code = "BF"},
                new Country() {Name = "Burundi", Code = "BI"},
                new Country() {Name = "Cambodia", Code = "KH"},
                new Country() {Name = "Cameroon", Code = "CM"},
                new Country() {Name = "Canada", Code = "CA"},
                new Country() {Name = "Cape Verde", Code = "CV"},
                new Country() {Name = "Cayman Islands", Code = "KY"},
                new Country() {Name = "Central African Republic", Code = "CF"},
                new Country() {Name = "Chad", Code = "TD"},
                new Country() {Name = "Chile", Code = "CL"},
                new Country() {Name = "China", Code = "CN"},
                new Country() {Name = "Christmas Island", Code = "CX"},
                new Country() {Name = "Cocos (Keeling) Islands", Code = "CC"},
                new Country() {Name = "Colombia", Code = "CO"},
                new Country() {Name = "Comoros", Code = "KM"},
                new Country() {Name = "Congo", Code = "CG"},
                new Country() {Name = "Congo, The Democratic Republic of the", Code = "CD"},
                new Country() {Name = "Cook Islands", Code = "CK"},
                new Country() {Name = "Costa Rica", Code = "CR"},
                new Country() {Name = " Côte d'Ivoire", Code = "CI" },
                new Country() {Name = "Croatia", Code = "HR"},
                new Country() {Name = "Cuba", Code = "CU"},
                new Country() {Name = "Cyprus", Code = "CY"},
                new Country() {Name = "Czech Republic", Code = "CZ"},
                new Country() {Name = "Denmark", Code = "DK"},
                new Country() {Name = "Djibouti", Code = "DJ"},
                new Country() {Name = "Dominica", Code = "DM"},
                new Country() {Name = "Dominican Republic", Code = "DO"},
                new Country() {Name = "Ecuador", Code = "EC"},
                new Country() {Name = "Egypt", Code = "EG"},
                new Country() {Name = "El Salvador", Code = "SV"},
                new Country() {Name = "Equatorial Guinea", Code = "GQ"},
                new Country() {Name = "Eritrea", Code = "ER"},
                new Country() {Name = "Estonia", Code = "EE"},
                new Country() {Name = "Ethiopia", Code = "ET"},
                new Country() {Name = "Falkland Islands (Malvinas)", Code = "FK"},
                new Country() {Name = "Faroe Islands", Code = "FO"},
                new Country() {Name = "Fiji", Code = "FJ"},
                new Country() {Name = "Finland", Code = "FI"},
                new Country() {Name = "France", Code = "FR"},
                new Country() {Name = "French Guiana", Code = "GF"},
                new Country() {Name = "French Polynesia", Code = "PF"},
                new Country() {Name = "French Southern Territories", Code = "TF"},
                new Country() {Name = "Gabon", Code = "GA"},
                new Country() {Name = "Gambia", Code = "GM"},
                new Country() {Name = "Georgia", Code = "GE"},
                new Country() {Name = "Germany", Code = "DE"},
                new Country() {Name = "Ghana", Code = "GH"},
                new Country() {Name = "Gibraltar", Code = "GI"},
                new Country() {Name = "Greece", Code = "GR"},
                new Country() {Name = "Greenland", Code = "GL"},
                new Country() {Name = "Grenada", Code = "GD"},
                new Country() {Name = "Guadeloupe", Code = "GP"},
                new Country() {Name = "Guam", Code = "GU"},
                new Country() {Name = "Guatemala", Code = "GT"},
                new Country() {Name = "Guernsey", Code = "GG"},
                new Country() {Name = "Guinea", Code = "GN"},
                new Country() {Name = "Guinea-Bissau", Code = "GW"},
                new Country() {Name = "Guyana", Code = "GY"},
                new Country() {Name = "Haiti", Code = "HT"},
                new Country() {Name = "Heard Island and Mcdonald Islands", Code = "HM"},
                new Country() {Name = "Holy See (Vatican City State)", Code = "VA"},
                new Country() {Name = "Honduras", Code = "HN"},
                new Country() {Name = "Hong Kong", Code = "HK"},
                new Country() {Name = "Hungary", Code = "HU"},
                new Country() {Name = "Iceland", Code = "IS"},
                new Country() {Name = "India", Code = "IN"},
                new Country() {Name = "Indonesia", Code = "ID"},
                new Country() {Name = "Iran, Islamic Republic Of", Code = "IR"},
                new Country() {Name = "Iraq", Code = "IQ"},
                new Country() {Name = "Ireland", Code = "IE"},
                new Country() {Name = "Isle of Man", Code = "IM"},
                new Country() {Name = "Israel", Code = "IL"},
                new Country() {Name = "Italy", Code = "IT"},
                new Country() {Name = "Jamaica", Code = "JM"},
                new Country() {Name = "Japan", Code = "JP"},
                new Country() {Name = "Jersey", Code = "JE"},
                new Country() {Name = "Jordan", Code = "JO"},
                new Country() {Name = "Kazakhstan", Code = "KZ"},
                new Country() {Name = "Kenya", Code = "KE"},
                new Country() {Name = "Kiribati", Code = "KI"},
                new Country() {Name = "Korea, Democratic People's Republic of", Code = "KP"},
                new Country() {Name = "Korea, Republic of", Code = "KR"},
                new Country() {Name = "Kuwait", Code = "KW"},
                new Country() {Name = "Kyrgyzstan", Code = "KG"},
                new Country() {Name = "Lao People\"S Democratic Republic", Code = "LA"},
                new Country() {Name = "Latvia", Code = "LV"},
                new Country() {Name = "Lebanon", Code = "LB"},
                new Country() {Name = "Lesotho", Code = "LS"},
                new Country() {Name = "Liberia", Code = "LR"},
                new Country() {Name = "Libyan Arab Jamahiriya", Code = "LY"},
                new Country() {Name = "Liechtenstein", Code = "LI"},
                new Country() {Name = "Lithuania", Code = "LT"},
                new Country() {Name = "Luxembourg", Code = "LU"},
                new Country() {Name = "Macao", Code = "MO"},
                new Country() {Name = "Macedonia, The Former Yugoslav Republic of", Code = "MK"},
                new Country() {Name = "Madagascar", Code = "MG"},
                new Country() {Name = "Malawi", Code = "MW"},
                new Country() {Name = "Malaysia", Code = "MY"},
                new Country() {Name = "Maldives", Code = "MV"},
                new Country() {Name = "Mali", Code = "ML"},
                new Country() {Name = "Malta", Code = "MT"},
                new Country() {Name = "Marshall Islands", Code = "MH"},
                new Country() {Name = "Martinique", Code = "MQ"},
                new Country() {Name = "Mauritania", Code = "MR"},
                new Country() {Name = "Mauritius", Code = "MU"},
                new Country() {Name = "Mayotte", Code = "YT"},
                new Country() {Name = "Mexico", Code = "MX"},
                new Country() {Name = "Micronesia, Federated States of", Code = "FM"},
                new Country() {Name = "Moldova, Republic of", Code = "MD"},
                new Country() {Name = "Monaco", Code = "MC"},
                new Country() {Name = "Mongolia", Code = "MN"},
                new Country() {Name = "Montserrat", Code = "MS"},
                new Country() {Name = "Morocco", Code = "MA"},
                new Country() {Name = "Mozambique", Code = "MZ"},
                new Country() {Name = "Myanmar", Code = "MM"},
                new Country() {Name = "Namibia", Code = "NA"},
                new Country() {Name = "Nauru", Code = "NR"},
                new Country() {Name = "Nepal", Code = "NP"},
                new Country() {Name = "Netherlands", Code = "NL"},
                new Country() {Name = "Netherlands Antilles", Code = "AN"},
                new Country() {Name = "New Caledonia", Code = "NC"},
                new Country() {Name = "New Zealand", Code = "NZ"},
                new Country() {Name = "Nicaragua", Code = "NI"},
                new Country() {Name = "Niger", Code = "NE"},
                new Country() {Name = "Nigeria", Code = "NG"},
                new Country() {Name = "Niue", Code = "NU"},
                new Country() {Name = "Norfolk Island", Code = "NF"},
                new Country() {Name = "Northern Mariana Islands", Code = "MP"},
                new Country() {Name = "Norway", Code = "NO"},
                new Country() {Name = "Oman", Code = "OM"},
                new Country() {Name = "Pakistan", Code = "PK"},
                new Country() {Name = "Palau", Code = "PW"},
                new Country() {Name = "Palestinian Territory, Occupied", Code = "PS"},
                new Country() {Name = "Panama", Code = "PA"},
                new Country() {Name = "Papua New Guinea", Code = "PG"},
                new Country() {Name = "Paraguay", Code = "PY"},
                new Country() {Name = "Peru", Code = "PE"},
                new Country() {Name = "Philippines", Code = "PH"},
                new Country() {Name = "Pitcairn", Code = "PN"},
                new Country() {Name = "Poland", Code = "PL"},
                new Country() {Name = "Portugal", Code = "PT"},
                new Country() {Name = "Puerto Rico", Code = "PR"},
                new Country() {Name = "Qatar", Code = "QA"},
                new Country() {Name = "Reunion", Code = "RE"},
                new Country() {Name = "Romania", Code = "RO"},
                new Country() {Name = "Russian Federation", Code = "RU"},
                new Country() {Name = "Rwanda", Code = "RW"},
                new Country() {Name = "Saint Helena", Code = "SH"},
                new Country() {Name = "Saint Kitts and Nevis", Code = "KN"},
                new Country() {Name = "Saint Lucia", Code = "LC"},
                new Country() {Name = "Saint Pierre and Miquelon", Code = "PM"},
                new Country() {Name = "Saint Vincent and the Grenadines", Code = "VC"},
                new Country() {Name = "Samoa", Code = "WS"},
                new Country() {Name = "San Marino", Code = "SM"},
                new Country() {Name = "Sao Tome and Principe", Code = "ST"},
                new Country() {Name = "Saudi Arabia", Code = "SA"},
                new Country() {Name = "Senegal", Code = "SN"},
                new Country() {Name = "Serbia and Montenegro", Code = "CS"},
                new Country() {Name = "Seychelles", Code = "SC"},
                new Country() {Name = "Sierra Leone", Code = "SL"},
                new Country() {Name = "Singapore", Code = "SG"},
                new Country() {Name = "Slovakia", Code = "SK"},
                new Country() {Name = "Slovenia", Code = "SI"},
                new Country() {Name = "Solomon Islands", Code = "SB"},
                new Country() {Name = "Somalia", Code = "SO"},
                new Country() {Name = "South Africa", Code = "ZA"},
                new Country() {Name = "South Georgia and the South Sandwich Islands", Code = "GS"},
                new Country() {Name = "Spain", Code = "ES"},
                new Country() {Name = "Sri Lanka", Code = "LK"},
                new Country() {Name = "Sudan", Code = "SD"},
                new Country() {Name = "Suriname", Code = "SR"},
                new Country() {Name = "Svalbard and Jan Mayen", Code = "SJ"},
                new Country() {Name = "Swaziland", Code = "SZ"},
                new Country() {Name = "Sweden", Code = "SE"},
                new Country() {Name = "Switzerland", Code = "CH"},
                new Country() {Name = "Syrian Arab Republic", Code = "SY"},
                new Country() {Name = "Taiwan, Province of China", Code = "TW"},
                new Country() {Name = "Tajikistan", Code = "TJ"},
                new Country() {Name = "Tanzania, United Republic of", Code = "TZ"},
                new Country() {Name = "Thailand", Code = "TH"},
                new Country() {Name = "Timor-Leste", Code = "TL"},
                new Country() {Name = "Togo", Code = "TG"},
                new Country() {Name = "Tokelau", Code = "TK"},
                new Country() {Name = "Tonga", Code = "TO"},
                new Country() {Name = "Trinidad and Tobago", Code = "TT"},
                new Country() {Name = "Tunisia", Code = "TN"},
                new Country() {Name = "Turkey", Code = "TR"},
                new Country() {Name = "Turkmenistan", Code = "TM"},
                new Country() {Name = "Turks and Caicos Islands", Code = "TC"},
                new Country() {Name = "Tuvalu", Code = "TV"},
                new Country() {Name = "Uganda", Code = "UG"},
                new Country() {Name = "Ukraine", Code = "UA"},
                new Country() {Name = "United Arab Emirates", Code = "AE"},
                new Country() {Name = "United Kingdom", Code = "GB"},
                new Country() {Name = "United States", Code = "US"},
                new Country() {Name = "United States Minor Outlying Islands", Code = "UM"},
                new Country() {Name = "Uruguay", Code = "UY"},
                new Country() {Name = "Uzbekistan", Code = "UZ"},
                new Country() {Name = "Vanuatu", Code = "VU"},
                new Country() {Name = "Venezuela", Code = "VE"},
                new Country() {Name = "Viet Nam", Code = "VN"},
                new Country() {Name = "Virgin Islands, British", Code = "VG"},
                new Country() {Name = "Virgin Islands, U.S.", Code = "VI"},
                new Country() {Name = "Wallis and Futuna", Code = "WF"},
                new Country() {Name = "Western Sahara", Code = "EH"},
                new Country() {Name = "Yemen", Code = "YE"},
                new Country() {Name = "Zambia", Code = "ZM"},
                new Country() {Name = "Zimbabwe", Code = "ZW"});
            #endregion

            //var norway = context.Countries.FirstOrDefault(p => p.Code == "NO");
            //var timeZone = context.TimeZones.Find(2);

            //var egersund = new Site()
            //{
            //    City = "Egersund",
            //    Country = norway,
            //    TimeZone = timeZone,
            //    Name = "Skjevoldsvik"
            //};
            //var stavanger = new Site()
            //{
            //    City = "Stavanger",
            //    Country = norway,
            //    TimeZone = timeZone,
            //    Name = "Pyntesundet"
            //};
            //context.Sites.AddOrUpdate(
            //    p => p.Name,
            //    egersund,
            //    stavanger);
        }
    }
}

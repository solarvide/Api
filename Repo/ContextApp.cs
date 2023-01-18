using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Context.Repo
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ConfigurationTag>().HasData(
                new ConfigurationTag
                {
                    Id = 1,
                    Tag = "default_user_type_id",
                    Description = "default_user_type_id",
                    Value = "1",
                },
                new ConfigurationTag
                {
                    Id = 2,
                    Tag = "default_user_type_abreviations",
                    Description = "default_user_type_abreviations",
                    Value = "MB",
                },
                new ConfigurationTag
                {
                    Id=3,
                    Tag= "default_percent_compress",
                    Description= "default_percent_compress",
                    Value = "60"
                }
                );
            modelBuilder.Entity<UserType>().HasData(
                new UserType
                {
                    Id = 1,
                    Abbreviation = "MB",
                    Name = "Membro",
                    CreatedOn = DateTime.Now,
                    Deleted = false
                },
                  new UserType
                  {
                      Id = 2,
                      Abbreviation = "ADM",
                      Name = "Adminitrator",
                      CreatedOn = DateTime.Now,
                      Deleted = false
                  });
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Abbreviation = "BR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Brazil",
                },
                new Country
                {
                    Id = 2,
                    Abbreviation = "AF",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Afghanistan",
                },
                new Country
                {
                    Id = 3,
                    Abbreviation = "AL",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Albania",
                },
                new Country
                {
                    Id = 4,
                    Abbreviation = "DZ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Algeria",
                },
                new Country
                {
                    Id = 5,
                    Abbreviation = "AS",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "American Samoa",
                },
                new Country
                {
                    Id = 6,
                    Abbreviation = "AD",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Andorra",
                },
                new Country
                {
                    Id = 7,
                    Abbreviation = "AO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Angola",
                },
                new Country
                {
                    Id = 8,
                    Abbreviation = "AI",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Anguilla",
                },
                new Country
                {
                    Id = 9,
                    Abbreviation = "AQ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Antarctica",
                },
                new Country
                {
                    Id = 10,
                    Abbreviation = "AG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Antigua and Barbuda",
                },
                new Country
                {
                    Id = 11,
                    Abbreviation = "AR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Argentina",
                },
                new Country
                {
                    Id = 12,
                    Abbreviation = "AM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Armenia",
                },
                new Country
                {
                    Id = 13,
                    Abbreviation = "AW",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Aruba",
                },
                new Country
                {
                    Id = 14,
                    Abbreviation = "AU",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Australia",
                },
                new Country
                {
                    Id = 15,
                    Abbreviation = "AT",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Austria",
                },
                new Country
                {
                    Id = 16,
                    Abbreviation = "AZ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Azerbaijan",
                },
                new Country
                {
                    Id = 17,
                    Abbreviation = "BS",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bahamas",
                },
                new Country
                {
                    Id = 18,
                    Abbreviation = "BH",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bahrain",
                },
                new Country
                {
                    Id = 19,
                    Abbreviation = "BD",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bangladesh",
                },
                new Country
                {
                    Id = 20,
                    Abbreviation = "BB",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Barbados",
                },
                new Country
                {
                    Id = 21,
                    Abbreviation = "BY",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Belarus",
                },
                new Country
                {
                    Id = 22,
                    Abbreviation = "BE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Belgium",
                },
                new Country
                {
                    Id = 23,
                    Abbreviation = "BZ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Belize",
                },
                new Country
                {
                    Id = 24,
                    Abbreviation = "BJ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Benin",
                },
                new Country
                {
                    Id = 25,
                    Abbreviation = "BM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bermuda",
                },
                new Country
                {
                    Id = 26,
                    Abbreviation = "BT",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bhutan",
                },
                new Country
                {
                    Id = 27,
                    Abbreviation = "BO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bolivia",
                },
                new Country
                {
                    Id = 28,
                    Abbreviation = "BA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bosnia and Herzegowina",
                },
                new Country
                {
                    Id = 29,
                    Abbreviation = "BW",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Botswana",
                },
                new Country
                {
                    Id = 30,
                    Abbreviation = "BV",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bouvet Island",
                },
                new Country
                {
                    Id = 31,
                    Abbreviation = "IO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "British Indian Ocean Territory",
                },
                new Country
                {
                    Id = 32,
                    Abbreviation = "BN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Brunei Darussalam",
                },
                new Country
                {
                    Id = 33,
                    Abbreviation = "BG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bulgaria",
                },
                new Country
                {
                    Id = 34,
                    Abbreviation = "BF",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Burkina Faso",
                },
                new Country
                {
                    Id = 35,
                    Abbreviation = "BI",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Burundi",
                },
                new Country
                {
                    Id = 36,
                    Abbreviation = "KH",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Cambodia",
                },
                new Country
                {
                    Id = 37,
                    Abbreviation = "CM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Cameroon",
                },
                new Country
                {
                    Id = 38,
                    Abbreviation = "CA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Canada",
                },
                new Country
                {
                    Id = 39,
                    Abbreviation = "CV",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Cape Verde",
                },
                new Country
                {
                    Id = 40,
                    Abbreviation = "KY",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Cayman Islands",
                },
                new Country
                {
                    Id = 41,
                    Abbreviation = "CF",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Central African Republic",
                },
                new Country
                {
                    Id = 42,
                    Abbreviation = "TD",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Chad",
                },
                new Country
                {
                    Id = 43,
                    Abbreviation = "CL",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Chile",
                },
                new Country
                {
                    Id = 44,
                    Abbreviation = "CN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "China",
                },
                new Country
                {
                    Id = 45,
                    Abbreviation = "CX",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Christmas Island",
                },
                new Country
                {
                    Id = 46,
                    Abbreviation = "CC",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Cocos (Keeling) Islands",
                },
                new Country
                {
                    Id = 47,
                    Abbreviation = "CO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Colombia",
                },
                new Country
                {
                    Id = 48,
                    Abbreviation = "KM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Comoros",
                },
                new Country
                {
                    Id = 49,
                    Abbreviation = "CG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Congo",
                },
                new Country
                {
                    Id = 50,
                    Abbreviation = "CD",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Congo, the Democratic Republic of the",
                },
                new Country
                {
                    Id = 51,
                    Abbreviation = "CK",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Cook Islands",
                },
                new Country
                {
                    Id = 52,
                    Abbreviation = "CR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Costa Rica",
                },
                new Country
                {
                    Id = 53,
                    Abbreviation = "CI",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Cote dIvoire",
                },
                new Country
                {
                    Id = 54,
                    Abbreviation = "HR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Croatia (Hrvatska)",
                },
                new Country
                {
                    Id = 55,
                    Abbreviation = "CU",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Cuba",
                },
                new Country
                {
                    Id = 56,
                    Abbreviation = "CY",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Cyprus",
                },
                new Country
                {
                    Id = 57,
                    Abbreviation = "CZ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Czech Republic",
                },
                new Country
                {
                    Id = 58,
                    Abbreviation = "DK",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Denmark",
                },
                new Country
                {
                    Id = 59,
                    Abbreviation = "DJ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Djibouti",
                },
                new Country
                {
                    Id = 60,
                    Abbreviation = "DM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Dominica",
                },
                new Country
                {
                    Id = 61,
                    Abbreviation = "DO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Dominican Republic",
                },
                new Country
                {
                    Id = 62,
                    Abbreviation = "TL",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "East Timor",
                },
                new Country
                {
                    Id = 63,
                    Abbreviation = "EC",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Ecuador",
                },
                new Country
                {
                    Id = 64,
                    Abbreviation = "EG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Egypt",
                },
                new Country
                {
                    Id = 65,
                    Abbreviation = "SV",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "El Salvador",
                },
                new Country
                {
                    Id = 66,
                    Abbreviation = "GQ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Equatorial Guinea",
                },
                new Country
                {
                    Id = 67,
                    Abbreviation = "ER",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Eritrea",
                },
                new Country
                {
                    Id = 68,
                    Abbreviation = "EE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Estonia",
                },
                new Country
                {
                    Id = 69,
                    Abbreviation = "ET",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Ethiopia",
                },
                new Country
                {
                    Id = 70,
                    Abbreviation = "FK",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Falkland Islands (Malvinas)",
                },
                new Country
                {
                    Id = 71,
                    Abbreviation = "FO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Faroe Islands",
                },
                new Country
                {
                    Id = 72,
                    Abbreviation = "FJ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Fiji",
                },
                new Country
                {
                    Id = 73,
                    Abbreviation = "FI",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Finland",
                },
                new Country
                {
                    Id = 74,
                    Abbreviation = "FR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "France",
                },
                new Country
                {
                    Id = 75,
                    Abbreviation = "GF",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "French Guiana",
                },
                new Country
                {
                    Id = 76,
                    Abbreviation = "PF",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "French Polynesia",
                },
                new Country
                {
                    Id = 77,
                    Abbreviation = "TF",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "French Southern Territories",
                },
                new Country
                {
                    Id = 78,
                    Abbreviation = "GA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Gabon",
                },
                new Country
                {
                    Id = 79,
                    Abbreviation = "GM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Gambia",
                },
                new Country
                {
                    Id = 80,
                    Abbreviation = "GE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Georgia",
                },
                new Country
                {
                    Id = 81,
                    Abbreviation = "DE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Germany",
                },
                new Country
                {
                    Id = 82,
                    Abbreviation = "GH",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Ghana",
                },
                new Country
                {
                    Id = 83,
                    Abbreviation = "GI",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Gibraltar",
                },
                new Country
                {
                    Id = 84,
                    Abbreviation = "GR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Greece",
                },
                new Country
                {
                    Id = 85,
                    Abbreviation = "GL",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Greenland",
                },
                new Country
                {
                    Id = 86,
                    Abbreviation = "GD",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Grenada",
                },
                new Country
                {
                    Id = 87,
                    Abbreviation = "GP",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Guadeloupe",
                },
                new Country
                {
                    Id = 88,
                    Abbreviation = "GU",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Guam",
                },
                new Country
                {
                    Id = 89,
                    Abbreviation = "GT",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Guatemala",
                },
                new Country
                {
                    Id = 90,
                    Abbreviation = "GN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Guinea",
                },
                new Country
                {
                    Id = 91,
                    Abbreviation = "GW",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Guinea-Bissau",
                },
                new Country
                {
                    Id = 92,
                    Abbreviation = "GY",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Guyana",
                },
                new Country
                {
                    Id = 93,
                    Abbreviation = "HT",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Haiti",
                },
                new Country
                {
                    Id = 94,
                    Abbreviation = "HM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Heard and Mc Donald Islands",
                },
                new Country
                {
                    Id = 95,
                    Abbreviation = "VA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Holy See (Vatican City State)",
                },
                new Country
                {
                    Id = 96,
                    Abbreviation = "HN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Honduras",
                },
                new Country
                {
                    Id = 97,
                    Abbreviation = "HK",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Hong Kong",
                },
                new Country
                {
                    Id = 98,
                    Abbreviation = "HU",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Hungary",
                },
                new Country
                {
                    Id = 99,
                    Abbreviation = "IS",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Iceland",
                },
                new Country
                {
                    Id = 100,
                    Abbreviation = "IN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "India",
                },
                new Country
                {
                    Id = 101,
                    Abbreviation = "ID",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Indonesia",
                },
                new Country
                {
                    Id = 102,
                    Abbreviation = "IR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Iran (Islamic Republic of)",
                },
                new Country
                {
                    Id = 103,
                    Abbreviation = "IQ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Iraq",
                },
                new Country
                {
                    Id = 104,
                    Abbreviation = "IE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Ireland",
                },
                new Country
                {
                    Id = 105,
                    Abbreviation = "IL",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Israel",
                },
                new Country
                {
                    Id = 106,
                    Abbreviation = "IT",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Italy",
                },
                new Country
                {
                    Id = 107,
                    Abbreviation = "JM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Jamaica",
                },
                new Country
                {
                    Id = 108,
                    Abbreviation = "JP",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Japan",
                },
                new Country
                {
                    Id = 109,
                    Abbreviation = "JO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Jordan",
                },
                new Country
                {
                    Id = 110,
                    Abbreviation = "KZ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Kazakhstan",
                },
                new Country
                {
                    Id = 111,
                    Abbreviation = "KE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Kenya",
                },
                new Country
                {
                    Id = 112,
                    Abbreviation = "KI",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Kiribati",
                },
                new Country
                {
                    Id = 113,
                    Abbreviation = "KP",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Korea, Democratic Peoples Republic of",
                },
                new Country
                {
                    Id = 114,
                    Abbreviation = "KR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Korea, Republic of",
                },
                new Country
                {
                    Id = 115,
                    Abbreviation = "KW",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Kuwait",
                },
                new Country
                {
                    Id = 116,
                    Abbreviation = "KG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Kyrgyzstan",
                },
                new Country
                {
                    Id = 117,
                    Abbreviation = "LA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Lao Peoples Democratic Republic",
                },
                new Country
                {
                    Id = 118,
                    Abbreviation = "LV",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Latvia",
                },
                new Country
                {
                    Id = 119,
                    Abbreviation = "LB",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Lebanon",
                },
                new Country
                {
                    Id = 120,
                    Abbreviation = "LS",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Lesotho",
                },
                new Country
                {
                    Id = 121,
                    Abbreviation = "LR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Liberia",
                },
                new Country
                {
                    Id = 122,
                    Abbreviation = "LY",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Libyan Arab Jamahiriya",
                },
                new Country
                {
                    Id = 123,
                    Abbreviation = "LI",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Liechtenstein",
                },
                new Country
                {
                    Id = 124,
                    Abbreviation = "LT",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Lithuania",
                },
                new Country
                {
                    Id = 125,
                    Abbreviation = "LU",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Luxembourg",
                },
                new Country
                {
                    Id = 126,
                    Abbreviation = "MO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Macau",
                },
                new Country
                {
                    Id = 127,
                    Abbreviation = "MK",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "North Macedonia",
                },
                new Country
                {
                    Id = 128,
                    Abbreviation = "MG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Madagascar",
                },
                new Country
                {
                    Id = 129,
                    Abbreviation = "MW",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Malawi",
                },
                new Country
                {
                    Id = 130,
                    Abbreviation = "MY",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Malaysia",
                },
                new Country
                {
                    Id = 131,
                    Abbreviation = "MV",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Maldives",
                },
                new Country
                {
                    Id = 132,
                    Abbreviation = "ML",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Mali",
                },
                new Country
                {
                    Id = 133,
                    Abbreviation = "MT",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Malta",
                },
                new Country
                {
                    Id = 134,
                    Abbreviation = "MH",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Marshall Islands",
                },
                new Country
                {
                    Id = 135,
                    Abbreviation = "MQ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Martinique",
                },
                new Country
                {
                    Id = 136,
                    Abbreviation = "MR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Mauritania",
                },
                new Country
                {
                    Id = 137,
                    Abbreviation = "MU",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Mauritius",
                },
                new Country
                {
                    Id = 138,
                    Abbreviation = "YT",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Mayotte",
                },
                new Country
                {
                    Id = 139,
                    Abbreviation = "MX",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Mexico",
                },
                new Country
                {
                    Id = 140,
                    Abbreviation = "FM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Micronesia, Federated States of",
                },
                new Country
                {
                    Id = 141,
                    Abbreviation = "MD",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Moldova, Republic of",
                },
                new Country
                {
                    Id = 142,
                    Abbreviation = "MC",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Monaco",
                },
                new Country
                {
                    Id = 143,
                    Abbreviation = "MN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Mongolia",
                },
                new Country
                {
                    Id = 144,
                    Abbreviation = "MS",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Montserrat",
                },
                new Country
                {
                    Id = 145,
                    Abbreviation = "MA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Morocco",
                },
                new Country
                {
                    Id = 146,
                    Abbreviation = "MZ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Mozambique",
                },
                new Country
                {
                    Id = 147,
                    Abbreviation = "MM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Myanmar",
                },
                new Country
                {
                    Id = 148,
                    Abbreviation = "NA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Namibia",
                },
                new Country
                {
                    Id = 149,
                    Abbreviation = "NR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Nauru",
                },
                new Country
                {
                    Id = 150,
                    Abbreviation = "NP",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Nepal",
                },
                new Country
                {
                    Id = 151,
                    Abbreviation = "NL",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Netherlands",
                },
                new Country
                {
                    Id = 152,
                    Abbreviation = "NC",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Caledonia",
                },
                new Country
                {
                    Id = 153,
                    Abbreviation = "NZ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "New Zealand",
                },
                new Country
                {
                    Id = 154,
                    Abbreviation = "NI",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Nicaragua",
                },
                new Country
                {
                    Id = 155,
                    Abbreviation = "NE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Niger",
                },
                new Country
                {
                    Id = 156,
                    Abbreviation = "NG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Nigeria",
                },
                new Country
                {
                    Id = 157,
                    Abbreviation = "NU",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Niue",
                },
                new Country
                {
                    Id = 158,
                    Abbreviation = "NF",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Norfolk Island",
                },
                new Country
                {
                    Id = 159,
                    Abbreviation = "MP",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Northern Mariana Islands",
                },
                new Country
                {
                    Id = 160,
                    Abbreviation = "NO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Norway",
                },
                new Country
                {
                    Id = 161,
                    Abbreviation = "OM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Oman",
                },
                new Country
                {
                    Id = 162,
                    Abbreviation = "PK",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Pakistan",
                },
                new Country
                {
                    Id = 163,
                    Abbreviation = "PW",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Palau",
                },
                new Country
                {
                    Id = 164,
                    Abbreviation = "PA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Panama",
                },
                new Country
                {
                    Id = 165,
                    Abbreviation = "PG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Papua new Guinea",
                },
                new Country
                {
                    Id = 166,
                    Abbreviation = "PY",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Paraguay",
                },
                new Country
                {
                    Id = 167,
                    Abbreviation = "PE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Peru",
                },
                new Country
                {
                    Id = 168,
                    Abbreviation = "PH",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Philippines",
                },
                new Country
                {
                    Id = 169,
                    Abbreviation = "PN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Pitcairn",
                },
                new Country
                {
                    Id = 170,
                    Abbreviation = "PL",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Poland",
                },
                new Country
                {
                    Id = 171,
                    Abbreviation = "PT",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Portugal",
                },
                new Country
                {
                    Id = 172,
                    Abbreviation = "PR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Puerto Rico",
                },
                new Country
                {
                    Id = 173,
                    Abbreviation = "QA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Qatar",
                },
                new Country
                {
                    Id = 174,
                    Abbreviation = "RE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Reunion",
                },
                new Country
                {
                    Id = 175,
                    Abbreviation = "RO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Romania",
                },
                new Country
                {
                    Id = 176,
                    Abbreviation = "RU",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Russian Federation",
                },
                new Country
                {
                    Id = 177,
                    Abbreviation = "RW",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Rwanda",
                },
                new Country
                {
                    Id = 178,
                    Abbreviation = "KN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Saint Kitts and Nevis",
                },
                new Country
                {
                    Id = 179,
                    Abbreviation = "LC",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Saint LUCIA",
                },
                new Country
                {
                    Id = 180,
                    Abbreviation = "VC",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Saint Vincent and the Grenadines",
                },
                new Country
                {
                    Id = 181,
                    Abbreviation = "WS",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Samoa",
                },
                new Country
                {
                    Id = 182,
                    Abbreviation = "SM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "San Marino",
                },
                new Country
                {
                    Id = 183,
                    Abbreviation = "ST",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Sao Tome and Principe",
                },
                new Country
                {
                    Id = 184,
                    Abbreviation = "SA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Saudi Arabia",
                },
                new Country
                {
                    Id = 185,
                    Abbreviation = "SN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Senegal",
                },
                new Country
                {
                    Id = 186,
                    Abbreviation = "SC",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Seychelles",
                },
                new Country
                {
                    Id = 187,
                    Abbreviation = "SL",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Sierra Leone",
                },
                new Country
                {
                    Id = 188,
                    Abbreviation = "SG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Singapore",
                },
                new Country
                {
                    Id = 189,
                    Abbreviation = "SK",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Slovakia (Slovak Republic)",
                },
                new Country
                {
                    Id = 190,
                    Abbreviation = "SI",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Slovenia",
                },
                new Country
                {
                    Id = 191,
                    Abbreviation = "SB",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Solomon Islands",
                },
                new Country
                {
                    Id = 192,
                    Abbreviation = "SO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Somalia",
                },
                new Country
                {
                    Id = 193,
                    Abbreviation = "ZA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "South Africa",
                },
                new Country
                {
                    Id = 194,
                    Abbreviation = "GS",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "South Georgia and the South Sandwich Islands",
                },
                new Country
                {
                    Id = 195,
                    Abbreviation = "ES",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Spain",
                },
                new Country
                {
                    Id = 196,
                    Abbreviation = "LK",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Sri Lanka",
                },
                new Country
                {
                    Id = 197,
                    Abbreviation = "SH",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "St. Helena",
                },
                new Country
                {
                    Id = 198,
                    Abbreviation = "PM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "St. Pierre and Miquelon",
                },
                new Country
                {
                    Id = 199,
                    Abbreviation = "SD",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Sudan",

                },
                new Country
                {
                    Id = 200,
                    Abbreviation = "SR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Suriname",
                },
                new Country
                {
                    Id = 201,
                    Abbreviation = "SJ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Svalbard and Jan Mayen Islands",
                },
                new Country
                {
                    Id = 202,
                    Abbreviation = "SZ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Swaziland",
                },
                new Country
                {
                    Id = 203,
                    Abbreviation = "SE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Sweden",
                },
                new Country
                {
                    Id = 204,
                    Abbreviation = "CH",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Switzerland",
                },
                new Country
                {
                    Id = 205,
                    Abbreviation = "SY",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Syrian Arab Republic",
                },
                new Country
                {
                    Id = 206,
                    Abbreviation = "TW",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Taiwan, Province of China",
                },
                new Country
                {
                    Id = 207,
                    Abbreviation = "TJ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Tajikistan",
                },
                new Country
                {
                    Id = 208,
                    Abbreviation = "TZ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Tanzania, United Republic of",
                },
                new Country
                {
                    Id = 209,
                    Abbreviation = "TH",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Thailand",
                },
                new Country
                {
                    Id = 210,
                    Abbreviation = "TG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Togo",
                },
                new Country
                {
                    Id = 211,
                    Abbreviation = "TK",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Tokelau",
                },
                new Country
                {
                    Id = 212,
                    Abbreviation = "TO",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Tonga",
                },
                new Country
                {
                    Id = 213,
                    Abbreviation = "TT",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Trinidad and Tobago",
                },
                new Country
                {
                    Id = 214,
                    Abbreviation = "TN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Tunisia",
                },
                new Country
                {
                    Id = 215,
                    Abbreviation = "TR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Turkey",
                },
                new Country
                {
                    Id = 216,
                    Abbreviation = "TM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Turkmenistan",
                },
                new Country
                {
                    Id = 217,
                    Abbreviation = "TC",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Turks and Caicos Islands",
                },
                new Country
                {
                    Id = 218,
                    Abbreviation = "TV",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Tuvalu",
                },
                new Country
                {
                    Id = 219,
                    Abbreviation = "UG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Uganda",
                },
                new Country
                {
                    Id = 220,
                    Abbreviation = "UA",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Ukraine",
                },
                new Country
                {
                    Id = 221,
                    Abbreviation = "AE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "United Arab Emirates",
                },
                new Country
                {
                    Id = 222,
                    Abbreviation = "GB",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "United Kingdom",
                },
                new Country
                {
                    Id = 223,
                    Abbreviation = "US",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "United States",
                },
                new Country
                {
                    Id = 224,
                    Abbreviation = "UM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "United States Minor Outlying Islands",
                },
                new Country
                {
                    Id = 225,
                    Abbreviation = "UY",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Uruguay",
                },
                new Country
                {
                    Id = 226,
                    Abbreviation = "UZ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Uzbekistan",
                },
                new Country
                {
                    Id = 227,
                    Abbreviation = "VU",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Vanuatu",
                },
                new Country
                {
                    Id = 228,
                    Abbreviation = "VE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Venezuela",
                },
                new Country
                {
                    Id = 229,
                    Abbreviation = "VN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Viet Nam",
                },
                new Country
                {
                    Id = 230,
                    Abbreviation = "VG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Virgin Islands (British)",
                },
                new Country
                {
                    Id = 231,
                    Abbreviation = "VI",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Virgin Islands (U.S.)",
                },
                new Country
                {
                    Id = 232,
                    Abbreviation = "WF",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Wallis and Futuna Islands",
                },
                new Country
                {
                    Id = 233,
                    Abbreviation = "EH",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Western Sahara",
                },
                new Country
                {
                    Id = 234,
                    Abbreviation = "YE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Yemen",
                },
                new Country
                {
                    Id = 235,
                    Abbreviation = "YU",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Yugoslavia",
                },
                new Country
                {
                    Id = 236,
                    Abbreviation = "ZM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Zambia",
                },
                new Country
                {
                    Id = 237,
                    Abbreviation = "ZW",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Zimbabwe",
                },
                new Country
                {
                    Id = 238,
                    Abbreviation = "GG",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bailiwick of Guernsey",
                },
                new Country
                {
                    Id = 239,
                    Abbreviation = "JE",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bailiwick of Jersey",
                },
                new Country
                {
                    Id = 240,
                    Abbreviation = "IM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Isle of Man",
                },
                new Country
                {
                    Id = 241,
                    Abbreviation = "ME",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Crna Gora (Montenegro)",
                },
                new Country
                {
                    Id = 242,
                    Abbreviation = "RS",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "SÉRVIA",
                },
                new Country
                {
                    Id = 243,
                    Abbreviation = "SS",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Republic of South Sudan",
                },
                new Country
                {
                    Id = 244,
                    Abbreviation = "N",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Zona del Canal de Panamá",
                },
                new Country
                {
                    Id = 245,
                    Abbreviation = "PS",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Dawlat Filas?in",
                },
                new Country
                {
                    Id = 246,
                    Abbreviation = "AX",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Åland Islands",
                },
                new Country
                {
                    Id = 247,
                    Abbreviation = "CW",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Curaçao",
                },
                new Country
                {
                    Id = 248,
                    Abbreviation = "SM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Saint Martin",
                },
                new Country
                {
                    Id = 249,
                    Abbreviation = "AN",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Bonaire",
                },
                new Country
                {
                    Id = 250,
                    Abbreviation = "AQ",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Antartica",
                },
                new Country
                {
                    Id = 251,
                    Abbreviation = "AU",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Heard Island and McDonald Islands",
                },
                new Country
                {
                    Id = 252,
                    Abbreviation = "FR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Saint-Barthélemy",
                },
                new Country
                {
                    Id = 253,
                    Abbreviation = "SM",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Saint Martin",
                },
                new Country
                {
                    Id = 254,
                    Abbreviation = "TF",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Terres Australes et Antarctiques Françaises",
                });


            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            modelBuilder.Entity<LanguageTag>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<CodeValidation>();
            modelBuilder.Entity<PushNotificationKey>();

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<ConfigurationTag> ConfigurationTags { get; set; }
        public DbSet<LanguageTag> LanguageTags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CodeValidation> CodeValidations { get; set; }
        public DbSet<PushNotificationKey> PushNotificationKeys { get; set; }
    }
}

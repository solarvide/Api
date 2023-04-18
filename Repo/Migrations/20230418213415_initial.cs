using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distric = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationTags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhonePrefix = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageTags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHtml = table.Column<bool>(type: "bit", nullable: false),
                    Usage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsApp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Average = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Archive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProposalHistoricEletrics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proposalId = table.Column<long>(type: "bigint", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", maxLength: 4000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalHistoricEletrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProposalHistoricEletrics_Proposal_proposalId",
                        column: x => x.proposalId,
                        principalTable: "Proposal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DocNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EmailValidated = table.Column<bool>(type: "bit", nullable: true),
                    UserTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactory = table.Column<bool>(type: "bit", nullable: true),
                    TwoFactorySecret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CodeValidations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidationCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeValidations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeValidations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PushNotificationKeys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PushKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushNotificationKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PushNotificationKeys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ConfigurationTags",
                columns: new[] { "Id", "Description", "Tag", "Value" },
                values: new object[,]
                {
                    { 1L, "default_user_type_id", "default_user_type_id", "1" },
                    { 2L, "default_user_type_abreviations", "default_user_type_abreviations", "RP" },
                    { 3L, "default_percent_compress", "default_percent_compress", "60" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Deleted", "Name", "PhonePrefix" },
                values: new object[,]
                {
                    { 1L, "BR", false, "Brazil", 1 },
                    { 2L, "AF", false, "Afghanistan", 1 },
                    { 3L, "AL", false, "Albania", 1 },
                    { 4L, "DZ", false, "Algeria", 1 },
                    { 5L, "AS", false, "American Samoa", 1 },
                    { 6L, "AD", false, "Andorra", 1 },
                    { 7L, "AO", false, "Angola", 1 },
                    { 8L, "AI", false, "Anguilla", 1 },
                    { 9L, "AQ", false, "Antarctica", 1 },
                    { 10L, "AG", false, "Antigua and Barbuda", 1 },
                    { 11L, "AR", false, "Argentina", 1 },
                    { 12L, "AM", false, "Armenia", 1 },
                    { 13L, "AW", false, "Aruba", 1 },
                    { 14L, "AU", false, "Australia", 1 },
                    { 15L, "AT", false, "Austria", 1 },
                    { 16L, "AZ", false, "Azerbaijan", 1 },
                    { 17L, "BS", false, "Bahamas", 1 },
                    { 18L, "BH", false, "Bahrain", 1 },
                    { 19L, "BD", false, "Bangladesh", 1 },
                    { 20L, "BB", false, "Barbados", 1 },
                    { 21L, "BY", false, "Belarus", 1 },
                    { 22L, "BE", false, "Belgium", 1 },
                    { 23L, "BZ", false, "Belize", 1 },
                    { 24L, "BJ", false, "Benin", 1 },
                    { 25L, "BM", false, "Bermuda", 1 },
                    { 26L, "BT", false, "Bhutan", 1 },
                    { 27L, "BO", false, "Bolivia", 1 },
                    { 28L, "BA", false, "Bosnia and Herzegowina", 1 },
                    { 29L, "BW", false, "Botswana", 1 },
                    { 30L, "BV", false, "Bouvet Island", 1 },
                    { 31L, "IO", false, "British Indian Ocean Territory", 1 },
                    { 32L, "BN", false, "Brunei Darussalam", 1 },
                    { 33L, "BG", false, "Bulgaria", 1 },
                    { 34L, "BF", false, "Burkina Faso", 1 },
                    { 35L, "BI", false, "Burundi", 1 },
                    { 36L, "KH", false, "Cambodia", 1 },
                    { 37L, "CM", false, "Cameroon", 1 },
                    { 38L, "CA", false, "Canada", 1 },
                    { 39L, "CV", false, "Cape Verde", 1 }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Deleted", "Name", "PhonePrefix" },
                values: new object[,]
                {
                    { 40L, "KY", false, "Cayman Islands", 1 },
                    { 41L, "CF", false, "Central African Republic", 1 },
                    { 42L, "TD", false, "Chad", 1 },
                    { 43L, "CL", false, "Chile", 1 },
                    { 44L, "CN", false, "China", 1 },
                    { 45L, "CX", false, "Christmas Island", 1 },
                    { 46L, "CC", false, "Cocos (Keeling) Islands", 1 },
                    { 47L, "CO", false, "Colombia", 1 },
                    { 48L, "KM", false, "Comoros", 1 },
                    { 49L, "CG", false, "Congo", 1 },
                    { 50L, "CD", false, "Congo, the Democratic Republic of the", 1 },
                    { 51L, "CK", false, "Cook Islands", 1 },
                    { 52L, "CR", false, "Costa Rica", 1 },
                    { 53L, "CI", false, "Cote dIvoire", 1 },
                    { 54L, "HR", false, "Croatia (Hrvatska)", 1 },
                    { 55L, "CU", false, "Cuba", 1 },
                    { 56L, "CY", false, "Cyprus", 1 },
                    { 57L, "CZ", false, "Czech Republic", 1 },
                    { 58L, "DK", false, "Denmark", 1 },
                    { 59L, "DJ", false, "Djibouti", 1 },
                    { 60L, "DM", false, "Dominica", 1 },
                    { 61L, "DO", false, "Dominican Republic", 1 },
                    { 62L, "TL", false, "East Timor", 1 },
                    { 63L, "EC", false, "Ecuador", 1 },
                    { 64L, "EG", false, "Egypt", 1 },
                    { 65L, "SV", false, "El Salvador", 1 },
                    { 66L, "GQ", false, "Equatorial Guinea", 1 },
                    { 67L, "ER", false, "Eritrea", 1 },
                    { 68L, "EE", false, "Estonia", 1 },
                    { 69L, "ET", false, "Ethiopia", 1 },
                    { 70L, "FK", false, "Falkland Islands (Malvinas)", 1 },
                    { 71L, "FO", false, "Faroe Islands", 1 },
                    { 72L, "FJ", false, "Fiji", 1 },
                    { 73L, "FI", false, "Finland", 1 },
                    { 74L, "FR", false, "France", 1 },
                    { 75L, "GF", false, "French Guiana", 1 },
                    { 76L, "PF", false, "French Polynesia", 1 },
                    { 77L, "TF", false, "French Southern Territories", 1 },
                    { 78L, "GA", false, "Gabon", 1 },
                    { 79L, "GM", false, "Gambia", 1 },
                    { 80L, "GE", false, "Georgia", 1 },
                    { 81L, "DE", false, "Germany", 1 }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Deleted", "Name", "PhonePrefix" },
                values: new object[,]
                {
                    { 82L, "GH", false, "Ghana", 1 },
                    { 83L, "GI", false, "Gibraltar", 1 },
                    { 84L, "GR", false, "Greece", 1 },
                    { 85L, "GL", false, "Greenland", 1 },
                    { 86L, "GD", false, "Grenada", 1 },
                    { 87L, "GP", false, "Guadeloupe", 1 },
                    { 88L, "GU", false, "Guam", 1 },
                    { 89L, "GT", false, "Guatemala", 1 },
                    { 90L, "GN", false, "Guinea", 1 },
                    { 91L, "GW", false, "Guinea-Bissau", 1 },
                    { 92L, "GY", false, "Guyana", 1 },
                    { 93L, "HT", false, "Haiti", 1 },
                    { 94L, "HM", false, "Heard and Mc Donald Islands", 1 },
                    { 95L, "VA", false, "Holy See (Vatican City State)", 1 },
                    { 96L, "HN", false, "Honduras", 1 },
                    { 97L, "HK", false, "Hong Kong", 1 },
                    { 98L, "HU", false, "Hungary", 1 },
                    { 99L, "IS", false, "Iceland", 1 },
                    { 100L, "IN", false, "India", 1 },
                    { 101L, "ID", false, "Indonesia", 1 },
                    { 102L, "IR", false, "Iran (Islamic Republic of)", 1 },
                    { 103L, "IQ", false, "Iraq", 1 },
                    { 104L, "IE", false, "Ireland", 1 },
                    { 105L, "IL", false, "Israel", 1 },
                    { 106L, "IT", false, "Italy", 1 },
                    { 107L, "JM", false, "Jamaica", 1 },
                    { 108L, "JP", false, "Japan", 1 },
                    { 109L, "JO", false, "Jordan", 1 },
                    { 110L, "KZ", false, "Kazakhstan", 1 },
                    { 111L, "KE", false, "Kenya", 1 },
                    { 112L, "KI", false, "Kiribati", 1 },
                    { 113L, "KP", false, "Korea, Democratic Peoples Republic of", 1 },
                    { 114L, "KR", false, "Korea, Republic of", 1 },
                    { 115L, "KW", false, "Kuwait", 1 },
                    { 116L, "KG", false, "Kyrgyzstan", 1 },
                    { 117L, "LA", false, "Lao Peoples Democratic Republic", 1 },
                    { 118L, "LV", false, "Latvia", 1 },
                    { 119L, "LB", false, "Lebanon", 1 },
                    { 120L, "LS", false, "Lesotho", 1 },
                    { 121L, "LR", false, "Liberia", 1 },
                    { 122L, "LY", false, "Libyan Arab Jamahiriya", 1 },
                    { 123L, "LI", false, "Liechtenstein", 1 }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Deleted", "Name", "PhonePrefix" },
                values: new object[,]
                {
                    { 124L, "LT", false, "Lithuania", 1 },
                    { 125L, "LU", false, "Luxembourg", 1 },
                    { 126L, "MO", false, "Macau", 1 },
                    { 127L, "MK", false, "North Macedonia", 1 },
                    { 128L, "MG", false, "Madagascar", 1 },
                    { 129L, "MW", false, "Malawi", 1 },
                    { 130L, "MY", false, "Malaysia", 1 },
                    { 131L, "MV", false, "Maldives", 1 },
                    { 132L, "ML", false, "Mali", 1 },
                    { 133L, "MT", false, "Malta", 1 },
                    { 134L, "MH", false, "Marshall Islands", 1 },
                    { 135L, "MQ", false, "Martinique", 1 },
                    { 136L, "MR", false, "Mauritania", 1 },
                    { 137L, "MU", false, "Mauritius", 1 },
                    { 138L, "YT", false, "Mayotte", 1 },
                    { 139L, "MX", false, "Mexico", 1 },
                    { 140L, "FM", false, "Micronesia, Federated States of", 1 },
                    { 141L, "MD", false, "Moldova, Republic of", 1 },
                    { 142L, "MC", false, "Monaco", 1 },
                    { 143L, "MN", false, "Mongolia", 1 },
                    { 144L, "MS", false, "Montserrat", 1 },
                    { 145L, "MA", false, "Morocco", 1 },
                    { 146L, "MZ", false, "Mozambique", 1 },
                    { 147L, "MM", false, "Myanmar", 1 },
                    { 148L, "NA", false, "Namibia", 1 },
                    { 149L, "NR", false, "Nauru", 1 },
                    { 150L, "NP", false, "Nepal", 1 },
                    { 151L, "NL", false, "Netherlands", 1 },
                    { 152L, "NC", false, "Caledonia", 1 },
                    { 153L, "NZ", false, "New Zealand", 1 },
                    { 154L, "NI", false, "Nicaragua", 1 },
                    { 155L, "NE", false, "Niger", 1 },
                    { 156L, "NG", false, "Nigeria", 1 },
                    { 157L, "NU", false, "Niue", 1 },
                    { 158L, "NF", false, "Norfolk Island", 1 },
                    { 159L, "MP", false, "Northern Mariana Islands", 1 },
                    { 160L, "NO", false, "Norway", 1 },
                    { 161L, "OM", false, "Oman", 1 },
                    { 162L, "PK", false, "Pakistan", 1 },
                    { 163L, "PW", false, "Palau", 1 },
                    { 164L, "PA", false, "Panama", 1 },
                    { 165L, "PG", false, "Papua new Guinea", 1 }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Deleted", "Name", "PhonePrefix" },
                values: new object[,]
                {
                    { 166L, "PY", false, "Paraguay", 1 },
                    { 167L, "PE", false, "Peru", 1 },
                    { 168L, "PH", false, "Philippines", 1 },
                    { 169L, "PN", false, "Pitcairn", 1 },
                    { 170L, "PL", false, "Poland", 1 },
                    { 171L, "PT", false, "Portugal", 1 },
                    { 172L, "PR", false, "Puerto Rico", 1 },
                    { 173L, "QA", false, "Qatar", 1 },
                    { 174L, "RE", false, "Reunion", 1 },
                    { 175L, "RO", false, "Romania", 1 },
                    { 176L, "RU", false, "Russian Federation", 1 },
                    { 177L, "RW", false, "Rwanda", 1 },
                    { 178L, "KN", false, "Saint Kitts and Nevis", 1 },
                    { 179L, "LC", false, "Saint LUCIA", 1 },
                    { 180L, "VC", false, "Saint Vincent and the Grenadines", 1 },
                    { 181L, "WS", false, "Samoa", 1 },
                    { 182L, "SM", false, "San Marino", 1 },
                    { 183L, "ST", false, "Sao Tome and Principe", 1 },
                    { 184L, "SA", false, "Saudi Arabia", 1 },
                    { 185L, "SN", false, "Senegal", 1 },
                    { 186L, "SC", false, "Seychelles", 1 },
                    { 187L, "SL", false, "Sierra Leone", 1 },
                    { 188L, "SG", false, "Singapore", 1 },
                    { 189L, "SK", false, "Slovakia (Slovak Republic)", 1 },
                    { 190L, "SI", false, "Slovenia", 1 },
                    { 191L, "SB", false, "Solomon Islands", 1 },
                    { 192L, "SO", false, "Somalia", 1 },
                    { 193L, "ZA", false, "South Africa", 1 },
                    { 194L, "GS", false, "South Georgia and the South Sandwich Islands", 1 },
                    { 195L, "ES", false, "Spain", 1 },
                    { 196L, "LK", false, "Sri Lanka", 1 },
                    { 197L, "SH", false, "St. Helena", 1 },
                    { 198L, "PM", false, "St. Pierre and Miquelon", 1 },
                    { 199L, "SD", false, "Sudan", 1 },
                    { 200L, "SR", false, "Suriname", 1 },
                    { 201L, "SJ", false, "Svalbard and Jan Mayen Islands", 1 },
                    { 202L, "SZ", false, "Swaziland", 1 },
                    { 203L, "SE", false, "Sweden", 1 },
                    { 204L, "CH", false, "Switzerland", 1 },
                    { 205L, "SY", false, "Syrian Arab Republic", 1 },
                    { 206L, "TW", false, "Taiwan, Province of China", 1 },
                    { 207L, "TJ", false, "Tajikistan", 1 }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Deleted", "Name", "PhonePrefix" },
                values: new object[,]
                {
                    { 208L, "TZ", false, "Tanzania, United Republic of", 1 },
                    { 209L, "TH", false, "Thailand", 1 },
                    { 210L, "TG", false, "Togo", 1 },
                    { 211L, "TK", false, "Tokelau", 1 },
                    { 212L, "TO", false, "Tonga", 1 },
                    { 213L, "TT", false, "Trinidad and Tobago", 1 },
                    { 214L, "TN", false, "Tunisia", 1 },
                    { 215L, "TR", false, "Turkey", 1 },
                    { 216L, "TM", false, "Turkmenistan", 1 },
                    { 217L, "TC", false, "Turks and Caicos Islands", 1 },
                    { 218L, "TV", false, "Tuvalu", 1 },
                    { 219L, "UG", false, "Uganda", 1 },
                    { 220L, "UA", false, "Ukraine", 1 },
                    { 221L, "AE", false, "United Arab Emirates", 1 },
                    { 222L, "GB", false, "United Kingdom", 1 },
                    { 223L, "US", false, "United States", 1 },
                    { 224L, "UM", false, "United States Minor Outlying Islands", 1 },
                    { 225L, "UY", false, "Uruguay", 1 },
                    { 226L, "UZ", false, "Uzbekistan", 1 },
                    { 227L, "VU", false, "Vanuatu", 1 },
                    { 228L, "VE", false, "Venezuela", 1 },
                    { 229L, "VN", false, "Viet Nam", 1 },
                    { 230L, "VG", false, "Virgin Islands (British)", 1 },
                    { 231L, "VI", false, "Virgin Islands (U.S.)", 1 },
                    { 232L, "WF", false, "Wallis and Futuna Islands", 1 },
                    { 233L, "EH", false, "Western Sahara", 1 },
                    { 234L, "YE", false, "Yemen", 1 },
                    { 235L, "YU", false, "Yugoslavia", 1 },
                    { 236L, "ZM", false, "Zambia", 1 },
                    { 237L, "ZW", false, "Zimbabwe", 1 },
                    { 238L, "GG", false, "Bailiwick of Guernsey", 1 },
                    { 239L, "JE", false, "Bailiwick of Jersey", 1 },
                    { 240L, "IM", false, "Isle of Man", 1 },
                    { 241L, "ME", false, "Crna Gora (Montenegro)", 1 },
                    { 242L, "RS", false, "SÉRVIA", 1 },
                    { 243L, "SS", false, "Republic of South Sudan", 1 },
                    { 244L, "N", false, "Zona del Canal de Panamá", 1 },
                    { 245L, "PS", false, "Dawlat Filas?in", 1 },
                    { 246L, "AX", false, "Åland Islands", 1 },
                    { 247L, "CW", false, "Curaçao", 1 },
                    { 248L, "SM", false, "Saint Martin", 1 },
                    { 249L, "AN", false, "Bonaire", 1 }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Deleted", "Name", "PhonePrefix" },
                values: new object[,]
                {
                    { 250L, "AQ", false, "Antartica", 1 },
                    { 251L, "AU", false, "Heard Island and McDonald Islands", 1 },
                    { 252L, "FR", false, "Saint-Barthélemy", 1 },
                    { 253L, "SM", false, "Saint Martin", 1 },
                    { 254L, "TF", false, "Terres Australes et Antarctiques Françaises", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Abbreviation", "CreatedOn", "Deleted", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { 1L, "SADM", new DateTime(2023, 4, 18, 18, 34, 15, 181, DateTimeKind.Local).AddTicks(6652), false, "Super Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "RP", new DateTime(2023, 4, 18, 18, 34, 15, 181, DateTimeKind.Local).AddTicks(6809), false, "Representante", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "ADMF", new DateTime(2023, 4, 18, 18, 34, 15, 181, DateTimeKind.Local).AddTicks(6810), false, "Administrador Filial", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeValidations_UserId",
                table: "CodeValidations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposalHistoricEletrics_proposalId",
                table: "ProposalHistoricEletrics",
                column: "proposalId");

            migrationBuilder.CreateIndex(
                name: "IX_PushNotificationKeys_UserId",
                table: "PushNotificationKeys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeValidations");

            migrationBuilder.DropTable(
                name: "ConfigurationTags");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "LanguageTags");

            migrationBuilder.DropTable(
                name: "ProposalHistoricEletrics");

            migrationBuilder.DropTable(
                name: "PushNotificationKeys");

            migrationBuilder.DropTable(
                name: "Proposal");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}

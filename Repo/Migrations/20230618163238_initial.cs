using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repo.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesBlog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesBlog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distributor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Irradiation = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    LevelIrradiation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
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
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "ntext", nullable: false),
                    Answer = table.Column<string>(type: "ntext", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
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
                name: "NetworkEnergies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstalationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimalkWh = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkEnergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
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
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryBlogId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_CategoriesBlog_CategoryBlogId",
                        column: x => x.CategoryBlogId,
                        principalTable: "CategoriesBlog",
                        principalColumn: "Id");
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
                name: "BlogUserReads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogUserReads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogUserReads_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
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
                });

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
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
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
                    Status = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactory = table.Column<bool>(type: "bit", nullable: true),
                    TwoFactorySecret = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Hierarchies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerId = table.Column<long>(type: "bigint", nullable: false),
                    ExecutiveId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hierarchies_Users_ExecutiveId",
                        column: x => x.ExecutiveId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hierarchies_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    NotificationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationUsers_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationUsers_Users_UserId",
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

            migrationBuilder.CreateTable(
                name: "Schedulers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateInitial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Schedulers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedulers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedulers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ConfigurationTags",
                columns: new[] { "Id", "Description", "Tag", "Value" },
                values: new object[,]
                {
                    { 1L, "default_user_type_id", "default_user_type_id", "2" },
                    { 2L, "default_user_type_abreviations", "default_user_type_abreviations", "RP" },
                    { 3L, "default_percent_compress", "default_percent_compress", "60" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Deleted", "Name", "PhonePrefix" },
                values: new object[] { 1L, "BR", false, "Brazil", 1 });

            migrationBuilder.InsertData(
                table: "NetworkEnergies",
                columns: new[] { "Id", "CreatedOn", "Deleted", "InstalationType", "MinimalkWh", "UpdatedOn" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 6, 18, 13, 32, 38, 265, DateTimeKind.Local).AddTicks(3103), false, "Monofásico", 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2023, 6, 18, 13, 32, 38, 265, DateTimeKind.Local).AddTicks(3104), false, "Bifásico", 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2023, 6, 18, 13, 32, 38, 265, DateTimeKind.Local).AddTicks(3105), false, "Trifásico", 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2023, 6, 18, 13, 32, 38, 265, DateTimeKind.Local).AddTicks(3106), false, "A4", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Abbreviation", "CreatedOn", "Deleted", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { 1L, "SADM", new DateTime(2023, 6, 18, 13, 32, 38, 265, DateTimeKind.Local).AddTicks(3070), false, "Super Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "RP", new DateTime(2023, 6, 18, 13, 32, 38, 265, DateTimeKind.Local).AddTicks(3072), false, "Representante", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "ADMF", new DateTime(2023, 6, 18, 13, 32, 38, 265, DateTimeKind.Local).AddTicks(3073), false, "Administrador Filial", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryBlogId",
                table: "Blogs",
                column: "CategoryBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogUserReads_BlogId",
                table: "BlogUserReads",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogUserReads_UserId",
                table: "BlogUserReads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeValidations_UserId",
                table: "CodeValidations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserId",
                table: "Companies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchies_ExecutiveId",
                table: "Hierarchies",
                column: "ExecutiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchies_ManagerId",
                table: "Hierarchies",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notications_UserId",
                table: "Notications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationUsers_NotificationId",
                table: "NotificationUsers",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationUsers_UserId",
                table: "NotificationUsers",
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
                name: "IX_Schedulers_CompanyId",
                table: "Schedulers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulers_UserId",
                table: "Schedulers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogUserReads_Users_UserId",
                table: "BlogUserReads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CodeValidations_Users_UserId",
                table: "CodeValidations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "BlogUserReads");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "CodeValidations");

            migrationBuilder.DropTable(
                name: "ConfigurationTags");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "Hierarchies");

            migrationBuilder.DropTable(
                name: "LanguageTags");

            migrationBuilder.DropTable(
                name: "NetworkEnergies");

            migrationBuilder.DropTable(
                name: "Notications");

            migrationBuilder.DropTable(
                name: "NotificationUsers");

            migrationBuilder.DropTable(
                name: "ProposalHistoricEletrics");

            migrationBuilder.DropTable(
                name: "PushNotificationKeys");

            migrationBuilder.DropTable(
                name: "Schedulers");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Proposal");

            migrationBuilder.DropTable(
                name: "CategoriesBlog");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}

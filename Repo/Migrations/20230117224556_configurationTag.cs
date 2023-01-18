using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repo.Migrations
{
    public partial class configurationTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ConfigurationTags",
                columns: new[] { "Id", "Description", "Tag", "Value" },
                values: new object[] { 3L, "default_percent_compress", "default_percent_compress", "60" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 1, 17, 19, 45, 56, 37, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 1, 17, 19, 45, 56, 37, DateTimeKind.Local).AddTicks(7476));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConfigurationTags",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 1, 17, 19, 13, 8, 242, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 1, 17, 19, 13, 8, 242, DateTimeKind.Local).AddTicks(9151));
        }
    }
}

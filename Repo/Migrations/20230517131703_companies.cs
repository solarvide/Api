using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repo.Migrations
{
    public partial class companies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 17, 10, 17, 3, 221, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 17, 10, 17, 3, 221, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 17, 10, 17, 3, 221, DateTimeKind.Local).AddTicks(2322));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 16, 0, 11, 28, 110, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 16, 0, 11, 28, 110, DateTimeKind.Local).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 16, 0, 11, 28, 110, DateTimeKind.Local).AddTicks(6025));
        }
    }
}

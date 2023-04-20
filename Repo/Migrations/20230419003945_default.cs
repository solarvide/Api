using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repo.Migrations
{
    public partial class @default : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ConfigurationTags",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Value",
                value: "2");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 21, 39, 45, 96, DateTimeKind.Local).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 21, 39, 45, 96, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 21, 39, 45, 96, DateTimeKind.Local).AddTicks(7541));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ConfigurationTags",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Value",
                value: "1");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 21, 34, 6, 560, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 21, 34, 6, 560, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 21, 34, 6, 560, DateTimeKind.Local).AddTicks(8016));
        }
    }
}

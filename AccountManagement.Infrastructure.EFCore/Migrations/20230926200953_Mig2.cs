using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "11EF8012-B314-485E-ABEC-C8D473B03679",
                column: "CreationDate",
                value: new DateTime(2023, 9, 26, 23, 39, 53, 435, DateTimeKind.Local).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1b1a3a22-115c-45e7-bcc9-0786caa01401",
                column: "CreationDate",
                value: new DateTime(2023, 9, 26, 23, 39, 53, 435, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "29DDC46D-9B46-4BD9-A833-26CE67267ED5",
                column: "CreationDate",
                value: new DateTime(2023, 9, 26, 23, 39, 53, 435, DateTimeKind.Local).AddTicks(3109));

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "6aabd0ed-3b59-45d6-b1fa-6803efedcb9d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "334c9e7f-8ebb-4c85-9a9a-0639552029e2", "AQAAAAIAAYagAAAAEOFQfM6LFYRyJZFA5A+yXpgYyqzQv7tqvlwnWVpC0HVWsoMaER/fzS+GRAAGa/5IHw==", true, "cdd4753b-2f61-412b-b1ac-f67e61acf793" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "11EF8012-B314-485E-ABEC-C8D473B03679",
                column: "CreationDate",
                value: new DateTime(2023, 9, 26, 23, 35, 44, 923, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1b1a3a22-115c-45e7-bcc9-0786caa01401",
                column: "CreationDate",
                value: new DateTime(2023, 9, 26, 23, 35, 44, 923, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "29DDC46D-9B46-4BD9-A833-26CE67267ED5",
                column: "CreationDate",
                value: new DateTime(2023, 9, 26, 23, 35, 44, 923, DateTimeKind.Local).AddTicks(3512));

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "6aabd0ed-3b59-45d6-b1fa-6803efedcb9d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "25aef209-0502-4657-824a-d2da7eac8115", "AQAAAAIAAYagAAAAEBeTy81u/2qe1x3Pn0kPV5sAntJvDfZAR61h+FsQ+PADpahGu9XlG0535EPYt9afmg==", false, "0bd52a5d-a57f-4c87-bc23-921e89c3bdc3" });
        }
    }
}

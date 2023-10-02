using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FileServers",
                keyColumn: "Id",
                keyValue: new Guid("812e3b67-7e01-4664-a72a-2957a146da80"),
                column: "CreationDate",
                value: new DateTime(2023, 9, 26, 23, 32, 32, 755, DateTimeKind.Local).AddTicks(5299));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FileServers",
                keyColumn: "Id",
                keyValue: new Guid("812e3b67-7e01-4664-a72a-2957a146da80"),
                column: "CreationDate",
                value: new DateTime(2023, 9, 26, 13, 35, 50, 760, DateTimeKind.Local).AddTicks(6274));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileServers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Capacity = table.Column<long>(type: "bigint", nullable: false),
                    FTPData = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    HttpPath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HttpDomain = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileServers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SizeOnDisk = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 450, nullable: true),
                    FileServerId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 450, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_FileServers_FileServerId",
                        column: x => x.FileServerId,
                        principalTable: "FileServers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FileServers",
                columns: new[] { "Id", "Capacity", "CreationDate", "Description", "FTPData", "HttpDomain", "HttpPath", "IsActive", "Name" },
                values: new object[] { new Guid("812e3b67-7e01-4664-a72a-2957a146da80"), 0L, new DateTime(2023, 9, 26, 13, 35, 50, 760, DateTimeKind.Local).AddTicks(6274), null, "", "http://127.0.0.127", "/Main", true, "Public" });

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileServerId",
                table: "Files",
                column: "FileServerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "FileServers");
        }
    }
}

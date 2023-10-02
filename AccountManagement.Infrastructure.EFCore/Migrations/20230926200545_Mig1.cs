using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileServer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Capacity = table.Column<long>(type: "bigint", nullable: false),
                    FTPData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HttpPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HttpDomain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileServer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeOnDisk = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FileServerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Accounts_AccountId1",
                        column: x => x.AccountId1,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_FileServer_FileServerId",
                        column: x => x.FileServerId,
                        principalTable: "FileServer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "25aef209-0502-4657-824a-d2da7eac8115", "AQAAAAIAAYagAAAAEBeTy81u/2qe1x3Pn0kPV5sAntJvDfZAR61h+FsQ+PADpahGu9XlG0535EPYt9afmg==", "9108031881", "0bd52a5d-a57f-4c87-bc23-921e89c3bdc3", "SuperAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_File_AccountId1",
                table: "File",
                column: "AccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_File_FileServerId",
                table: "File",
                column: "FileServerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "FileServer");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "11EF8012-B314-485E-ABEC-C8D473B03679",
                column: "CreationDate",
                value: new DateTime(2023, 8, 7, 1, 12, 33, 322, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1b1a3a22-115c-45e7-bcc9-0786caa01401",
                column: "CreationDate",
                value: new DateTime(2023, 8, 7, 1, 12, 33, 322, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "29DDC46D-9B46-4BD9-A833-26CE67267ED5",
                column: "CreationDate",
                value: new DateTime(2023, 8, 7, 1, 12, 33, 322, DateTimeKind.Local).AddTicks(98));

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "6aabd0ed-3b59-45d6-b1fa-6803efedcb9d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "ae372105-eb7e-4b72-8c88-ed29d208dd80", "AQAAAAIAAYagAAAAEHUwlgMqsw2Ndllc7+Q+DwJxuYdKBncplqKOE1hfUanh3qV8xBIuS2Tu5P3q/FM1LQ==", "9108031880", "9faff739-4f5d-4c44-bd03-b4680b3a4ef2", "superAdmin" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountHolderId",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AccountHolderId",
                table: "Categories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "AccountHolders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VerificationCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Roles = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHolders", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AccountHolderId",
                table: "Expenses",
                column: "AccountHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AccountHolderId",
                table: "Categories",
                column: "AccountHolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AccountHolders_AccountHolderId",
                table: "Categories",
                column: "AccountHolderId",
                principalTable: "AccountHolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AccountHolders_AccountHolderId",
                table: "Expenses",
                column: "AccountHolderId",
                principalTable: "AccountHolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AccountHolders_AccountHolderId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AccountHolders_AccountHolderId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "AccountHolders");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_AccountHolderId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Categories_AccountHolderId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AccountHolderId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "AccountHolderId",
                table: "Categories");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceWeb.CartAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bar_code",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "category",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "origin",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "packaging_quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "packaging_type",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "supplier",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bar_code",
                table: "Products",
                type: "VARCHAR(13)",
                maxLength: 13,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Products",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Products",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Products",
                type: "VARCHAR(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "origin",
                table: "Products",
                type: "CHAR(1)",
                maxLength: 1,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "packaging_quantity",
                table: "Products",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "packaging_type",
                table: "Products",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Products",
                type: "DECIMAL(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "supplier",
                table: "Products",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceWeb.CartAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductCode",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductCode",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "ProductCode",
                table: "CartItems",
                newName: "product_code");

            migrationBuilder.AlterColumn<string>(
                name: "product_code",
                table: "CartItems",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(6)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "product_code",
                table: "CartItems",
                newName: "ProductCode");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "CartItems",
                type: "varchar(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_code = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductCode",
                table: "CartItems",
                column: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductCode",
                table: "CartItems",
                column: "ProductCode",
                principalTable: "Products",
                principalColumn: "product_code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

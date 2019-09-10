using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSite.Migrations
{
    public partial class Initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_categories_categoryID",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "categoryID",
                table: "items",
                newName: "catID");

            migrationBuilder.RenameIndex(
                name: "IX_items_categoryID",
                table: "items",
                newName: "IX_items_catID");

            migrationBuilder.AddForeignKey(
                name: "FK_items_categories_catID",
                table: "items",
                column: "catID",
                principalTable: "categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_categories_catID",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "catID",
                table: "items",
                newName: "categoryID");

            migrationBuilder.RenameIndex(
                name: "IX_items_catID",
                table: "items",
                newName: "IX_items_categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_items_categories_categoryID",
                table: "items",
                column: "categoryID",
                principalTable: "categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

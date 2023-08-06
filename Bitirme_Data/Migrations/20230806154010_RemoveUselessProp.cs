using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bitirme_Projesi.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUselessProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlisverisTamamlandiMi",
                table: "ShoppingLists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlisverisTamamlandiMi",
                table: "ShoppingLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

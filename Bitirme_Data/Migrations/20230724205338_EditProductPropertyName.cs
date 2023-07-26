using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bitirme_Projesi.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditProductPropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFİlePath",
                table: "Products",
                newName: "ImageFilePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFilePath",
                table: "Products",
                newName: "ImageFİlePath");
        }
    }
}

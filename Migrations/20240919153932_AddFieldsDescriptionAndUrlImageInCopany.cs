using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace main_menu.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsDescriptionAndUrlImageInCopany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlSite",
                table: "Company");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Company",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Company",
                type: "character varying(999)",
                maxLength: 999,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Company");

            migrationBuilder.AddColumn<string>(
                name: "UrlSite",
                table: "Company",
                type: "character varying(999)",
                maxLength: 999,
                nullable: false,
                defaultValue: "");
        }
    }
}

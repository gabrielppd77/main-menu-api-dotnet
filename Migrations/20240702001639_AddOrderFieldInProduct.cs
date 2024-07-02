using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace main_menu.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderFieldInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Product");
        }
    }
}

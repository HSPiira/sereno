using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sereno.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ItemCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "InventoryItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "InventoryItems");
        }
    }
}

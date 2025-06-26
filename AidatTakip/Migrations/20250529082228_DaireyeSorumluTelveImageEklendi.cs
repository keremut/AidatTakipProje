using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AidatTakip.Migrations
{
    /// <inheritdoc />
    public partial class DaireyeSorumluTelveImageEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SorumluImage",
                table: "Daireler",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SorumluTel",
                table: "Daireler",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SorumluImage",
                table: "Daireler");

            migrationBuilder.DropColumn(
                name: "SorumluTel",
                table: "Daireler");
        }
    }
}

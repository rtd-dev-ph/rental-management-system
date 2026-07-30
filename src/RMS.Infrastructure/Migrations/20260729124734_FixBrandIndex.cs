using Microsoft.EntityFrameworkCore.Migrations;
			
#nullable disable

namespace RMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixBrandIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vehicles_Brand",
                table: "vehicles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_vehicles_Brand",
                table: "vehicles",
                column: "Brand",
                unique: true);
        }
        
    }
}

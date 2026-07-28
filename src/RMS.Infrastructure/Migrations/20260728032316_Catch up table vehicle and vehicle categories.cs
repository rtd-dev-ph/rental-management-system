using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Catchuptablevehicleandvehiclecategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_categories_VehicleCategory_CategoryId",
                table: "vehicle_categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleCategory",
                table: "VehicleCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicle_categories",
                table: "vehicle_categories");

            migrationBuilder.RenameTable(
                name: "VehicleCategory",
                newName: "VehicleCategories");

            migrationBuilder.RenameTable(
                name: "vehicle_categories",
                newName: "vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_vehicle_categories_CategoryId",
                table: "vehicles",
                newName: "IX_vehicles_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicle_categories_Brand",
                table: "vehicles",
                newName: "IX_vehicles_Brand");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "vehicles",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleCategories",
                table: "VehicleCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicles",
                table: "vehicles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_VehicleCategories_CategoryId",
                table: "vehicles",
                column: "CategoryId",
                principalTable: "VehicleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_VehicleCategories_CategoryId",
                table: "vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicles",
                table: "vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleCategories",
                table: "VehicleCategories");

            migrationBuilder.RenameTable(
                name: "vehicles",
                newName: "vehicle_categories");

            migrationBuilder.RenameTable(
                name: "VehicleCategories",
                newName: "VehicleCategory");

            migrationBuilder.RenameIndex(
                name: "IX_vehicles_CategoryId",
                table: "vehicle_categories",
                newName: "IX_vehicle_categories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicles_Brand",
                table: "vehicle_categories",
                newName: "IX_vehicle_categories_Brand");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "vehicle_categories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicle_categories",
                table: "vehicle_categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleCategory",
                table: "VehicleCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_categories_VehicleCategory_CategoryId",
                table: "vehicle_categories",
                column: "CategoryId",
                principalTable: "VehicleCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

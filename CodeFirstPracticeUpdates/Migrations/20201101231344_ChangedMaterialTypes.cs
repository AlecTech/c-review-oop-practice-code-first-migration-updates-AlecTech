using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstPracticeUpdates.Migrations
{
    public partial class ChangedMaterialTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "shelf_material",
                keyColumn: "ID",
                keyValue: 1,
                column: "MaterialName",
                value: "wood");

            migrationBuilder.UpdateData(
                table: "shelf_material",
                keyColumn: "ID",
                keyValue: 2,
                column: "MaterialName",
                value: "glass");

            migrationBuilder.UpdateData(
                table: "shelf_material",
                keyColumn: "ID",
                keyValue: 3,
                column: "MaterialName",
                value: "rubber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "shelf_material",
                keyColumn: "ID",
                keyValue: 1,
                column: "MaterialName",
                value: "wooden");

            migrationBuilder.UpdateData(
                table: "shelf_material",
                keyColumn: "ID",
                keyValue: 2,
                column: "MaterialName",
                value: "laminated");

            migrationBuilder.UpdateData(
                table: "shelf_material",
                keyColumn: "ID",
                keyValue: 3,
                column: "MaterialName",
                value: "cork");
        }
    }
}

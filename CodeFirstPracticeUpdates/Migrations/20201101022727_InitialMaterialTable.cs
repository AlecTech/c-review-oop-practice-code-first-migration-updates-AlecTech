using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstPracticeUpdates.Migrations
{
    public partial class InitialMaterialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shelf_material",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaterialName = table.Column<string>(type: "varchar(25)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shelf_material", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "shelfs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    ShelfMaterialID = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shelfs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shelf_Shelf_Material",
                        column: x => x.ShelfMaterialID,
                        principalTable: "shelf_material",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "shelf_material",
                columns: new[] { "ID", "MaterialName" },
                values: new object[,]
                {
                    { 1, "wooden" },
                    { 2, "laminated" },
                    { 3, "cork" },
                    { 4, "steel" },
                    { 5, "plastic" }
                });

            migrationBuilder.InsertData(
                table: "shelfs",
                columns: new[] { "ID", "Name", "ShelfMaterialID" },
                values: new object[,]
                {
                    { -1, "Item1", 1 },
                    { -2, "Item2", 2 },
                    { -3, "Item3", 3 },
                    { -4, "Item4", 4 },
                    { -5, "Item5", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "FK_Shelf_Shelf_Material",
                table: "shelfs",
                column: "ShelfMaterialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shelfs");

            migrationBuilder.DropTable(
                name: "shelf_material");
        }
    }
}

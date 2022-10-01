using Microsoft.EntityFrameworkCore.Migrations;

namespace JuanDavidB.Persistence.Migrations
{
    public partial class ChangeLenghtPais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tableros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deportista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Arranque = table.Column<int>(type: "int", nullable: false),
                    Envion = table.Column<int>(type: "int", nullable: false),
                    TotalPeso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tableros", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tableros",
                columns: new[] { "Id", "Arranque", "Deportista", "Envion", "Pais", "TotalPeso" },
                values: new object[,]
                {
                    { 1, 134, "Carlos Alviz", 177, "AUS", 311 },
                    { 2, 130, "Andrés Sabogal", 180, "CHN", 310 },
                    { 3, 125, "Jorge Ortega", 184, "FRA", 309 },
                    { 4, 0, "Pablo Velasco", 150, "AUS", 150 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tableros");
        }
    }
}

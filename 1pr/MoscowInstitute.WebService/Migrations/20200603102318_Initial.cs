using Microsoft.EntityFrameworkCore.Migrations;

namespace MoscowInstitutes.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoscowInstitutes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortName = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    ChiefName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoscowInstitutes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MoscowInstitutes",
                columns: new[] { "Id", "ChiefName", "LegalAddress", "ShortName", "WebSite" },
                values: new object[] { 1L, "Ледовская Татьяна Леонидовна", "123154, ГОРОД МОСКВА, УЛИЦА МАРШАЛА ТУХАЧЕВСКОГО, 20, 1", "ГБОУ ДО ДТДМ «Хорошево»", "dtim.mskobr.ru" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoscowInstitutes");
        }
    }
}

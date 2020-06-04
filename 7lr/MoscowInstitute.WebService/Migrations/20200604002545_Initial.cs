using Microsoft.EntityFrameworkCore.Migrations;

namespace MoscowInstitute.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortName = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    ChiefName = table.Column<string>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "ChiefName", "LegalAddress", "ShortName", "WebSite" },
                values: new object[] { 1L, "Ледовская Татьяна Леонидовна", "123154, ГОРОД МОСКВА, УЛИЦА МАРШАЛА ТУХАЧЕВСКОГО, 20, 1", "ГБОУ ДО ДТДМ «Хорошево»", "dtim.mskobr.ru" });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "ChiefName", "LegalAddress", "ShortName", "WebSite" },
                values: new object[] { 2L, "Шпаро Матвей Дмитриевич", "109147, г. Москва, ул. Нижегородская, д. 3", "ГБУ «Лаборатория путешествий»", "lab-putesh.mskobr.ru" });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "ChiefName", "LegalAddress", "ShortName", "WebSite" },
                values: new object[] { 3L, "Седова Наталья Николаевна", "115569, г. Москва, Шипиловский проезд, дом 37, корпус 1", "ГБПОУ колледж «Царицыно»", "collegetsaritsyno.mskobr.ru" });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "ChiefName", "LegalAddress", "ShortName", "WebSite" },
                values: new object[] { 4L, "Коминова Елена Борисовна", "107553, Москва, ул. Большая Черкизовская, д. 15", "ГБОУДО «ДТДиМ «Преображенский»", "dtdimvouo.mskobr.ru" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Institutes");
        }
    }
}

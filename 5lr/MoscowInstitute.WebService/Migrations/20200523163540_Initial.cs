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
                    NameInstitute = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "NameInstitute", "Site", "Address", "Director" },
                values: new object[] { 1L, "ГБОУ ДО ДТДМ «Хорошево»", "dtim.mskobr.ru",
                    "123154, ГОРОД МОСКВА, УЛИЦА МАРШАЛА ТУХАЧЕВСКОГО, 20, 1", "Ледовская Татьяна Леонидовна" });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "NameInstitute", "Site", "Address", "Director" },
                values: new object[] { 2L, "ГБУ «Лаборатория путешествий»", "lab-putesh.mskobr.ru",
                    "109147, г. Москва, ул. Нижегородская, д. 3", "Шпаро Матвей Дмитриевич" });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "NameInstitute", "Site", "Address", "Director" },
                values: new object[] { 3L, "ГБПОУ колледж «Царицыно»", "collegetsaritsyno.mskobr.ru",
                    "115569, г. Москва, Шипиловский проезд, дом 37, корпус 1", "Седова Наталья Николаевна" });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "NameInstitute", "Site", "Address", "Director" },
                values: new object[] { 4L, "ГБОУДО «ДТДиМ «Преображенский»", "dtdimvouo.mskobr.ru",
                    "107553, Москва, ул. Большая Черкизовская, д. 15", "Коминова Елена Борисовна" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Institutes");
        }
    }
}

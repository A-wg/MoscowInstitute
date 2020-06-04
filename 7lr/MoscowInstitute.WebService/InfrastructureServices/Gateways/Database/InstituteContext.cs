using Microsoft.EntityFrameworkCore;
using MoscowInstitute.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoscowInstitute.InfrastructureServices.Gateways.Database
{
    public class InstituteContext : DbContext
    {
        public DbSet<Institute> Institutes { get; set; }

        public InstituteContext(DbContextOptions<InstituteContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institute>().HasData(
                new
                {
                    Id = 1L,
                    ShortName = "ГБОУ ДО ДТДМ «Хорошево»",
                    LegalAddress = "123154, ГОРОД МОСКВА, УЛИЦА МАРШАЛА ТУХАЧЕВСКОГО, 20, 1",
                    WebSite = "dtim.mskobr.ru",
                    ChiefName = "Ледовская Татьяна Леонидовна"
                },
                new
                {
                    Id = 2L,
                    ShortName = "ГБУ «Лаборатория путешествий»",
                    LegalAddress = "109147, г. Москва, ул. Нижегородская, д. 3",
                    WebSite = "lab-putesh.mskobr.ru",
                    ChiefName = "Шпаро Матвей Дмитриевич"
                },
                 new
                 {
                     Id = 3L,
                     ShortName = "ГБПОУ колледж «Царицыно»",
                     LegalAddress = "115569, г. Москва, Шипиловский проезд, дом 37, корпус 1",
                     WebSite = "collegetsaritsyno.mskobr.ru",
                     ChiefName = "Седова Наталья Николаевна"
                 },
                 new
                 {
                     Id = 4L,
                     ShortName = "ГБОУДО «ДТДиМ «Преображенский»",
                     LegalAddress = "107553, Москва, ул. Большая Черкизовская, д. 15",
                     WebSite = "dtdimvouo.mskobr.ru",
                     ChiefName = "Коминова Елена Борисовна"
                 }
            );
        }
    }
}

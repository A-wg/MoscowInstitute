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

        public InstituteContext(DbContextOptions options)
            : base(options)
        { }

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
                    NameInstitute = "ГБОУ ДО ДТДМ «Хорошево»",
                    Site = "dtim.mskobr.ru",
                    Address = "123154, ГОРОД МОСКВА, УЛИЦА МАРШАЛА ТУХАЧЕВСКОГО, 20, 1",
                    Director = "Ледовская Татьяна Леонидовна"
                },
                new
                {
                    Id = 2L,
                    NameInstitute = "ГБУ «Лаборатория путешествий»",
                    Site = "lab-putesh.mskobr.ru  ",
                    Address = "109147, г. Москва, ул. Нижегородская, д. 3  ",
                    Director = "Шпаро Матвей Дмитриевич"
                },
                new
                {
                    Id = 3L,
                    NameInstitute = "ГБПОУ колледж «Царицыно»",
                    Site = "collegetsaritsyno.mskobr.ru",
                    Address = "115569, г. Москва, Шипиловский проезд, дом 37, корпус 1",
                    Director = "Седова Наталья Николаевна"
                },
                new
                {
                    Id = 4L,
                    NameInstitute = "ГБОУДО «ДТДиМ «Преображенский»",
                    Site = "dtdimvouo.mskobr.ru",
                    Address = "107553, Москва, ул. Большая Черкизовская, д. 15 ",
                    Director = "Коминова Елена Борисовна"
                }
            );
        }
    }
}

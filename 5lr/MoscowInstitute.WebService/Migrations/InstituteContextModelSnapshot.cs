﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoscowInstitute.InfrastructureServices.Gateways.Database;

namespace MoscowInstitute.WebService.Migrations
{
    [DbContext(typeof(InstituteContext))]
    partial class InstituteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("MoscowInstitute.DomainObjects.Institute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("EndInstitute")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxTemperature")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinTemperature")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StartInstitute")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeInstitute")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Institutes");

                    b.HasData(
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
                            Site = "lab-putesh.mskobr.ru",
                            Address = "109147, г. Москва, ул. Нижегородская, д. 3",
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
                            Address = "107553, Москва, ул. Большая Черкизовская, д. 15",
                            Director = "Коминова Елена Борисовна"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

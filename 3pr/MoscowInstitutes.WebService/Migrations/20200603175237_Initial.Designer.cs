﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoscowInstitute.InfrastructureServices.Gateways.Database;

namespace MoscowInstitutes.WebService.Migrations
{
    [DbContext(typeof(MInstituteContext))]
    [Migration("20200603175237_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("MoscowInstitute.DomainObjects.MoscowInstitute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChiefName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LegalAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebSite")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MoscowInstitutes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ChiefName = "Ледовская Татьяна Леонидовна",
                            LegalAddress = "123154, ГОРОД МОСКВА, УЛИЦА МАРШАЛА ТУХАЧЕВСКОГО, 20, 1",
                            ShortName = "ГБОУ ДО ДТДМ «Хорошево»",
                            WebSite = "dtim.mskobr.ru"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

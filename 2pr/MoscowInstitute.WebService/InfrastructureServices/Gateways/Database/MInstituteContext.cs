using Microsoft.EntityFrameworkCore;
using MoscowInstitute.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowInstitute.InfrastructureServices.Gateways.Database
{
    public class MInstituteContext : DbContext
    {
        public DbSet<MoscowInstitutes> MoscowInstitutes { get; set; }

        public MInstituteContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoscowInstitutes>().HasData(
                new
                {
                    Id = 1L,
                    ShortName = "ГБОУ ДО ДТДМ «Хорошево»",
                    WebSite = "dtim.mskobr.ru",
                    LegalAddress = "123154, ГОРОД МОСКВА, УЛИЦА МАРШАЛА ТУХАЧЕВСКОГО, 20, 1",
                    ChiefName = "Ледовская Татьяна Леонидовна"
                }
            );
        }
    }
}
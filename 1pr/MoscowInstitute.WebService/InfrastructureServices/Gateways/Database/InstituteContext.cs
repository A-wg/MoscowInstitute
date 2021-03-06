﻿using Microsoft.EntityFrameworkCore;
using MoscowInstitute.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowInstitute.InfrastructureServices.Gateways.Database
{
    public class InstituteContext : DbContext
    {
        public DbSet<DomainObjects.MoscowInstitute> MoscowInstitutes { get; set; }

        public InstituteContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DomainObjects.MoscowInstitute>().HasData(
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
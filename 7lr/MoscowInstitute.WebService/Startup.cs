using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using MoscowInstitute.ApplicationServices.GetInstituteListUseCase;
using MoscowInstitute.ApplicationServices.Ports.Gateways.Database;
using MoscowInstitute.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using MoscowInstitute.ApplicationServices.Repositories;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MoscowInstitute.WebService.InfrastructureServices.Gateways;
using MoscowInstitute.WebService.Scheduler;

namespace MoscowInstitute.WebService 
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InstituteContext>(opts =>
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "MoscowInstitute.db")}")
            );
            services.AddHostedService<ScheduleTask>();
            services.AddScoped<IInstituteDatabaseGateway, InstituteEFSqliteGateway>();

            services.AddScoped<DbInstituteRepository>();
            services.AddScoped<IReadOnlyInstituteRepository>(x => x.GetRequiredService<DbInstituteRepository>());
            services.AddScoped<IInstituteRepository>(x => x.GetRequiredService<DbInstituteRepository>());

            services.AddScoped<IGetInstituteListUseCase, GetInstituteListUseCase>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

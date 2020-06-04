using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MoscowInstitute.InfrastructureServices.Gateways.Database;
using MoscowInstitute.WebService.InfrastructureServices.Gateways;
using MoscowInstitute.WebService.Scheduler;
using System.IO;

namespace MoscowInstitute.WebService.Scheduler
{
    public class ScheduleTask : ScheduledProcessor
    {

        public ScheduleTask(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        protected override string Schedule => "*/1 * * * *";

        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.DownloadString("https://apidata.mos.ru/v1/datasets/2263/rows?$top=10&api_key=c941a998bbb9e1e374fc2d7a33f61ed0");
            List<ResultFromServer> resultServer = JsonConvert.DeserializeObject<List<ResultFromServer>>(result);
            var optionsBuilder = new DbContextOptionsBuilder<InstituteContext>();
            string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\"));
            string newnewpath = System.IO.Path.Combine(newPath, "MoscowInstitute.WebService", "MoscowInstitute.db");
            optionsBuilder.UseSqlite($"Data Source={newnewpath}");
            var context = new InstituteContext(options: optionsBuilder.Options);
            context.Database.ExecuteSqlRaw("DELETE FROM Institutes");
            using (context)
            {
                foreach (var item in resultServer)
                {
                    DomainObjects.Institute institute = new DomainObjects.Institute();
                    institute.ShortName = item.Cells.ShortName;
                    institute.LegalAddress = item.Cells.LegalAddress;
                    institute.WebSite = item.Cells.WebSite;
                    institute.ChiefName = item.Cells.ChiefName;
                    context.Entry(institute).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
        
            
            Console.WriteLine("Updated db.");
            return Task.CompletedTask;
        }
    }
}

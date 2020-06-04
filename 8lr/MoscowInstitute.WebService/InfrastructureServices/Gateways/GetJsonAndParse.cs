using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.InfrastructureServices.Gateways.Database;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MoscowInstitute.WebService.InfrastructureServices.Gateways
{
    public class GetJsonAndParse
    {
        public async Task ParseAndPush()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.DownloadString("https://apidata.mos.ru/v1/datasets/2263/rows?$top=10&api_key=c941a998bbb9e1e374fc2d7a33f61ed0");
            List<ResultFromServer> resultServer = JsonConvert.DeserializeObject<List<ResultFromServer>>(result);
            var optionsBuilder = new DbContextOptionsBuilder<InstituteContext>();
            string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\"));
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
            await Task.CompletedTask;
        }
    }
}

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

namespace MoscowInstitutes.WebService.InfrastructureServices.Gateways
{
    public class GetJsonAndParse
    {
        public async Task ParseAndPush()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.DownloadString("https://apidata.mos.ru/v1/datasets/2263/rows?$top=10&api_key=c941a998bbb9e1e374fc2d7a33f61ed0");
            List<ResultFromServer> resultServer = JsonConvert.DeserializeObject<List<ResultFromServer>>(result);
            var optionsBuilder = new DbContextOptionsBuilder<MInstituteContext>();
            string newPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\"));
            string newnewpath = Path.Combine(newPath, "MoscowInstitutes.WebService", "MoscowInstitutes.db");
            optionsBuilder.UseSqlite($"Data Source={newnewpath}");
            var context = new MInstituteContext(options: optionsBuilder.Options);
            context.Database.ExecuteSqlRaw("DELETE FROM MoscowInstitutes");
            using (context)
            {
                foreach (var item in resultServer)
                {
                    MoscowInstitute.DomainObjects.MoscowInstitute moscowinstitute = new MoscowInstitute.DomainObjects.MoscowInstitute();
                    moscowinstitute.ShortName = item.Cells.ShortName;
                    moscowinstitute.WebSite = item.Cells.WebSite;
                    moscowinstitute.ChiefName = item.Cells.ChiefName;
                    moscowinstitute.LegalAddress = item.Cells.LegalAddress;
                    context.Entry(moscowinstitute).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            await Task.CompletedTask;
        }
    }
}

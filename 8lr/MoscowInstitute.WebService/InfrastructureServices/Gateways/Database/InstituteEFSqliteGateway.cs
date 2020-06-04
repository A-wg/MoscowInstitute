using MoscowInstitute.DomainObjects;
using MoscowInstitute.ApplicationServices.Ports.Gateways.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using MoscowInstitute.ApplicationServices.Ports.Gateways.Database;
using System.Net;
using MoscowInstitute.WebService.InfrastructureServices.Gateways;
using System.Text;
using Newtonsoft.Json;

namespace MoscowInstitute.InfrastructureServices.Gateways.Database
{
    public class InstituteEFSqliteGateway : IInstituteDatabaseGateway
    {
        private readonly InstituteContext _instituteContext;

        public InstituteEFSqliteGateway(InstituteContext instituteContext)
            => _instituteContext = instituteContext;

        public async Task<Institute> GetInstitute(long id)
           => await _instituteContext.Institutes.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Institute>> GetAllInstitutes()
            => await _instituteContext.Institutes.ToListAsync();

        public async Task<IEnumerable<Institute>> QueryInstitutes(Expression<Func<Institute, bool>> filter)
            => await _instituteContext.Institutes.Where(filter).ToListAsync();

        public async Task AddInstitute(Institute institute)
        {
            _instituteContext.Institutes.Add(institute);
            await _instituteContext.SaveChangesAsync();
        }

        public async Task UpdateInstitute(Institute institute)
        {
            _instituteContext.Entry(institute).State = EntityState.Modified;
            await _instituteContext.SaveChangesAsync();
        }

        public async Task RemoveInstitute(Institute institute)
        {
            _instituteContext.Institutes.Remove(institute);
            await _instituteContext.SaveChangesAsync();
        }

        public async Task ParseAndPush()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.DownloadString("https://apidata.mos.ru/v1/datasets/2263/rows?$top=10&api_key=c941a998bbb9e1e374fc2d7a33f61ed0");
            List<ResultFromServer> resultServer = JsonConvert.DeserializeObject<List<ResultFromServer>>(result);
            var optionsBuilder = new DbContextOptionsBuilder<InstituteContext>();
            optionsBuilder.UseSqlite("Data Source=C:/Users/User/Desktop/Mylaba-master/laba8/MoscowInstitute.WebService/MoscowInstitute.db"); ;
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

using MoscowInstitute.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using MoscowInstitute.ApplicationServices.Ports.Gateways.Database;
using System.Net;
using MoscowInstitutes.WebService.InfrastructureServices.Gateways;
using System.Text;
using Newtonsoft.Json;

namespace MoscowInstitute.InfrastructureServices.Gateways.Database
{
    public class MInstituteEFSqliteGateway : IMInstituteDatabaseGateway
    {
        private readonly MInstituteContext _MInstituteContext;

        public MInstituteEFSqliteGateway(MInstituteContext MInstituteContext)
            => _MInstituteContext = MInstituteContext;

        public async Task<DomainObjects.MoscowInstitute> GetInstitute(long id)
           => await _MInstituteContext.MoscowInstitutes.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<DomainObjects.MoscowInstitute>> GetAllInstitutes()
            => await _MInstituteContext.MoscowInstitutes.ToListAsync();

        public async Task<IEnumerable<DomainObjects.MoscowInstitute>> QueryInstitutes(Expression<Func<DomainObjects.MoscowInstitute, bool>> filter)
            => await _MInstituteContext.MoscowInstitutes.Where(filter).ToListAsync();

        public async Task AddInstitute(DomainObjects.MoscowInstitute institute)
        {
            _MInstituteContext.MoscowInstitutes.Add(institute);
            await _MInstituteContext.SaveChangesAsync();
        }

        public async Task UpdateInstitute(DomainObjects.MoscowInstitute institute)
        {
            _MInstituteContext.Entry(institute).State = EntityState.Modified;
            await _MInstituteContext.SaveChangesAsync();
        }

        public async Task RemoveInstitute(DomainObjects.MoscowInstitute institute)
        {
            _MInstituteContext.MoscowInstitutes.Remove(institute);
            await _MInstituteContext.SaveChangesAsync();
        }
       
        public async Task ParseAndPush()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.DownloadString("https://apidata.mos.ru/v1/datasets/2263/rows?$top=10&api_key=c941a998bbb9e1e374fc2d7a33f61ed0");
            List<ResultFromServer> resultServer = JsonConvert.DeserializeObject<List<ResultFromServer>>(result);
            var optionsBuilder = new DbContextOptionsBuilder<MInstituteContext>();
            optionsBuilder.UseSqlite("Data Source=C:/Users/User/Desktop/transfernodemsk-lab6/transfernodes-lab6/MoscowInstitutes.WebService/MoscowInstitutes.db"); ;
            var context = new MInstituteContext(options: optionsBuilder.Options);
            context.Database.ExecuteSqlRaw("DELETE FROM MoscowInstitutes");
            using (context)
            {
                foreach (var item in resultServer)
                {
                    DomainObjects.MoscowInstitute moscowinstitute = new DomainObjects.MoscowInstitute();
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
using MoscowInstitute.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using MoscowInstitute.ApplicationServices.Ports.Gateways.Database;

namespace MoscowInstitute.InfrastructureServices.Gateways.Database
{
    public class InstituteEFSqliteGateway : IInstituteDatabaseGateway
    {
        private readonly InstituteContext _InstituteContext;

        public InstituteEFSqliteGateway(InstituteContext InstituteContext)
            => _InstituteContext = InstituteContext;

        public async Task<DomainObjects.MoscowInstitute> GetInstitute(long id)
           => await _InstituteContext.MoscowInstitutes.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<DomainObjects.MoscowInstitute>> GetAllInstitutes()
            => await _InstituteContext.MoscowInstitutes.ToListAsync();

        public async Task<IEnumerable<DomainObjects.MoscowInstitute>> QueryInstitutes(Expression<Func<DomainObjects.MoscowInstitute, bool>> filter)
            => await _InstituteContext.MoscowInstitutes.Where(filter).ToListAsync();

        public async Task AddInstitute(DomainObjects.MoscowInstitute institute)
        {
            _InstituteContext.MoscowInstitutes.Add(institute);
            await _InstituteContext.SaveChangesAsync();
        }

        public async Task UpdateInstitute(DomainObjects.MoscowInstitute institute)
        {
            _InstituteContext.Entry(institute).State = EntityState.Modified;
            await _InstituteContext.SaveChangesAsync();
        }

        public async Task RemoveInstitute(DomainObjects.MoscowInstitute institute)
        {
            _InstituteContext.MoscowInstitutes.Remove(institute);
            await _InstituteContext.SaveChangesAsync();
        }
    }
}

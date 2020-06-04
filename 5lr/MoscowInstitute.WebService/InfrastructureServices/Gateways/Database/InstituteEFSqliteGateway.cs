using MoscowInstitute.DomainObjects;
using MoscowInstitute.ApplicationServices.Ports.Gateways.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

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
    }
}

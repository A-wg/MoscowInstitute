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
    public class MInstituteEFSqliteGateway : IMInstituteDatabaseGateway
    {
        private readonly MInstituteContext _MInstituteContext;

        public MInstituteEFSqliteGateway(MInstituteContext MInstituteContext)
            => _MInstituteContext = MInstituteContext;

        public async Task<MoscowInstitutes> GetInstitute(long id)
           => await _MInstituteContext.MoscowInstitutes.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<MoscowInstitutes>> GetAllInstitutes()
            => await _MInstituteContext.MoscowInstitutes.ToListAsync();

        public async Task<IEnumerable<MoscowInstitutes>> QueryInstitutes(Expression<Func<MoscowInstitutes, bool>> filter)
            => await _MInstituteContext.MoscowInstitutes.Where(filter).ToListAsync();

        public async Task AddInstitute(MoscowInstitutes institute)
        {
            _MInstituteContext.MoscowInstitutes.Add(institute);
            await _MInstituteContext.SaveChangesAsync();
        }

        public async Task UpdateInstitute(MoscowInstitutes institute)
        {
            _MInstituteContext.Entry(institute).State = EntityState.Modified;
            await _MInstituteContext.SaveChangesAsync();
        }

        public async Task RemoveInstitute(MoscowInstitutes institute)
        {
            _MInstituteContext.MoscowInstitutes.Remove(institute);
            await _MInstituteContext.SaveChangesAsync();
        }
    }
}

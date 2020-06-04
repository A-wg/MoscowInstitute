using MoscowInstitute.ApplicationServices.Ports.Gateways.Database;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoscowInstitute.ApplicationServices.Repositories
{
    public class DbMInstituteRepository : IReadOnlyInstituteRepository,
                                     IInstituteRepository
    {
        private readonly IMInstituteDatabaseGateway _databaseGateway;

        public DbMInstituteRepository(IMInstituteDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<MoscowInstitutes> GetInstitute(long id)
            => await _databaseGateway.GetInstitute(id);

        public async Task<IEnumerable<MoscowInstitutes>> GetAllInstitutes()
            => await _databaseGateway.GetAllInstitutes();

        public async Task<IEnumerable<MoscowInstitutes>> QueryInstitutes(ICriteria<MoscowInstitutes> criteria)
            => await _databaseGateway.QueryInstitutes(criteria.Filter);

        public async Task AddInstitute(MoscowInstitutes institute)
            => await _databaseGateway.AddInstitute(institute);

        public async Task RemoveInstitute(MoscowInstitutes institute)
            => await _databaseGateway.RemoveInstitute(institute);

        public async Task UpdateInstitute(MoscowInstitutes institute)
            => await _databaseGateway.UpdateInstitute(institute);
    }
}

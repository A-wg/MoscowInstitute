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

        public async Task<DomainObjects.MoscowInstitute> GetInstitute(long id)
            => await _databaseGateway.GetInstitute(id);

        public async Task<IEnumerable<DomainObjects.MoscowInstitute>> GetAllInstitutes()
            => await _databaseGateway.GetAllInstitutes();

        public async Task<IEnumerable<DomainObjects.MoscowInstitute>> QueryInstitutes(ICriteria<DomainObjects.MoscowInstitute> criteria)
            => await _databaseGateway.QueryInstitutes(criteria.Filter);

        public async Task AddInstitute(DomainObjects.MoscowInstitute institute)
            => await _databaseGateway.AddInstitute(institute);

        public async Task RemoveInstitute(DomainObjects.MoscowInstitute institute)
            => await _databaseGateway.RemoveInstitute(institute);

        public async Task UpdateInstitute(DomainObjects.MoscowInstitute institute)
            => await _databaseGateway.UpdateInstitute(institute);
    }
}

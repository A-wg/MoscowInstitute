using System;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using MoscowInstitute.ApplicationServices.Ports.Gateways.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoscowInstitute.ApplicationServices.Repositories
{
    public class DbInstituteRepository : IReadOnlyInstituteRepository,
                                     IInstituteRepository
    {
        private readonly IInstituteDatabaseGateway _databaseGateway;

        public DbInstituteRepository(IInstituteDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<Institute> GetInstitute(long id)
            => await _databaseGateway.GetInstitute(id);

        public async Task<IEnumerable<Institute>> GetAllInstitutes()
            => await _databaseGateway.GetAllInstitutes();

        public async Task<IEnumerable<Institute>> QueryInstitutes(ICriteria<Institute> criteria)
            => await _databaseGateway.QueryInstitutes(criteria.Filter);

        public async Task AddInstitute(Institute institute)
            => await _databaseGateway.AddInstitute(institute);

        public async Task RemoveInstitute(Institute institute)
            => await _databaseGateway.RemoveInstitute(institute);

        public async Task UpdateInstitute(Institute institute)
            => await _databaseGateway.UpdateInstitute(institute);

        public async Task ParseAndPush()
            => await _databaseGateway.ParseAndPush();
    }
}

using MoscowInstitute.ApplicationServices.Ports.Cache;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using MoscowInstitute.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowInstitute.InfrastructureServices.Repositories
{
    public class CachedReadOnlyInstituteRepository : ReadOnlyInstituteRepositoryDecorator
    {
        private readonly IDomainObjectsCache<Institute> _institutesCache;

        public CachedReadOnlyInstituteRepository(IReadOnlyInstituteRepository instituteRepository,
                                             IDomainObjectsCache<Institute> institutesCache)
            : base(instituteRepository)
            => _institutesCache = institutesCache;

        public async override Task<Institute> GetInstitute(long id)
            => _institutesCache.GetObject(id) ?? await base.GetInstitute(id);

        public async override Task<IEnumerable<Institute>> GetAllInstitutes()
            => _institutesCache.GetObjects() ?? await base.GetAllInstitutes();

        public async override Task<IEnumerable<Institute>> QueryInstitutes(ICriteria<Institute> criteria)
            => _institutesCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryInstitutes(criteria);
    }
}

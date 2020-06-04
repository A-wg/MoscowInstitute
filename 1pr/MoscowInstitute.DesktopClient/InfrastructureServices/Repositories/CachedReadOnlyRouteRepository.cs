using MoscowInstitute.ApplicationServices.Ports.Cache;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowInstitute.InfrastructureServices.Repositories
{
    public class CachedReadOnlyRouteRepository : ReadOnlyInstituteRepositoryDecorator
    {
        private readonly IDomainObjectsCache<DomainObjects.MoscowInstitute> _institutesCache;

        public CachedReadOnlyRouteRepository(IReadOnlyInstituteRepository instituteRepository, 
                                             IDomainObjectsCache<DomainObjects.MoscowInstitute> institutesCache)
            : base(instituteRepository)
            => _institutesCache = institutesCache;

        public async override Task<DomainObjects.MoscowInstitute> GetInstitute(long id)
            => _institutesCache.GetObject(id) ?? await base.GetInstitute(id);

        public async override Task<IEnumerable<DomainObjects.MoscowInstitute>> GetAllInstitutes()
            => _institutesCache.GetObjects() ?? await base.GetAllInstitutes();

        public async override Task<IEnumerable<DomainObjects.MoscowInstitute>> QueryInstitutes(ICriteria<DomainObjects.MoscowInstitute> criteria)
            => _institutesCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryInstitutes(criteria);

    }
}

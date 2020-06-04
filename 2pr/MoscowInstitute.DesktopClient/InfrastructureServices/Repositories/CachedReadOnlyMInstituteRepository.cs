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
    public class CachedReadOnlyMInstituteRepository : ReadOnlyMInstituteRepositoryDecorator
    {
        private readonly IDomainObjectsCache<DomainObjects.MoscowInstitutes> _routesCache;

        public CachedReadOnlyMInstituteRepository(IReadOnlyInstituteRepository routeRepository, 
                                             IDomainObjectsCache<DomainObjects.MoscowInstitutes> routesCache)
            : base(routeRepository)
            => _routesCache = routesCache;

        public async override Task<DomainObjects.MoscowInstitutes> GetInstitute(long id)
            => _routesCache.GetObject(id) ?? await base.GetInstitute(id);

        public async override Task<IEnumerable<DomainObjects.MoscowInstitutes>> GetAllInstitutes()
            => _routesCache.GetObjects() ?? await base.GetAllInstitutes();

        public async override Task<IEnumerable<DomainObjects.MoscowInstitutes>> QueryInstitutes(ICriteria<DomainObjects.MoscowInstitutes> criteria)
            => _routesCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryInstitutes(criteria);

    }
}

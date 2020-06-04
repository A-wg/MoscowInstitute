using MoscowInstitute.ApplicationServices.Ports.Cache;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoscowInstitute.InfrastructureServices.Repositories
{
    public class NetworkInstituteRepository : NetworkRepositoryBase, IReadOnlyInstituteRepository
    {
        private readonly IDomainObjectsCache<DomainObjects.MoscowInstitutes> _instituteCache;

        public NetworkInstituteRepository(string host, ushort port, bool useTls, IDomainObjectsCache<DomainObjects.MoscowInstitutes> instituteCache)
            : base(host, port, useTls)
            => _instituteCache = instituteCache;

        public async Task<DomainObjects.MoscowInstitutes> GetInstitute(long id)
            => CacheAndReturn(await ExecuteHttpRequest<DomainObjects.MoscowInstitutes>($"MInstitute/{id}"));

        public async Task<IEnumerable<DomainObjects.MoscowInstitutes>> GetAllInstitutes()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<DomainObjects.MoscowInstitutes>>($"MInstitute"), allObjects: true);

        public async Task<IEnumerable<DomainObjects.MoscowInstitutes>> QueryInstitutes(ICriteria<DomainObjects.MoscowInstitutes> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<DomainObjects.MoscowInstitutes>>($"MInstitute"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<DomainObjects.MoscowInstitutes> CacheAndReturn(IEnumerable<DomainObjects.MoscowInstitutes> routes, bool allObjects = false)
        {
            if (allObjects)
            {
                _instituteCache.ClearCache();
            }
            _instituteCache.UpdateObjects(routes, DateTime.Now.AddDays(1), allObjects);
            return routes;
        }

        private DomainObjects.MoscowInstitutes CacheAndReturn(DomainObjects.MoscowInstitutes route)
        {
            _instituteCache.UpdateObject(route, DateTime.Now.AddDays(1));
            return route;
        }
    }
}

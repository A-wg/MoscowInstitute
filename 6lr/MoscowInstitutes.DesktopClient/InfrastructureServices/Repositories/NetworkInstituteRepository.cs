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
        private readonly IDomainObjectsCache<DomainObjects.MoscowInstitute> _instituteCache;

        public NetworkInstituteRepository(string host, ushort port, bool useTls, IDomainObjectsCache<DomainObjects.MoscowInstitute> instituteCache)
            : base(host, port, useTls)
            => _instituteCache = instituteCache;

        public async Task<DomainObjects.MoscowInstitute> GetInstitute(long id)
            => CacheAndReturn(await ExecuteHttpRequest<DomainObjects.MoscowInstitute>($"MInstitute/{id}"));

        public async Task<IEnumerable<DomainObjects.MoscowInstitute>> GetAllInstitutes()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<DomainObjects.MoscowInstitute>>($"MInstitute"), allObjects: true);

        public async Task<IEnumerable<DomainObjects.MoscowInstitute>> QueryInstitutes(ICriteria<DomainObjects.MoscowInstitute> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<DomainObjects.MoscowInstitute>>($"MInstitute"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<DomainObjects.MoscowInstitute> CacheAndReturn(IEnumerable<DomainObjects.MoscowInstitute> institutes, bool allObjects = false)
        {
            if (allObjects)
            {
                _instituteCache.ClearCache();
            }
            _instituteCache.UpdateObjects(institutes, DateTime.Now.AddDays(1), allObjects);
            return institutes;
        }

        private DomainObjects.MoscowInstitute CacheAndReturn(DomainObjects.MoscowInstitute institutes)
        {
            _instituteCache.UpdateObject(institutes, DateTime.Now.AddDays(1));
            return institutes;
        }
    }
}
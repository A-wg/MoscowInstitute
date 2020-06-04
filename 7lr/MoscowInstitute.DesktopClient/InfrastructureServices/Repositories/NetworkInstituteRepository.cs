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
        private readonly IDomainObjectsCache<Institute> _instituteCache;

        public NetworkInstituteRepository(string host, ushort port, bool useTls, IDomainObjectsCache<Institute> instituteCache)
            : base(host, port, useTls)
            => _instituteCache = instituteCache;

        public async Task<Institute> GetInstitute(long id)
            => CacheAndReturn(await ExecuteHttpRequest<Institute>($"Institute/{id}"));

        public async Task<IEnumerable<Institute>> GetAllInstitutes()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<Institute>>($"Institute"), allObjects: true);

        public async Task<IEnumerable<Institute>> QueryInstitutes(ICriteria<Institute> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<Institute>>($"Institute"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<Institute> CacheAndReturn(IEnumerable<Institute> institutes, bool allObjects = false)
        {
            if (allObjects)
            {
                _instituteCache.ClearCache();
            }
            _instituteCache.UpdateObjects(institutes, DateTime.Now.AddDays(1), allObjects);
            return institutes;
        }

        private Institute CacheAndReturn(Institute institute)
        {
            _instituteCache.UpdateObject(institute, DateTime.Now.AddDays(1));
            return institute;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MoscowInstitute.DomainObjects.Ports
{
    public abstract class ReadOnlyInstituteRepositoryDecorator : IReadOnlyInstituteRepository
    {
        private readonly IReadOnlyInstituteRepository _MoscowInstituteRepository;

        public ReadOnlyInstituteRepositoryDecorator(IReadOnlyInstituteRepository InstituteRepository)
        {
            _MoscowInstituteRepository = InstituteRepository;
        }

        public virtual async Task<IEnumerable<MoscowInstitute>> GetAllInstitutes()
        {
            return await _MoscowInstituteRepository?.GetAllInstitutes();
        }

        public virtual async Task<MoscowInstitute> GetInstitute(long id)
        {
            return await _MoscowInstituteRepository?.GetInstitute(id);
        }

        public virtual async Task<IEnumerable<MoscowInstitute>> QueryInstitutes(ICriteria<MoscowInstitute> criteria)
        {
            return await _MoscowInstituteRepository?.QueryInstitutes(criteria);
        }
    }
}

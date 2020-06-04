using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowInstitute.DomainObjects.Repositories
{
    public abstract class ReadOnlyMInstituteRepositoryDecorator : IReadOnlyInstituteRepository
    {
        private readonly IReadOnlyInstituteRepository _MoscowInstituteRepository;

        public ReadOnlyMInstituteRepositoryDecorator(IReadOnlyInstituteRepository MInstituteRepository)
        {
            _MoscowInstituteRepository = MInstituteRepository;
        }

        public virtual async Task<IEnumerable<MoscowInstitutes>> GetAllInstitutes()
        {
            return await _MoscowInstituteRepository?.GetAllInstitutes();
        }

        public virtual async Task<MoscowInstitutes> GetInstitute(long id)
        {
            return await _MoscowInstituteRepository?.GetInstitute(id);
        }

        public virtual async Task<IEnumerable<MoscowInstitutes>> QueryInstitutes(ICriteria<MoscowInstitutes> criteria)
        {
            return await _MoscowInstituteRepository?.QueryInstitutes(criteria);
        }
    }
}

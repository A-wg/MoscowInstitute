using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowInstitute.DomainObjects.Repositories
{
    public abstract class ReadOnlyInstituteRepositoryDecorator : IReadOnlyInstituteRepository
    {
        private readonly IReadOnlyInstituteRepository _instituteRepository;

        public ReadOnlyInstituteRepositoryDecorator(IReadOnlyInstituteRepository instituteRepository)
        {
            _instituteRepository = instituteRepository;
        }

        public virtual async Task<IEnumerable<Institute>> GetAllInstitutes()
        {
            return await _instituteRepository?.GetAllInstitutes();
        }

        public virtual async Task<Institute> GetInstitute(long id)
        {
            return await _instituteRepository?.GetInstitute(id);
        }

        public virtual async Task<IEnumerable<Institute>> QueryInstitutes(ICriteria<Institute> criteria)
        {
            return await _instituteRepository?.QueryInstitutes(criteria);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MoscowInstitute.DomainObjects.Ports
{
    public interface IReadOnlyInstituteRepository
    {
        Task<Institute> GetInstitute(long id);

        Task<IEnumerable<Institute>> GetAllInstitute();

        Task<IEnumerable<Institute>> QueryInstitute(ICriteria<Institute> criteria);

    }

    public interface IInstituteRepository
    {
        Task AddInstitute(Institute institute);

        Task RemoveInstitute(Institute institute);

        Task UpdateInstitute(Institute institute);
    }
}

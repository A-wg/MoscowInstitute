using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MoscowInstitute.DomainObjects.Ports
{
    public interface IReadOnlyInstituteRepository
    {
        Task<MoscowInstitute> GetInstitute(long id);

        Task<IEnumerable<MoscowInstitute>> GetAllInstitutes();

        Task<IEnumerable<MoscowInstitute>> QueryInstitutes(ICriteria<MoscowInstitute> criteria);

    }

    public interface IInstituteRepository
    {
        Task AddInstitute(MoscowInstitute institute);

        Task RemoveInstitute(MoscowInstitute institute);

        Task UpdateInstitute(MoscowInstitute institute);
    }
}

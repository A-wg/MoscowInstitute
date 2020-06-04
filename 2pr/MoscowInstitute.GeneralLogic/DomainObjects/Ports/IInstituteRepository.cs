using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MoscowInstitute.DomainObjects.Ports
{
    public interface IReadOnlyInstituteRepository
    {
        Task<MoscowInstitutes> GetInstitute(long id);

        Task<IEnumerable<MoscowInstitutes>> GetAllInstitutes();

        Task<IEnumerable<MoscowInstitutes>> QueryInstitutes(ICriteria<MoscowInstitutes> criteria);

    }

    public interface IInstituteRepository
    {
        Task AddInstitute(MoscowInstitutes institute);

        Task RemoveInstitute(MoscowInstitutes institute);

        Task UpdateInstitute(MoscowInstitutes institute);
    }
}

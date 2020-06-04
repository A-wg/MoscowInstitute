using MoscowInstitute.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowInstitute.ApplicationServices.Ports.Gateways.Database
{
    public interface IMInstituteDatabaseGateway
    {
        Task AddInstitute(MoscowInstitutes institute);

        Task RemoveInstitute(MoscowInstitutes institute);

        Task UpdateInstitute(MoscowInstitutes institute);

        Task<MoscowInstitutes> GetInstitute(long id);

        Task<IEnumerable<MoscowInstitutes>> GetAllInstitutes();

        Task<IEnumerable<MoscowInstitutes>> QueryInstitutes(Expression<Func<MoscowInstitutes, bool>> filter);
    }
}

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
        Task AddInstitute(DomainObjects.MoscowInstitute MInstitute);

        Task RemoveInstitute(DomainObjects.MoscowInstitute MInstitute);

        Task UpdateInstitute(DomainObjects.MoscowInstitute MInstitute);

        Task<DomainObjects.MoscowInstitute> GetInstitute(long id);

        Task<IEnumerable<DomainObjects.MoscowInstitute>> GetAllInstitutes();

        Task<IEnumerable<DomainObjects.MoscowInstitute>> QueryInstitutes(Expression<Func<DomainObjects.MoscowInstitute, bool>> filter);

    }
}

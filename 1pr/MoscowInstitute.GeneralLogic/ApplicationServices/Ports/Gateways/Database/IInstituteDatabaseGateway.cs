using MoscowInstitute.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowInstitute.ApplicationServices.Ports.Gateways.Database
{
    public interface IInstituteDatabaseGateway
    {
        Task AddInstitute(DomainObjects.MoscowInstitute route);

        Task RemoveInstitute(DomainObjects.MoscowInstitute route);

        Task UpdateInstitute(DomainObjects.MoscowInstitute route);

        Task<DomainObjects.MoscowInstitute> GetInstitute(long id);

        Task<IEnumerable<DomainObjects.MoscowInstitute>> GetAllInstitutes();

        Task<IEnumerable<DomainObjects.MoscowInstitute>> QueryInstitutes(Expression<Func<DomainObjects.MoscowInstitute, bool>> filter);
    }
}

using MoscowInstitute.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoscowInstitute.ApplicationServices.Ports.Gateways.Database
{
    public interface IInstituteDatabaseGateway
    {
        Task AddInstitute(Institute institute);

        Task RemoveInstitute(Institute institute);

        Task UpdateInstitute(Institute institute);

        Task<Institute> GetInstitute(long id);

        Task<IEnumerable<Institute>> GetAllInstitutes();

        Task<IEnumerable<Institute>> QueryInstitutes(Expression<Func<Institute, bool>> filter);

    }
}

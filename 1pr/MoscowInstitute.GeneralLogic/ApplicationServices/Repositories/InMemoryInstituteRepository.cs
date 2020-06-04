using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoscowInstitute.ApplicationServices.Repositories
{
    public class InMemoryInstituteRepository : IReadOnlyInstituteRepository,
                                           IInstituteRepository 
    {
        private readonly List<DomainObjects.MoscowInstitute> _institutes = new List<DomainObjects.MoscowInstitute>();

        public InMemoryInstituteRepository(IEnumerable<DomainObjects.MoscowInstitute> institutes = null)
        {
            if (institutes != null)
            {
                _institutes.AddRange(institutes);
            }
        }

        public Task AddInstitute(DomainObjects.MoscowInstitute institute)
        {
            _institutes.Add(institute);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<DomainObjects.MoscowInstitute>> GetAllInstitutes()
        {
            return Task.FromResult(_institutes.AsEnumerable());
        }

        public Task<DomainObjects.MoscowInstitute> GetInstitute(long id)
        {
            return Task.FromResult(_institutes.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<DomainObjects.MoscowInstitute>> QueryInstitutes(ICriteria<DomainObjects.MoscowInstitute> criteria)
        {
            return Task.FromResult(_institutes.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveInstitute(DomainObjects.MoscowInstitute institute)
        {
            _institutes.Remove(institute);
            return Task.CompletedTask;
        }

        public Task UpdateInstitute(DomainObjects.MoscowInstitute institute)
        {
            var foundinstitute = GetInstitute(institute.Id).Result;
            if (foundinstitute == null)
            {
                AddInstitute(institute);
            }
            else
            {
                if (foundinstitute != institute)
                {
                    _institutes.Remove(foundinstitute);
                    _institutes.Add(institute);
                }
            }
            return Task.CompletedTask;
        }
    }
}

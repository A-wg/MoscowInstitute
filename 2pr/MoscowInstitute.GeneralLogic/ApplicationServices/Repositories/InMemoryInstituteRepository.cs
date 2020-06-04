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
        private readonly List<MoscowInstitutes> _institutes = new List<MoscowInstitutes>();

        public InMemoryInstituteRepository(IEnumerable<MoscowInstitutes> institutes = null)
        {
            if (institutes != null)
            {
                _institutes.AddRange(institutes);
            }
        }

        public Task AddInstitute(MoscowInstitutes institute)
        {
            _institutes.Add(institute);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<MoscowInstitutes>> GetAllInstitutes()
        {
            return Task.FromResult(_institutes.AsEnumerable());
        }

        public Task<MoscowInstitutes> GetInstitute(long id)
        {
            return Task.FromResult(_institutes.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<MoscowInstitutes>> QueryInstitutes(ICriteria<MoscowInstitutes> criteria)
        {
            return Task.FromResult(_institutes.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveInstitute(MoscowInstitutes institute)
        {
            _institutes.Remove(institute);
            return Task.CompletedTask;
        }

        public Task UpdateInstitute(MoscowInstitutes institute)
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

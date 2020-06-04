using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoscowInstitute.ApplicationServices.Repositories
{
    public class InMemoryInstituteRepository : IReadOnlyInstituteRepository,
                                           IInstituteRepository
    {
        private readonly List<Institute> _institutes = new List<Institute>();

        public InMemoryInstituteRepository(IEnumerable<Institute> institutes = null)
        {
            if (institutes != null)
            {
                _institutes.AddRange(institutes);
            }
        }

        public Task AddInstitute(Institute institute)
        {
            _institutes.Add(institute);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Institute>> GetAllInstitutes()
        {
            return Task.FromResult(_institutes.AsEnumerable());
        }

        public Task<Institute> GetInstitute(long id)
        {
            return Task.FromResult(_institutes.Where(o => o.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Institute>> QueryInstitutes(ICriteria<Institute> criteria)
        {
            return Task.FromResult(_institutes.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveInstitute(Institute institute)
        {
            _institutes.Remove(institute);
            return Task.CompletedTask;
        }

        public Task UpdateInstitute(Institute institute)
        {
            var foundInstitute = GetInstitute(institute.Id).Result;
            if (foundInstitute == null)
            {
                AddInstitute(institute);
            }
            else
            {
                if (foundInstitute != institute)
                {
                    _institutes.Remove(foundInstitute);
                    _institutes.Add(institute);
                }
            }
            return Task.CompletedTask;
        }
        public Task ParseAndPush()
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class InMemoryMInstituteRepository : IReadOnlyInstituteRepository,
                                           IInstituteRepository 
    {
        private readonly List<DomainObjects.MoscowInstitute> _MInstitutes = new List<DomainObjects.MoscowInstitute>();

        public InMemoryMInstituteRepository(IEnumerable<DomainObjects.MoscowInstitute> MInstitutes = null)
        {
            if (MInstitutes != null)
            {
                _MInstitutes.AddRange(MInstitutes);
            }
        }

        public Task AddInstitute(DomainObjects.MoscowInstitute MInstitute)
        {
            _MInstitutes.Add(MInstitute);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<DomainObjects.MoscowInstitute>> GetAllInstitutes()
        {
            return Task.FromResult(_MInstitutes.AsEnumerable());
        }

        public Task<DomainObjects.MoscowInstitute> GetInstitute(long id)
        {
            return Task.FromResult(_MInstitutes.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<DomainObjects.MoscowInstitute>> QueryInstitutes(ICriteria<DomainObjects.MoscowInstitute> criteria)
        {
            return Task.FromResult(_MInstitutes.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveInstitute(DomainObjects.MoscowInstitute MInstitute)
        {
            _MInstitutes.Remove(MInstitute);
            return Task.CompletedTask;
        }

        public Task UpdateInstitute(DomainObjects.MoscowInstitute MInstitute)
        {
            var foundinstitute = GetInstitute(MInstitute.Id).Result;
            if (foundinstitute == null)
            {
                AddInstitute(MInstitute);
            }
            else
            {
                if (foundinstitute != MInstitute)
                {
                    _MInstitutes.Remove(foundinstitute);
                    _MInstitutes.Add(MInstitute);
                }
            }
            return Task.CompletedTask;
        }
    }
}

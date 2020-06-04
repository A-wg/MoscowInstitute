using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MoscowInstitute.ApplicationServices.GetInstituteListUseCase
{
    public class LegalAddressCriteria : ICriteria<Institute>
    {
        public string LegalAddress { get; }

        public LegalAddressCriteria(string legalAddress)
            => LegalAddress = legalAddress;

        public Expression<Func<Institute, bool>> Filter
            => (s => s.LegalAddress == LegalAddress);
    }
}

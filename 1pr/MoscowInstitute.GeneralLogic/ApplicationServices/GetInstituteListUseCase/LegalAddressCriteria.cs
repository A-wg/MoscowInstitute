using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MoscowInstitute.ApplicationServices.GetInstituteListUseCase
{
    public class LegalAddressCriteria : ICriteria<DomainObjects.MoscowInstitute>
    {
        public string LegalAddress { get; }

        public LegalAddressCriteria(string legaladdress)
            => LegalAddress = legaladdress;

        public Expression<Func<DomainObjects.MoscowInstitute, bool>> Filter
            => (r => r.LegalAddress == LegalAddress);
    }
}

using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MoscowInstitute.ApplicationServices.GetMInstituteListUseCase
{
    public class LegalAddressCriteria : ICriteria<MoscowInstitutes>
    {
        public string LegalAddress { get; }

        public LegalAddressCriteria(string legaladdress)
            => LegalAddress = legaladdress;

        public Expression<Func<MoscowInstitutes, bool>> Filter
            => (r => r.LegalAddress == LegalAddress);
    }
}

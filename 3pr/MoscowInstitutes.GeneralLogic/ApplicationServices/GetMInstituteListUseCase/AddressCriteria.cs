using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MoscowInstitute.ApplicationServices.GetMInstituteListUseCase
{
    public class AddressCriteria : ICriteria<DomainObjects.MoscowInstitute>
    {
        public string Address { get; }

        public AddressCriteria(string address)
            => Address = address;

        public Expression<Func<DomainObjects.MoscowInstitute, bool>> Filter
            => (r => r.LegalAddress == Address);
    }
}

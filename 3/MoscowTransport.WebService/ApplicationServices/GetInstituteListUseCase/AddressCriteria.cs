using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MoscowInstitute.ApplicationServices.GetInstituteListUseCase
{
    public class AddressCriteria : ICriteria<Institute>
    {
        public string Address { get; }

        public AddressCriteria(string address)
            => Address = address;

        public Expression<Func<Institute, bool>> Filter
            => (i => i.Address == Address);
    }
}

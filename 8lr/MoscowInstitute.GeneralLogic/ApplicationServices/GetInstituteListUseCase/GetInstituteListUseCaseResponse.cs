using MoscowInstitute.DomainObjects;
using MoscowInstitute.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoscowInstitute.ApplicationServices.GetInstituteListUseCase
{
    public class GetInstituteListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<Institute> Institutes { get; }

        public GetInstituteListUseCaseResponse(IEnumerable<Institute> institutes) => Institutes = institutes;
    }
}

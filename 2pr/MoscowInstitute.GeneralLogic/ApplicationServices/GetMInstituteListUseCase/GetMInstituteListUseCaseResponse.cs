using MoscowInstitute.DomainObjects;
using MoscowInstitute.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowInstitute.ApplicationServices.GetMInstituteListUseCase
{
    public class GetMInstituteListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<MoscowInstitutes> MoscowInstitute { get; }

        public GetMInstituteListUseCaseResponse(IEnumerable<MoscowInstitutes> transferinstitute) => MoscowInstitute = transferinstitute;
    }
}

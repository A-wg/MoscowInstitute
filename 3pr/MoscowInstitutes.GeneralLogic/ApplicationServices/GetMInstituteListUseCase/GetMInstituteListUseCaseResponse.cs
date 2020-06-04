using MoscowInstitute.DomainObjects;
using MoscowInstitute.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowInstitute.ApplicationServices.GetMInstituteListUseCase
{
    public class GetMInstituteListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<DomainObjects.MoscowInstitute> MoscowInstitute { get; }

        public GetMInstituteListUseCaseResponse(IEnumerable<DomainObjects.MoscowInstitute> moscowinstitute) => MoscowInstitute = moscowinstitute;
    }
}

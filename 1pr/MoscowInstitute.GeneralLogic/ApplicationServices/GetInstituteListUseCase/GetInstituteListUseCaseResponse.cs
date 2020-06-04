using MoscowInstitute.DomainObjects;
using MoscowInstitute.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowInstitute.ApplicationServices.GetInstituteListUseCase
{
    public class GetInstituteListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<DomainObjects.MoscowInstitute> Routes { get; }

        public GetInstituteListUseCaseResponse(IEnumerable<DomainObjects.MoscowInstitute> routes) => Routes = routes;
    }
}

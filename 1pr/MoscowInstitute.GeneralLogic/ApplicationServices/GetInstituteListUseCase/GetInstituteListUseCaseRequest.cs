using MoscowInstitute.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowInstitute.ApplicationServices.GetInstituteListUseCase
{
    public class GetInstituteListUseCaseRequest : IUseCaseRequest<GetInstituteListUseCaseResponse>
    {
        public string? LegalAddress { get; private set; }
        public long? InstituteId { get; private set; }

        private GetInstituteListUseCaseRequest()
        { }

        public static GetInstituteListUseCaseRequest CreateAllInstitutesRequest()
        {
            return new GetInstituteListUseCaseRequest();
        }

        public static GetInstituteListUseCaseRequest CreateInstituteRequest(long InstituteId)
        {
            return new GetInstituteListUseCaseRequest() { InstituteId = InstituteId };
        }
        public static GetInstituteListUseCaseRequest CreateLegalAddressRequest(string legaladdress)
        {
            return new GetInstituteListUseCaseRequest() { LegalAddress = legaladdress };
        }
    }
}

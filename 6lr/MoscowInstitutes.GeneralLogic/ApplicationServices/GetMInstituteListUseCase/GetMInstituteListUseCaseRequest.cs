using MoscowInstitute.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowInstitute.ApplicationServices.GetMInstituteListUseCase
{
    public class GetMInstituteListUseCaseRequest : IUseCaseRequest<GetMInstituteListUseCaseResponse>
    {
        public string? LegalAddress { get; private set; }
        public long? MInstituteId { get; private set; }

        private GetMInstituteListUseCaseRequest()
        { }

        public static GetMInstituteListUseCaseRequest CreateAllMInstitutesRequest()
        {
            return new GetMInstituteListUseCaseRequest();
        }

        public static GetMInstituteListUseCaseRequest CreateMInstituteRequest(long MInstituteId)
        {
            return new GetMInstituteListUseCaseRequest() { MInstituteId = MInstituteId };
        }
        public static GetMInstituteListUseCaseRequest CreateLegalAddressRequest(string legaladdress)
        {
            return new GetMInstituteListUseCaseRequest() { LegalAddress = legaladdress };
        }
    }
}

using MoscowInstitute.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowInstitute.ApplicationServices.GetInstituteListUseCase
{
    public class GetInstituteListUseCaseRequest : IUseCaseRequest<GetInstituteListUseCaseResponse>
    {
        public string Address { get; private set; }
        public long? InstituteId { get; private set; }

        private GetInstituteListUseCaseRequest()
        { }

        public static GetInstituteListUseCaseRequest CreateAllInstitutesRequest()
        {
            return new GetInstituteListUseCaseRequest();
        }

        public static GetInstituteListUseCaseRequest CreateInstituteRequest(long instituteId)
        {
            return new GetInstituteListUseCaseRequest() { InstituteId = instituteId };
        }
        public static GetInstituteListUseCaseRequest CreateAddressInstituteRequest(string address)
        {
            return new GetInstituteListUseCaseRequest() { Address = address };
        }
    }
}

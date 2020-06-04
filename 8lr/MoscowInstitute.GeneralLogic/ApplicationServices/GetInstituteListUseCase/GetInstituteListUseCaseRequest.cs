using MoscowInstitute.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoscowInstitute.ApplicationServices.GetInstituteListUseCase
{
    public class GetInstituteListUseCaseRequest : IUseCaseRequest<GetInstituteListUseCaseResponse>
    {
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
    }
}


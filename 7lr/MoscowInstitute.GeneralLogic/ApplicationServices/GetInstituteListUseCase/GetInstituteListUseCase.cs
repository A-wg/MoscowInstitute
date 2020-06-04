using System.Threading.Tasks;
using System.Collections.Generic;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using MoscowInstitute.ApplicationServices.Ports;

namespace MoscowInstitute.ApplicationServices.GetInstituteListUseCase
{
    public class GetInstituteListUseCase : IGetInstituteListUseCase
    {
        private readonly IReadOnlyInstituteRepository _readOnlyInstituteRepository;

        public GetInstituteListUseCase(IReadOnlyInstituteRepository readOnlyInstituteRepository)
            => _readOnlyInstituteRepository = readOnlyInstituteRepository;

        public async Task<bool> Handle(GetInstituteListUseCaseRequest request, IOutputPort<GetInstituteListUseCaseResponse> outputPort)
        {
            IEnumerable<Institute> institutes = null;
            if (request.InstituteId != null)
            {
                var institute = await _readOnlyInstituteRepository.GetInstitute(request.InstituteId.Value);
                institutes = (institute != null) ? new List<Institute>() { institute } : new List<Institute>();

            }
            else
            {
                institutes = await _readOnlyInstituteRepository.GetAllInstitutes();
            }
            outputPort.Handle(new GetInstituteListUseCaseResponse(institutes));
            return true;
        }
    }
}

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
            IEnumerable<DomainObjects.MoscowInstitute> Institutes = null;
            if (request.InstituteId != null)
            {
                var Institute = await _readOnlyInstituteRepository.GetInstitute(request.InstituteId.Value);
                Institutes = (Institute != null) ? new List<DomainObjects.MoscowInstitute>() { Institute } : new List<DomainObjects.MoscowInstitute>();

            }
            else if (request.LegalAddress != null)
            {
                Institutes = await _readOnlyInstituteRepository.QueryInstitutes(new LegalAddressCriteria(request.LegalAddress));
            }
            else
            {
                Institutes = await _readOnlyInstituteRepository.GetAllInstitutes();
            }
            outputPort.Handle(new GetInstituteListUseCaseResponse(Institutes));
            return true;
        }
    }
}

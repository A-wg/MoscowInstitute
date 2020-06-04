using System.Threading.Tasks;
using System.Collections.Generic;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.DomainObjects.Ports;
using MoscowInstitute.ApplicationServices.Ports;

namespace MoscowInstitute.ApplicationServices.GetMInstituteListUseCase
{
    public class GetMInstituteListUseCase : IGetMInstituteListUseCase
    {
        private readonly IReadOnlyInstituteRepository _readOnlyMInstituteRepository;

        public GetMInstituteListUseCase(IReadOnlyInstituteRepository readOnlyMInstituteRepository) 
            => _readOnlyMInstituteRepository = readOnlyMInstituteRepository;

        public async Task<bool> Handle(GetMInstituteListUseCaseRequest request, IOutputPort<GetMInstituteListUseCaseResponse> outputPort)
        {
            IEnumerable<DomainObjects.MoscowInstitute> MInstitutes = null;
            if (request.MInstituteId != null)
            {
                var MInstitute = await _readOnlyMInstituteRepository.GetInstitute(request.MInstituteId.Value);
                MInstitutes = (MInstitute != null) ? new List<DomainObjects.MoscowInstitute>() { MInstitute } : new List<DomainObjects.MoscowInstitute>();
                
            }
            else if (request.LegalAddress != null)
            {
                MInstitutes = await _readOnlyMInstituteRepository.QueryInstitutes(new LegalAddressCriteria(request.LegalAddress));
            }
            else
            {
                MInstitutes = await _readOnlyMInstituteRepository.GetAllInstitutes();
            }
            outputPort.Handle(new GetMInstituteListUseCaseResponse(MInstitutes));
            return true;
        }
    }
}

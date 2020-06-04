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
            IEnumerable<MoscowInstitutes> MInstitutes = null;
            if (request.MInstituteId != null)
            {
                var MInstitute = await _readOnlyMInstituteRepository.GetInstitute(request.MInstituteId.Value);
                MInstitutes = (MInstitute != null) ? new List<MoscowInstitutes>() { MInstitute } : new List<MoscowInstitutes>();
                
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

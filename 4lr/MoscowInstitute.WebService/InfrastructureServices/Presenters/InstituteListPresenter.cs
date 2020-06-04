using System.Net;
using Newtonsoft.Json;
using MoscowInstitute.ApplicationServices.Ports;
using MoscowInstitute.ApplicationServices.GetInstituteListUseCase;

namespace MoscowInstitute.InfrastructureServices.Presenters
{
    public class InstituteListPresenter : IOutputPort<GetInstituteListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public InstituteListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetInstituteListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Institutes) : JsonConvert.SerializeObject(response.Message);
        }
    }
}

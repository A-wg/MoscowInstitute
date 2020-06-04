using MoscowInstitute.ApplicationServices.GetMInstituteListUseCase;
using System.Net;
using Newtonsoft.Json;
using MoscowInstitute.ApplicationServices.Ports;

namespace MoscowInstitute.InfrastructureServices.Presenters
{
    public class InstituteListPresenter : IOutputPort<GetMInstituteListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public InstituteListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetMInstituteListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.MoscowInstitute) : JsonConvert.SerializeObject(response.Message);
        }
    }
}

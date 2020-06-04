using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.ApplicationServices.GetInstituteListUseCase;
using MoscowInstitute.InfrastructureServices.Presenters;

namespace MoscowInstitute.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstituteController : ControllerBase
    {
        private readonly ILogger<InstituteController> _logger;
        private readonly IGetInstituteListUseCase _getInstituteListUseCase;

        public InstituteController(ILogger<InstituteController> logger, IGetInstituteListUseCase getInstituteListUseCase)
        {
            _logger = logger; 
            _getInstituteListUseCase = getInstituteListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInstitutes()
        {
            var presenter = new InstituteListPresenter();
            await _getInstituteListUseCase.Handle(GetInstituteListUseCaseRequest.CreateAllInstitutesRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{routeId}")]
        public async Task<ActionResult> GetInstitute(long instituteId) 
        {
            var presenter = new InstituteListPresenter();
            await _getInstituteListUseCase.Handle(GetInstituteListUseCaseRequest.CreateInstituteRequest(instituteId), presenter);
            return presenter.ContentResult;
        }
    }
}

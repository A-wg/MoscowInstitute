using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.ApplicationServices.GetInstituteListUseCase;
using MoscowInstitute.InfrastructureServices.Presenters;

namespace MoscowInstitute.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstituteController : ControllerBase
    {
        private readonly ILogger<InstituteController> _logger;
        private readonly IGetInstituteListUseCase _getInstituteListUseCase;

        public InstituteController(ILogger<InstituteController> logger,
                                IGetInstituteListUseCase getInstituteListUseCase)
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

        [HttpGet("{instituteId}")]
        public async Task<ActionResult> GetInstitute(long instituteID)
        {
            var presenter = new InstituteListPresenter();
            await _getInstituteListUseCase.Handle(GetInstituteListUseCaseRequest.CreateInstituteRequest(instituteID), presenter);
            return presenter.ContentResult;
        }

    }
}

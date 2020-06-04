using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.ApplicationServices.GetMInstituteListUseCase;
using MoscowInstitute.InfrastructureServices.Presenters;

namespace MoscowInstitute.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MInstituteController : ControllerBase
    {
        private readonly ILogger<MInstituteController> _logger;
        private readonly IGetMInstituteListUseCase _getInstituteListUseCase;

        public MInstituteController(ILogger<MInstituteController> logger,
                                IGetMInstituteListUseCase getInstituteListUseCase)
        {
            _logger = logger;
            _getInstituteListUseCase = getInstituteListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInstitutes()
        {
            var presenter = new InstituteListPresenter();
            await _getInstituteListUseCase.Handle(GetMInstituteListUseCaseRequest.CreateAllInstitutesRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{instituteId}")]
        public async Task<ActionResult> GetInstitute(long instituteId)
        {
            var presenter = new InstituteListPresenter();
            await _getInstituteListUseCase.Handle(GetMInstituteListUseCaseRequest.CreateMInstituteRequest(instituteId), presenter);
            return presenter.ContentResult;
        }
    }
}

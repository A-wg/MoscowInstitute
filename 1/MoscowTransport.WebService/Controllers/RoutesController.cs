using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoscowInstitute.DomainObjects;

namespace MoscowInstitute.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly ILogger<RoutesController> _logger;

        public RoutesController(ILogger<RoutesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Institute> GetRoute()
        {
            return new List<Institute>() 
            { 
                new Institute() 
                {
                 Id = 1,
                    NameInstitute = "ГБОУ ДО ДТДМ «Хорошево»",
                    Site = "dtim.mskobr.ru",
                    Address = "123154, ГОРОД МОСКВА, УЛИЦА МАРШАЛА ТУХАЧЕВСКОГО, 20, 1",
                    Program = "Дополнительное образование | дополнительное образование детей # Дополнительное образование | дополнительное профессиональное образование # Дополнительное образование | дополнительное образование взрослых  "

                }
            };
        }
    }
}

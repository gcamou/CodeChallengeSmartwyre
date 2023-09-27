using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RebateController : ControllerBase
    {
        private readonly IRebateService _rebateService;

        private readonly ILogger<RebateController> _logger;


        public RebateController(ILogger<RebateController> logger, IRebateService rebateService)
        {
            _logger = logger;
            _rebateService = rebateService;
        }

        [HttpPut]
        public ActionResult CalculateRebate(CalculateRebateRequest request)
        {
            _rebateService.Calculate(request);

            return Ok();
        }
    }
}
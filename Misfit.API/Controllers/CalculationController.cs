using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misfit.CORE.Domains;
using Misfit.CORE.ViewModels;
using Misfit.SERVICE.Services;

namespace Misfit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        CalculationService calculationService;

        public CalculationController(CalculationService calculationService)
        {
            this.calculationService = calculationService;
        }

        [HttpPost]
        [Route("sumoftwonumbers")]
        public IActionResult CalculateSum(CalculateVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<bool>()
                {
                    Success = false,
                    Data = false,
                    ErrorMessage = "Model is not valid"
                });
            }
            return Ok(calculationService.CalculateSum(model));
        }
    }
}
using Formulario.Core.DTOs;
using Formulario.Core.Entities;
using Formulario.Core.Helpers;
using Formulario.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IConfiguration _configuration;

        public TestController(ITestService testService, IConfiguration configuration)
        {
            _testService = testService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> PostExample(RegistroDTO registro)
        {
            Error error = new Error();
            try
            {
                Registro Record = await _testService.AddRecord(registro);
                return Ok(Record);
            }
            catch (Exception)
            {
                error.code = 99;
                error.message = "Internal Server Errorr. Please try again later.";
                Response.StatusCode = 500;
            }
            return StatusCode(Response.StatusCode, error);
        }

    }
}

using Alat.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalGovtController : ControllerBase
    {
        private ILocalGovtRepository _localGoverRepository;

        public LocalGovtController(ILocalGovtRepository localGoverRepository)
        {
            _localGoverRepository = localGoverRepository;
        }
        // GET: api/<LocalGovtController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var result = await _localGoverRepository.GetLocalGovts();
            return StatusCode(result.StatusCode, result);
        }

        // GET api/<LocalGovtController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await  _localGoverRepository.FindLocalGovtsById(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}

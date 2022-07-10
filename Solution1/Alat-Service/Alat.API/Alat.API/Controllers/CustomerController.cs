using Alat.Core.Interfaces;
using Alat.Model;
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
    public class CustomerController : ControllerBase
    {
        private IUserRepository _userRepository;

        public CustomerController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// Get all Customer
        /// </summary>
        /// <returns></returns>
        // GET: api/<CustomerController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _userRepository.GetCustomers(pageNumber, pageSize);
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="customer"></param>
        // POST api/<CustomerController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            var result = await _userRepository.CreateUserAsync(customer);
            return StatusCode(result.StatusCode, result);
        }
    }
}

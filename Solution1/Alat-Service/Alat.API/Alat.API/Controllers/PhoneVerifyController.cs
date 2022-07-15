using Alat.Core.Interfaces;
using Alat.Dtos;
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
    public class PhoneVerifyController : ControllerBase
    {
        private IVerificationService _verificationService;

        public PhoneVerifyController(IVerificationService verificationService)
        {
            _verificationService = verificationService;
        }

        // POST api/<PhoneVerifyController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] VerificationDto verificationDto)
        {
          var verfyResult = await _verificationService.RequestVerificationOTP(verificationDto);
          return StatusCode(verfyResult.StatusCode, verfyResult);
        }


        // POST api/<PhoneVerifyController>
        [HttpPost]
        [Route("verifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto verifyOtpDto)
        {
            var verfyResult = await _verificationService.ValidateOTP(verifyOtpDto);
            return StatusCode(verfyResult.StatusCode, verfyResult);
        }
    }
}

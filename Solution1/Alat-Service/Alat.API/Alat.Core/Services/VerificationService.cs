using Alat.Core.Interfaces;
using Alat.Core.Repository;
using Alat.Data;
using Alat.Dtos;
using Alat.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alat.Core.Services
{
    public class VerificationService : IVerificationService
    {
        private AppDbContext _appDbContext;
        private IResponseFactory _responseService;

        public VerificationService(AppDbContext appDbContext, IResponseFactory responseService)
        {
            _appDbContext = appDbContext;
            _responseService = responseService;
        }
        public async Task<ExecutionResponse<object>> RequestVerificationOTP(VerificationDto verificationDto)
        {

            var accountVerification =  _appDbContext.otpVerifications.FirstOrDefault(x => x.PhoneNumber == verificationDto.PhoneNumber);
            var code = Guid.NewGuid().ToString("N").Substring(0, 5);

            if (accountVerification != null)
            {
                accountVerification.Code = code;
                accountVerification.ExpiresIn = DateTime.Now.AddMinutes(5);
                accountVerification.IsVerified = false;
                accountVerification.PhoneNumber = verificationDto.PhoneNumber;

                _appDbContext.otpVerifications.Update(accountVerification);
            }
            else
            {
                var verification = new OtpVerification
                {
                    Code = code,
                    ExpiresIn = DateTime.Now.AddMinutes(10),
                    IsVerified = false,
                    PhoneNumber = verificationDto.PhoneNumber
               };
                _appDbContext.otpVerifications.Add(verification);
            }

            await _appDbContext.SaveChangesAsync();
            return _responseService.ExecutionResponse<object>($"OTP {code} has been sent to {verificationDto.PhoneNumber} ", statusCode: StatusCodes.Status200OK);
        }

        public async Task<ExecutionResponse<object>> ValidateOTP(VerifyOtpDto verifyOtpDto)
        {
            var phoneVerification =  _appDbContext.otpVerifications.FirstOrDefault(x => x.Code == verifyOtpDto.OtpCode && x.PhoneNumber == verifyOtpDto.PhoneNumber && x.ExpiresIn > DateTime.Now );
           
            if (phoneVerification == null)
                return _responseService.ExecutionResponse<object>("invalid otp", status: false, statusCode: StatusCodes.Status400BadRequest);


            phoneVerification.IsVerified = true;
            _appDbContext.otpVerifications.Update(phoneVerification);
            await _appDbContext.SaveChangesAsync();

            return _responseService.ExecutionResponse<object>("valid otp", null, status: true, statusCode: StatusCodes.Status200OK);
        }


        public async Task<ExecutionResponse<object>> OtpStatus(string phoneNumber)
        {
            var phoneVerification = _appDbContext.otpVerifications.FirstOrDefault(x => x.PhoneNumber == phoneNumber && x.IsVerified == true);

            if (phoneVerification == null)
                return _responseService.ExecutionResponse<object>("PhoneNumber Not Verified ", status: false, statusCode: StatusCodes.Status400BadRequest);


            return _responseService.ExecutionResponse<object>("valid otp", null, status: true, statusCode: StatusCodes.Status200OK);
        }
    }
}

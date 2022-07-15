using Alat.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alat.Core.Interfaces
{
    public interface IVerificationService
    {
       Task<ExecutionResponse<object>> RequestVerificationOTP(VerificationDto verificationDto);
       Task<ExecutionResponse<object>> ValidateOTP(VerifyOtpDto verifyOtpDto);
       Task<ExecutionResponse<object>> OtpStatus(string phoneNumber);
    }
}

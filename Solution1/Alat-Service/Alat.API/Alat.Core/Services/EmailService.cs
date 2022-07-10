using Alat.Core.Interfaces;
using Alat.Core.Repository;
using Alat.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alat.Core.Services
{
    public class EmailService : IEmailService
    {
        private IResponseFactory _responseService;

        public EmailService(IResponseFactory responseService)
        {
            _responseService = responseService;
        }
        public async Task<ExecutionResponse<String>> SendEmail(string phoneNumber)
        {
            return _responseService.ExecutionResponse<String>("Email Sent to Customer", null);
        }
    }
}

using Alat.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alat.Core.Interfaces
{
    public interface IEmailService
    {
        Task<ExecutionResponse<String>> SendEmail(string phoneNumber);
    }
}

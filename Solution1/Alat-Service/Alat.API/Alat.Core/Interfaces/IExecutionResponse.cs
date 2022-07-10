using System;
using System.Collections.Generic;
using System.Text;

namespace Alat.Core.Interfaces
{
    public interface IExecutionResponse<T> where T : class
    {
        T Data { get; set; }
        string Message { get; set; }
        bool Status { get; set; }
        int StatusCode { get; set; }
    }
}

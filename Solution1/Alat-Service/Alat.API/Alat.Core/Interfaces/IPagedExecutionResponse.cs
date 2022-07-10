using System;
using System.Collections.Generic;
using System.Text;

namespace Alat.Core.Repository
{
    public interface IPagedExecutionResponse<T> where T : class
    {
        T Data { get; set; }
        string Message { get; set; }
        int StatusCode { get; set; }
        bool Status { get; set; }
        long TotalRecords { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace Alat.Dtos
{
 
    public class ExecutionResponse<T> where T : class 
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public T Data { get; set; }
    }


    public class PagedExecutionResponse<T>  where T : class 
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public long TotalRecords { get; set; }

        public T Data { get; set; }
    }
}

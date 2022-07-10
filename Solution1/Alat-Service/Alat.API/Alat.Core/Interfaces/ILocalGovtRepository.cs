using Alat.Dtos;
using Alat.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alat.Core.Interfaces
{
    public interface ILocalGovtRepository
    {
        Task<ExecutionResponse<IEnumerable<Lga>>> GetLocalGovts();
        Task<ExecutionResponse<Lga>> FindLocalGovtsById(int Id);
    }
}

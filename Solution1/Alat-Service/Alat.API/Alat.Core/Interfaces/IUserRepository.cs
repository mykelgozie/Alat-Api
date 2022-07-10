using Alat.Dtos;
using Alat.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alat.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<ExecutionResponse<ApplicationUser>> CreateUserAsync(Customer customer);
        Task<PagedExecutionResponse<IEnumerable<ApplicationUser>>> GetCustomers(int pageNumber = 1, int pageSize = 10);


    }
}

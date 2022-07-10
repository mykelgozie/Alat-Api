using Alat.Core.Interfaces;
using Alat.Data;
using Alat.Dtos;
using Alat.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alat.Core.Repository
{
    public class LocalGovtRepository : ILocalGovtRepository
    {
        private AppDbContext _appDbContext;
        private IResponseFactory _responseService;
        private ILogger<LocalGovtRepository> _logger;

        public LocalGovtRepository( AppDbContext appDbContext, IResponseFactory responseService, ILogger<LocalGovtRepository> logger)
        {
            _appDbContext = appDbContext;
            _responseService = responseService;
            _logger = logger;
        }
        public async Task<ExecutionResponse<IEnumerable<Lga>>> GetLocalGovts()
        {
            _logger.LogInformation("Retrieving Local Goverments ");
            var lgas =  _appDbContext.Lgas.Include(x => x.state).ToList().AsEnumerable();
            return _responseService.ExecutionResponse<IEnumerable<Lga>>("Local Govt ", lgas,true,200);
        }

        public async Task<ExecutionResponse<Lga>> FindLocalGovtsById(int Id)
        {
            try
            {
                var lga = await _appDbContext.Lgas.Include(x => x.state).FirstOrDefaultAsync(x => x.Id == Id);

                if (lga != null)
                {
                    _logger.LogInformation($"Retrieving Local Goverment by {Id} ");
                    return _responseService.ExecutionResponse<Lga>("Local Govt ", lga, true, 200);
                }
                return _responseService.ExecutionResponse<Lga>("No Local Govt Found ", lga, false, 400);

            }
            catch (Exception ex)
            {
                return _responseService.ExecutionResponse<Lga>($"Error {ex.Message} ", null, true, 500);
            }
         
        }
    }
}

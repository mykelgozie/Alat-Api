using Alat.Core.Interfaces;
using Alat.Data;
using Alat.Dtos;
using Alat.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alat.Core.Repository
{
    
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IResponseFactory _responseService;
        private readonly AppDbContext _appDbContext;
        private readonly IEmailService _emailService;
        private readonly ILogger<UserRepository> _logger;
        private readonly ILocalGovtRepository _localGovtRepository;
        private readonly IVerificationService _verificationService;

        public UserRepository(UserManager<ApplicationUser> userManager, ILogger<UserRepository> logger, IResponseFactory responseService, AppDbContext appDbContext, IEmailService emailService, ILocalGovtRepository localGovtRepository, IVerificationService verificationService)
        {
            _userManager = userManager;
            _responseService = responseService;
            _appDbContext = appDbContext;
            _emailService = emailService;
            _logger = logger;
            _localGovtRepository = localGovtRepository;
            _verificationService = verificationService;
        }

        public async Task<ExecutionResponse<ApplicationUser>> CreateUserAsync(Customer customer)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(customer.Email);

                if (user != null)
                {
                    _logger.LogInformation($" Customer already Exist");
                    return _responseService.ExecutionResponse<ApplicationUser>("User already Exist in the system", null);
                }

               var phoneNumberStatus = await _verificationService.OtpStatus(customer.PhoneNumber);

                if (!phoneNumberStatus.Status)
                {
                    return _responseService.ExecutionResponse<ApplicationUser>("Phone Number Not Verified", null);
                }


                var lgaResult = await _localGovtRepository.FindLocalGovtsById(customer.Lga);

                if (!lgaResult.Status)
                {
                    _logger.LogInformation($"Local Government not Found");
                    return _responseService.ExecutionResponse<ApplicationUser>("Local Goverment Not Found", null, statusCode: 400);
                }

                var newCustomer = new ApplicationUser()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    UserName = customer.Email,
                    PasswordHash = customer.Password,
                    PhoneNumber = customer.PhoneNumber,
                    Lga = lgaResult.Data
                };


                var emailResult = await _emailService.SendEmail(customer.PhoneNumber);
                var userResponse = await _userManager.CreateAsync(newCustomer, customer.Password);

                if (!userResponse.Succeeded)
                {
                    _logger.LogInformation($" Customer Not Created ");
                    return _responseService.ExecutionResponse<ApplicationUser>("Invalid Detail", null, false, StatusCodes.Status400BadRequest);
                }

                _logger.LogInformation($" Customer Created Successfully");
                return _responseService.ExecutionResponse<ApplicationUser>($"Customer Successfully Created, {emailResult.Message} ", null, true, StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return _responseService.ExecutionResponse<ApplicationUser>($"Error {ex.Message}", null, false, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<PagedExecutionResponse<IEnumerable<ApplicationUser>>> GetCustomers(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var users = _userManager.Users;

                if (users == null)
                {
                    _logger.LogInformation($"No Customer Found ");
                    return _responseService.PagedExecutionResponse<IEnumerable<ApplicationUser>>($"Successfully retrieved page {pageNumber} of Users ", users, 0, false);
                }

                _logger.LogInformation($"Successfully retrieved page {pageNumber} of Customer ");
                return _responseService.PagedExecutionResponse<IEnumerable<ApplicationUser>>($"Successfully retrieved page {pageNumber} of Users ", users, users.Count(), true);

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error {ex.Message}");
                return _responseService.PagedExecutionResponse<IEnumerable<ApplicationUser>>($"Error {ex.Message}", null, 0, false);
            }  
        }
    }
}

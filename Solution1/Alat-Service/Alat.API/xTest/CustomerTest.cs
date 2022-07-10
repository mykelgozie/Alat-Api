using Alat.API.Controllers;
using Alat.Core.Interfaces;
using Alat.Core.Repository;
using Alat.Core.Services;
using Alat.Dtos;
using Alat.Model;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xTest
{
    public class CustomerTest
    {
        private Mock<IUserRepository> _mockRepo;
        private CustomerController _controller;
        private Mock<IResponseFactory> _resRepo;

        public CustomerTest()
        {
            _mockRepo = new Mock<IUserRepository>();
            _controller = new CustomerController(_mockRepo.Object);
            _resRepo = new Mock<IResponseFactory>(); 
        }

        [Fact]
        public async Task CreateCustomerTest()
        {
            var customer = new Customer() { FirstName = "hello", Email = "Hello" };
            var user = new ApplicationUser();
            _mockRepo.Setup(repo => repo.CreateUserAsync(customer))
               .ReturnsAsync(
                new ExecutionResponse<ApplicationUser>() 
                {
                    Data = user,
                    Message = "User created", 
                    StatusCode = 200, 
                    Status = true 
                });
         
            var data = await _controller.Post(customer);
            var okResult = data as ObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetCustomerTest()
        {
            var userList = new List<ApplicationUser>();

            for (int i = 0; i < 5; i++)
            {
                var user = new ApplicationUser()
                {
                    FirstName = $"item{i}",
                    LastName = $"item Last{i}",
                    Email = $"item{i}"

                };
                userList.Add(user);

            }
            _mockRepo.Setup(repo => repo.GetCustomers(1,10))
                .ReturnsAsync(new PagedExecutionResponse<IEnumerable<ApplicationUser>>() 
                {
                    Data = userList, 
                    Message = "All users ", 
                    Status = true, 
                    TotalRecords = userList.Count,  
                    StatusCode = 200
                });

            var data = await _controller.Get();
            var okResult = data as ObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }
    }
}

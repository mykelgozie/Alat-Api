using Alat.API.Controllers;
using Alat.Core.Interfaces;
using Alat.Core.Repository;
using Alat.Data;
using Alat.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace zTest
{
    public class CustomerTest
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        public readonly DbContextOptions<AppDbContext> dbContextOptions;
        private Mock<IUserRepository> _mockRepo;
        private CustomerController _controller;

        public CustomerTest()
        {
            _mockRepo = new Mock<IUserRepository>();
            _controller = new CustomerController(_mockRepo.Object);
        }
        [SetUp]
        public void Setup()
        {
      
        }

        //[Test]
        //public async Task GetCustomerTest() 
        //{
        //    var result = await _controller.Get(1,10);
           

        //}

        //[Test]
        //public async Task EmailTestAsync()
        //{

        //   var result =await  _emailService.SendEmail("test");

        //    Assert.IsTrue(result.Status);

        //}
        }
}

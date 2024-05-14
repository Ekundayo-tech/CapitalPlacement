using InternshipPrograms.Application.Dtos;
using InternshipPrograms.Application.Services.Implementations;
using InternshipPrograms.Application.Services.Interfaces;
using InternshipPrograms.Controllers;
using InternshipPrograms.Infrastructures.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace TestProject
{
    public class QuestionsControllerTest
    {
        private readonly QuestionsController _controller;
        private readonly IQuestion _service;
       // private readonly ILogger<QuestionsController> _logger;
        ILoggerFactory loggerFactory;
        private readonly DataContext _context;

        private readonly IServiceProvider _provider;
        private readonly ILogger logger;
        private readonly IServiceScope scope;

        public QuestionsControllerTest(IServiceProvider provider)
        {
            _provider = provider;
            scope = _provider.CreateScope();
            logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            _context = scope.ServiceProvider.GetRequiredService<DataContext>();
            //_logger =  loggerFactory.CreateLogger<EducationController>() ?? null;
            _context = new DataContext(GetAllOptions());
            _service = new QuestionsService(provider);
            _controller = new QuestionsController(null, _service);
        }

        public DbContextOptions<DataContext> GetAllOptions()
        {
            DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            optionsBuilder.UseCosmos(
                "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                "ProgramsDB");

            return optionsBuilder.Options;
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAll().Result;

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAll().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<QuestionsDto>>(okResult.Value);
            Assert.Equal(6, items.Count);
        }
        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(Guid.NewGuid().ToString()).Result;

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = "07ef854c-47a2-4410-a734-762b27357553";

            // Act
            var okResult = _controller.Get(testGuid).Result;

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = "07ef854c-47a2-4410-a734-762b27357553";

            // Act
            var okResult = _controller.Get(testGuid).Result as OkObjectResult;

            // Assert
            Assert.IsType<QuestionsDto>(okResult.Value);
            Assert.Equal(testGuid.ToString(), (okResult.Value as QuestionsDto).Id);
        }

     

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            CreateQuestionsDto testItem = new()
            {
                 Choices = new[] {"s"},
                 EnbaleOtherOptions = true,
                 MaxChoiceAllowed = "2",
                 Name = "test",
                 Type = "test"
            };

            // Act
            var createdResponse = _controller.Post(testItem).Result;

            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            CreateQuestionsDto testItem = new()
            {
                Choices = new[] { "s" },
                EnbaleOtherOptions = true,
                MaxChoiceAllowed = "2",
                Name = "test",
                Type = "test"
            };

            // Act
            var createdResponse = _controller.Post(testItem).Result as OkObjectResult;
            var item = createdResponse.Value as string;

            // Assert
            Assert.IsType<string>(item);
            Assert.Equal("Guinness Original 6 Pack", testItem.Name);
        }

        //[Fact]
        //public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        //{
        //    // Arrange
        //    var notExistingGuid = Guid.NewGuid();

        //    // Act
        //    var badResponse = _controller.Delete(notExistingGuid.ToString());

        //    // Assert
        //    Assert.IsType<OkResult>(badResponse);
        //}

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsNoContentResult()
        {
            // Arrange
            var existingGuid = "8f15ec2d-dce6-4e71-bde2-3a7dd77dff8c";

            // Act
            var noContentResponse = _controller.Delete(existingGuid);

            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
            //Assert.IsType<OkResult>(noContentResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = "7c4be1f2-ac55-4225-8bae-e9b934a49a7d";

            // Act
            var okResponse = _controller.Delete(existingGuid);

            // Assert
            Assert.Equal(2, _service.GetAllAsync().Result.Count());
        }
    }
}
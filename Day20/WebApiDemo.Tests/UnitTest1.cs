namespace WebApiDemo.Tests;

using WebApiDemo;
using DataAccessLayer;
using FakeItEasy;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

public class UnitTest1
{
    [Fact]
    public void Customer_Get_ReturnsCustomerList()
    {
        // Arrange

        var fakeService = A.Fake<ICustomerService>();
        var fakeMapper = A.Fake<IMapper>();
        var fakeValidator = A.Fake<IValidator<CreateCustomerDTO>>();

        var customers = new List<Customer>
        {
            new Customer
            {
                Id = 3,
                Name = "Sarah Smith",
                Email = "sarah.smith@example.com"
            }
        };

        A.CallTo(() => fakeService.GetAllCustomers()).Returns(customers);

        var controller = new CustomerController(
            fakeService,
            fakeMapper,
            fakeValidator
        );

        // Act
        var result = controller.Get();

        // Assert

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedCustomers = Assert.IsType<List<Customer>>(okResult.Value);

        Assert.Equal(200, okResult.StatusCode ?? 200);
        Assert.Single(returnedCustomers);
        Assert.Equal("Sarah Smith", returnedCustomers[0].Name);
    }
}
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace WebAPI.IntegrationTests;

public class IntegrationTest : IClassFixture<WebApplicationFactory<CustomerController>>
{
    private readonly WebApplicationFactory<CustomerController> factory;
    private readonly HttpClient browserWidnow;

    public IntegrationTest(WebApplicationFactory<CustomerController> factory)
    {
        this.factory = factory;
        browserWidnow = factory.CreateClient();
        browserWidnow.BaseAddress = new Uri("http://localhost:5000");
    }

    [Fact]
    public async Task Get_Customers()
    {
        // Arrange

        // Act
        var response = await browserWidnow.GetAsync("/api/v1/customer");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
public async Task Post_Customers()
{
    // Arrange
    var customer = new
    {
        name = "John Doe",
        email = "john@example.com"
    };

    var json = JsonSerializer.Serialize(customer);

    var content = new StringContent(json, Encoding.UTF8, "application/json");

    // Act
    var response = await browserWidnow.PostAsync("/api/v1/customer", content);

    // Assert
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
}
}
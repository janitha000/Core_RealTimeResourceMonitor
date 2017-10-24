using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UserControllerIntegrationTests : BaseHttpTests
{
    protected override void ConfigureServices(IServiceCollection services)
    {
        //services.AddSingleton()
    }

    [TestMethod]
    public void ReadAll()
    {
        var result =  client.GetAsync("api/v1/user");
        Assert.AreSame(200, result.Status, "Status should be 200");


    }
}
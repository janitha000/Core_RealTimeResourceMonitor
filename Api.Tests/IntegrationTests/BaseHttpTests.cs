using System;
using System.Net.Http;
using Api.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

public abstract class BaseHttpTests : IDisposable
{
    protected TestServer server { get; }
    protected HttpClient client { get; }

    protected virtual Uri BaseAddress => new Uri("http://localhost");
    protected virtual string Enviornment => "Development";

    public BaseHttpTests()
    {
        var builder = new WebHostBuilder().
            UseEnvironment(Enviornment).
            ConfigureServices(ConfigureServices).
            UseStartup<Startup>();

        server = new TestServer(builder);
        client = server.CreateClient();
        client.BaseAddress = BaseAddress;
    }

    protected virtual void ConfigureServices(IServiceCollection services)
    {
    }

    private bool disposedValue = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                client.Dispose();
                server.Dispose();
            }
            disposedValue = true;
        }
    }
    public void Dispose()
    {
        Dispose(true);
    }
}
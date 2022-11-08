using Shin.Megami.Tensei.API;
using Shin.Megami.Tensei.Data.Context;
using Shin.Megami.Tensei.Test.Integration.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;

namespace Shin.Megami.Tensei.Test.Integration
{
    public abstract class IntegrationTests
    {
        protected readonly HttpClient _client;
        protected readonly WebApplicationFactory<Startup> _factory;

        protected IntegrationTests()
        {
            _factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(HealthCtx));
                        services.AddDbContext<HealthCtx>((options, context) =>
                        {
                            context.UseNpgsql("Host=localhost; Port=5432; Database=postgres_tests; UserName=postgres; Password=root");
                        }, ServiceLifetime.Transient);

                        var serviceProvider = services.BuildServiceProvider();

                        using (var scope = serviceProvider.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var context = scopedServices.GetRequiredService<HealthCtx>();
                            var logger = scopedServices.GetRequiredService<ILogger<WebApplicationFactory<Startup>>>();

                            context.Database.EnsureCreated();

                            try
                            {
                                context.ReinitializeDatabaseForTests();
                            }
                            catch (Exception ex)
                            {
                                logger.LogError(ex, "An error occured seeding the database with the message: " + ex.Message);
                            }
                        }
                    });
                    builder.UseContentRoot(Directory.GetCurrentDirectory());
                });
            _client = _factory.CreateClient();
        }
    }
}
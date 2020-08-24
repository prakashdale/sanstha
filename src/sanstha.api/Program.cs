using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Convey;
using sanstha.application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using sanstha.infrastructure.mongo;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using sanstha.application.queries;
using sanstha.application.dto;
using System.Collections.Generic;
using sanstha.application.commands;

namespace sanstha.api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args)
                .Build()
                .RunAsync();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => {
                    services
                        .AddControllers()
                        .AddNewtonsoftJson();
                    services
                    .AddConvey()
                    .AddWebApi()
                    .AddApplication()
                    .AddInfrastructure()
                    .Build();
                })
                .Configure(app => {
                    app
                        .UseInfrastructure()
                        .UseDispatcherEndpoints(endpoints => 
                            endpoints
                                .Get<GetResources, IEnumerable<ResourceDto>>("resources")                                
                                .Get<GetResource, ResourceDto>("resources/{resourceid}")
                                .Post<AddResource>("resources", afterDispatch: (cmd, ctx) => ctx.Response.Created($"resources/{cmd.ResourceId}"))                                
                                .Post<ReserveResource>("resources/{resourceid}/reserve-resource/")
                        );                       
                });
    }
}
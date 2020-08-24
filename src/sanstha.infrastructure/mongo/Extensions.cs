using System;
using sanstha.application.events.external;
using sanstha.core.repositories;
using sanstha.infrastructure.exceptions;
using sanstha.infrastructure.mongo.documents;
using sanstha.infrastructure.mongo.repositories;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace sanstha.infrastructure.mongo {
    public static class Extensions {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder){
            builder.Services.AddTransient<IResourceRepository, ResourcesMongoRepository>();
            

            builder
            .AddErrorHandler<ExceptionResponseMapper>()
            .AddQueryHandlers()
            .AddInMemoryQueryDispatcher()
            .AddMongo()
            .AddMongoRepository<ResourceDocument, Guid>("resources")
            .AddRabbitMq();

            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app){
            app
                .UseErrorHandler()
                .UseConvey()
                .UseRabbitMq()
                .SubscribeEvent<SignedUp>();
                

            return app;

        }
        
    }
}
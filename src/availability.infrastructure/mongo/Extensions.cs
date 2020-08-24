using System;
using availability.application.events.external;
using availability.core.repositories;
using availability.infrastructure.exceptions;
using availability.infrastructure.mongo.documents;
using availability.infrastructure.mongo.repositories;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace availability.infrastructure.mongo {
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
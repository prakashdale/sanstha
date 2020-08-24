using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sanstha.application.dto;
using sanstha.application.queries;
using sanstha.infrastructure.mongo.documents;
using Convey.CQRS.Queries;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace sanstha.infrastructure.mongo.queries.handlers {
    internal sealed class GetResourcesHandler : IQueryHandler<GetResources, IEnumerable<ResourceDto>>
    {
        private readonly IMongoDatabase _db;

        public GetResourcesHandler(IMongoDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<ResourceDto>> HandleAsync(GetResources query)
        {
            var collection = _db.GetCollection<ResourceDocument>("resources");
            if (query.Tags is null || !query.Tags.Any()) {
                var allDocuments = await collection.Find( _ => true).ToListAsync();
                return allDocuments.Select(x => x.AsDto());
            }

            var documents = collection.AsQueryable();
            documents = query.MatchAllTags
                ? documents.Where(d => query.Tags.All(t => d.Tags.Contains(t)))
                : documents.Where(d => query.Tags.Any(t => d.Tags.Contains(t)));
            
            var resouces = await documents.ToListAsync();
            return resouces.Select(d => d.AsDto());
        }
    }

}
using sanstha.core.entities;

namespace sanstha.core.events {
    public class ResourceCreated: IDomainEvent{
        public Resource Resource{get;}
        public ResourceCreated(Resource resource) => Resource = resource;
    }
}

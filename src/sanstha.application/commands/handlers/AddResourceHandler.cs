
using System.Threading.Tasks;
using sanstha.application.exceptions;
using sanstha.core.entities;
using sanstha.core.repositories;
using Convey.CQRS.Commands;

namespace sanstha.application.commands.handlers {
    internal sealed class AddResourceHandler : ICommandHandler<AddResource>
    {
        private readonly IResourceRepository _resourceRepository;

        public AddResourceHandler(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        public async Task HandleAsync(AddResource command)
        {
            var resource = await _resourceRepository.GetAsync(command.ResourceId);
            if (resource is {}) {
                throw new ResourceAlreadyExistsException(command.ResourceId);
            }

            resource = Resource.Create(command.ResourceId, command.Tags);
            await _resourceRepository.AddAsync(resource);
        }
    }
}

using System.Threading.Tasks;
using sanstha.application.exceptions;
using sanstha.core.entities;
using sanstha.core.repositories;
using sanstha.core.valueObjects;
using Convey.CQRS.Commands;

namespace sanstha.application.commands.handlers {
    internal sealed class ReserveResourceHandler : ICommandHandler<ReserveResource>
    {
        private readonly IResourceRepository _resourceRepository;

        public ReserveResourceHandler(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        public async Task HandleAsync(ReserveResource command)
        {
            var resource = await _resourceRepository.GetAsync(command.ResourceId);
            if (resource is null) {
                throw new ResourceNotFoundException(command.ResourceId);
            }

            var reservation = new Reservation(command.From, command.To, command.Priority);
            resource.AddReservation(reservation);
            await _resourceRepository.UpdateAsync(resource);
        }
    }
}
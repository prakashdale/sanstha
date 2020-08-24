using System.Threading.Tasks;
using Convey.CQRS.Events;

namespace sanstha.application.events.external.handlers {
    public class SignedUpHandler : IEventHandler<SignedUp>
    {
        public Task HandleAsync(SignedUp @event)
        {
            return Task.CompletedTask;
        }
    }
}
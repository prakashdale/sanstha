using sanstha.core.entities;
using sanstha.core.valueObjects;

namespace sanstha.core.events {
    public class ReservationCancelled: IDomainEvent{
        public Resource Resource{get;}
        public Reservation Reservation{get;}
        public ReservationCancelled(Resource resource, Reservation reservation) => (Resource, Reservation) = (resource, reservation);
    }
}

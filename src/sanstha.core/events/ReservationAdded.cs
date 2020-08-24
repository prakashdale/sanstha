using sanstha.core.entities;
using sanstha.core.valueObjects;

namespace sanstha.core.events {
    public class ReservationAdded: IDomainEvent{
        public Resource Resource{get;}
        public Reservation Reservation{get;}
        public ReservationAdded(Resource resource, Reservation reservation) => (Resource, Reservation) = (resource, reservation);
    }
}

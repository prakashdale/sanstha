using System;
using System.Collections.Generic;

namespace sanstha.application.dto {
    public class ResourceDto {
        public Guid Id{get;set;}
        public IEnumerable<string> Tags {get;set;}
        public IEnumerable<ReservationDto> Reservations{get;set;}
    }
} 
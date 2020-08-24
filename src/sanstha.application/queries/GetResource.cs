using System;
using sanstha.application.dto;
using Convey.CQRS.Queries;

namespace sanstha.application.queries {
    public class GetResource: IQuery<ResourceDto>{
        public Guid ResourceId{get;set;}

    }

}
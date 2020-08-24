using System;
using System.Collections.Generic;
using sanstha.application.dto;
using Convey.CQRS.Queries;

namespace sanstha.application.queries {
    public class GetResources: IQuery<IEnumerable<ResourceDto>>{
        public IEnumerable<string> Tags {get; set;}
        public bool MatchAllTags {get;set;}


    }

}
using System;

namespace sanstha.core.exceptions {
    public class InvalidResourceTagsException : DomainException
    {
        public InvalidResourceTagsException() : base("Missing Resource tag")
        {
        }
    }
}

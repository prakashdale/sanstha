using System;

namespace sanstha.core.exceptions {
    public class MissingResourceTagsException : DomainException
    {
        public MissingResourceTagsException() : base("Missing tag for Resource")
        {
        }
    }
}

using System;

namespace sanstha.application.exceptions {
    public class ResourceNotFoundException : AppException
    {
        public ResourceNotFoundException(Guid id) : base($"Resource with id: '{id}' does not exist")
        {
        }
    }

}
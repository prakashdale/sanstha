using System;

namespace sanstha.core.exceptions {
    public abstract class DomainException: Exception {
        public virtual string Code {get;}
        protected DomainException(string message): base(message) {

        }

    }
}
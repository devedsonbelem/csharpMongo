using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace myMongoProject.Exceptions
{
   public class UpdateFailedException : Exception
    {
        public UpdateFailedException()
        {
        }

        public UpdateFailedException(string message) : base(message)
        {
        }

        public UpdateFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UpdateFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

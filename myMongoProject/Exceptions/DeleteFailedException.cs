using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace myMongoProject.Exceptions
{
    [Serializable]
    public class DeleteFailedException : Exception
    {
        public DeleteFailedException()
        {
        }

        public DeleteFailedException(string message) : base(message)
        {
        }

        public DeleteFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeleteFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

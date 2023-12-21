using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace myMongoProject.Exceptions
{
    [Serializable]
    public class InsertFailedException : Exception
    {
        public InsertFailedException()
        {
        }

        public InsertFailedException(string message) : base(message)
        {
        }

        public InsertFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsertFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

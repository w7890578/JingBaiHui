using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JingBaiHui.Common.Exceptions
{
    public class AssertException : ApplicationException
    {
        public AssertException()
        {
        }

        public AssertException(string message) : base(message)
        {
        }

        public AssertException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
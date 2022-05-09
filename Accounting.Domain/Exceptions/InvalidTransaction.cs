using System;

namespace Accounting.Domain.Exceptions
{
    public class InvalidTransaction : Exception
    {
        public InvalidTransaction()
        {
        }

        public InvalidTransaction(string message)
            : base(message)
        {
        }

        public InvalidTransaction(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
   
}

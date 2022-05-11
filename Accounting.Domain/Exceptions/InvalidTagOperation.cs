using System;

namespace Accounting.Domain.Exceptions
{
    public class InvalidTagOperation : Exception
    {
        public InvalidTagOperation()
        {
        }

        public InvalidTagOperation(string message)
            : base(message)
        {
        }

        public InvalidTagOperation(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
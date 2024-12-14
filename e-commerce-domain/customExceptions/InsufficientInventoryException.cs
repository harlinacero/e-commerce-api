using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_domain.customExceptions
{
    public class InsufficientInventoryException : Exception
    {
        public InsufficientInventoryException() { }

        public InsufficientInventoryException(string message) : base(message) { }

        public InsufficientInventoryException(string message, Exception inner) : base(message, inner) { }
    }
}
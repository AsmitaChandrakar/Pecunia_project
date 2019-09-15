using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.Exceptions
{
    public class PecuniaException : ApplicationException
    {
        public PecuniaException()
            : base()
        {
        }

        public PecuniaException(string message)
            : base(message)
        {
        }
        public PecuniaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NIBO.Challenge.Infra.Exceptions
{
    public class HeaderTransactionException:Exception
    {
        public HeaderTransactionException(string message) : base(message) { }
    }
}

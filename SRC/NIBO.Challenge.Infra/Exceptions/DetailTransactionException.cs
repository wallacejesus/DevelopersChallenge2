using System;
using System.Collections.Generic;
using System.Text;

namespace NIBO.Challenge.Infra.Exceptions
{
    public class DetailTransactionException:Exception
    {
        public DetailTransactionException(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Exceptions
{
    public class ConfirmationTransacctionException :
        Exception
    {
        public ConfirmationTransacctionException(string reason)
            : base("La transacción no puede ser confirmada por que " + reason)
        {
        }
    }
}

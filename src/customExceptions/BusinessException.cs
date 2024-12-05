using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lugares_oficina.src.customExceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }

    }
}
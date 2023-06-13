using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Excepciones
{
    public class DomainException:Exception
    {
        public DomainException() { }
        public DomainException(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Shared
{
    public class Error
    {
        public string Codigo { get; }    
        public string Mensaje { get; }

        public string StackTrace { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Domain.Entities.Cuenta
{
    public class ClienteCuenta
    {
        public int ClienteCuentaId      { get; set; }
        public int CuentaId { get; set; }
        public int ClienteId { get; set; }


    }
}

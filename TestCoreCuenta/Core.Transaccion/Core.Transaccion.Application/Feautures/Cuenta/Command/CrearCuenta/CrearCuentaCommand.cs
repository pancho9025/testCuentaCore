using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Feautures.Cuenta.Command.CrearCuenta
{
    public class CrearCuentaCommand : Core.Transaccion.Domain.Entities.Cuenta.Cuenta, IRequest<Core.Transaccion.Application.Shared.MetaDatosResult<int>>
    {
        public int ClienteId { get; set; }

        public CrearCuentaCommand(int clienteId) 
        { 
         ClienteId= clienteId;  
        }

    }
}

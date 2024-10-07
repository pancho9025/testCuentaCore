using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Feautures.Cuenta.Command.EliminarCuenta
{
    public class EliminarCuentaCommand : Core.Transaccion.Domain.Entities.Cuenta.Cuenta, IRequest<Core.Transaccion.Application.Shared.MetaDatosResult<int>>
    {

    }
}

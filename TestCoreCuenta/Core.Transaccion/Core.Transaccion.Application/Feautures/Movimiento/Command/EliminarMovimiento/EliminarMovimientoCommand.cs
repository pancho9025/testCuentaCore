using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Feautures.Movimiento.Command.EliminarMovimiento
{
    public class EliminarMovimientoCommand : Core.Transaccion.Domain.Entities.Cuenta.Movimiento, IRequest<Core.Transaccion.Application.Shared.MetaDatosResult<int>>
    {

    }
}

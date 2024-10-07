using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Feautures.Cliente.Command.EliminarCliente
{
    public class EliminarClienteCommand : Core.Transaccion.Domain.Entities.Cliente.Cliente, IRequest<Core.Transaccion.Application.Shared.MetaDatosResult<int>>
    {

    }
}

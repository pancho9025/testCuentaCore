using Core.Transaccion.Application.Shared;
using MediatR;

namespace Core.Transaccion.Application.Feautures.Cliente.Command.CrearCliente
{
    public class CrearClienteCommand : Core.Transaccion.Domain.Entities.Cliente.Cliente,  IRequest<MetaDatosResult<int>>
    {

    }
}

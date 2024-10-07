using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Application.Feautures.Cliente.Command.CrearCliente;
using Core.Transaccion.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Feautures.Cliente.Command.EliminarCliente
{
    public class EliminarClienteCommandHandler : IRequestHandler<EliminarClienteCommand, Core.Transaccion.Application.Shared.MetaDatosResult<int>>
    {
        ITransaccionUnitOfWork _unitOfWork;

        public EliminarClienteCommandHandler(ITransaccionUnitOfWork libraryUnitOfWork)
        {
            _unitOfWork = libraryUnitOfWork;
        }

        /// <summary>
        /// Eliminar Cliente
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Core.Transaccion.Application.Shared.MetaDatosResult<int>> Handle(EliminarClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ClienteRepository.EliminarCliente(request);
            if (result >= 0)
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = true, Mensaje = new Mensaje() { Texto = "Cliente eliminado exitosamente" } };
            }
            else
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = false, Mensaje = new Mensaje() { Texto = "Cliente no se pudo eliminar" } };
            }            
        }
    }
}

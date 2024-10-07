using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Feautures.Cliente.Command.CrearCliente
{
    public class CrearClienteCommandHandler : IRequestHandler<CrearClienteCommand, Core.Transaccion.Application.Shared.MetaDatosResult<int>>
    {
        ITransaccionUnitOfWork _unitOfWork;

        public CrearClienteCommandHandler(ITransaccionUnitOfWork libraryUnitOfWork)
        {
            _unitOfWork = libraryUnitOfWork;
        }

        /// <summary>
        /// Crear Cliente
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Core.Transaccion.Application.Shared.MetaDatosResult<int>> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ClienteRepository.AgregarCliente(request);
            if (result >= 0)
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = true, Mensaje = new Mensaje() { Codigo=result.ToString(), Texto = "Cliente creado exitosamente" } };
            }
            else
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = false, Mensaje = new Mensaje() { Texto = "Cliente no se pudo crear" } };
            }
        }
    }
}

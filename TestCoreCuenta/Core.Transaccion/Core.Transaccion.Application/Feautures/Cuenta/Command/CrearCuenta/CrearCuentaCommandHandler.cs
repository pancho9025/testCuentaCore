using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Application.Feautures.Cliente.Command.CrearCliente;
using Core.Transaccion.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Feautures.Cuenta.Command.CrearCuenta
{
    public class CrearCuentaCommandHandler : IRequestHandler<CrearCuentaCommand, Core.Transaccion.Application.Shared.MetaDatosResult<int>>
    {
        ITransaccionUnitOfWork _unitOfWork;

        public CrearCuentaCommandHandler(ITransaccionUnitOfWork libraryUnitOfWork)
        {
            _unitOfWork = libraryUnitOfWork;
        }

        /// <summary>
        /// Crear Cuenta
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Core.Transaccion.Application.Shared.MetaDatosResult<int>> Handle(CrearCuentaCommand request, CancellationToken cancellationToken)
        {            
                var result = await _unitOfWork.CuentaRepository.AgregarCuenta(request, request.ClienteId);
                if (result >= 0)
                {
                    return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = true, Mensaje = new Mensaje() { Codigo = result.ToString(), Texto = "Cuenta creada exitosamente" } };
                }
                else
                {
                    return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = false, Mensaje = new Mensaje() { Texto = "Cuenta no se pudo crear" } };
                }
        }
    }
}

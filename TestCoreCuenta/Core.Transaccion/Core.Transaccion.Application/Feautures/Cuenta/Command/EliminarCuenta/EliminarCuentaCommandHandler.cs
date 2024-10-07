using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Application.Shared;
using MediatR;

namespace Core.Transaccion.Application.Feautures.Cuenta.Command.EliminarCuenta
{
    public class EliminarCuentaCommandHandler : IRequestHandler<EliminarCuentaCommand, Core.Transaccion.Application.Shared.MetaDatosResult<int>>
    {
        ITransaccionUnitOfWork _unitOfWork;

        public EliminarCuentaCommandHandler(ITransaccionUnitOfWork libraryUnitOfWork)
        {
            _unitOfWork = libraryUnitOfWork;
        }

        /// <summary>
        /// Eliminar cuenta
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Core.Transaccion.Application.Shared.MetaDatosResult<int>> Handle(EliminarCuentaCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CuentaRepository.EliminarCuenta(request);
            if (result >= 0)
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = true, Mensaje = new Mensaje() { Texto = "Cuenta eliminada exitosamente" } };
            }
            else
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = false, Mensaje = new Mensaje() { Texto = "Cuenta no se pudo eliminar" } };
            }
        }
    }
}

using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Application.Shared;
using MediatR;

namespace Core.Transaccion.Application.Feautures.Movimiento.Command.ActualizarMovimiento
{
    public class ActualizarMovimientoCommandHandler : IRequestHandler<ActualizarMovimientoCommand, Core.Transaccion.Application.Shared.MetaDatosResult<int>>
    {
        ITransaccionUnitOfWork _unitOfWork;

        public ActualizarMovimientoCommandHandler(ITransaccionUnitOfWork libraryUnitOfWork)
        {
            _unitOfWork = libraryUnitOfWork;
        }

        /// <summary>
        /// Actualizar movimiento
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Core.Transaccion.Application.Shared.MetaDatosResult<int>> Handle(ActualizarMovimientoCommand request, CancellationToken cancellationToken)
        {
            decimal saldoActual = _unitOfWork.MovimientoRepository.ObtenerSaldoCliente(request.ClienteId, request.CuentaId);
            if (request.Valor < 0 && saldoActual < request.Valor * (-1))
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>()
                {
                    Estado = false,
                    Mensaje = new Mensaje() { Texto = "Saldo no disponible" }
                };
            }
            request.Saldo = saldoActual + request.Valor;
            var result = await _unitOfWork.MovimientoRepository.ActualizarMovimiento(request);
            if (result >= 0)
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = true, Mensaje = new Mensaje() { Texto = "Movimiento actualizado exitosamente" } };
            }
            else
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = false, Mensaje = new Mensaje() { Texto = "Movimiento no se pudo actualizar" } };
            }
        }
    }
}

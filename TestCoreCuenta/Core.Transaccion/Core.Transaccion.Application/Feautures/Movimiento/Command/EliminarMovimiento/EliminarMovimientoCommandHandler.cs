using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Application.Shared;
using MediatR;

namespace Core.Transaccion.Application.Feautures.Movimiento.Command.EliminarMovimiento
{
    public class EliminarMovimientoCommandHandler : IRequestHandler<EliminarMovimientoCommand, Core.Transaccion.Application.Shared.MetaDatosResult<int>>
    {
        ITransaccionUnitOfWork _unitOfWork;

        public EliminarMovimientoCommandHandler(ITransaccionUnitOfWork libraryUnitOfWork)
        {
            _unitOfWork = libraryUnitOfWork;
        }

        /// <summary>
        /// Eliminar movimiento
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Core.Transaccion.Application.Shared.MetaDatosResult<int>> Handle(EliminarMovimientoCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MovimientoRepository.EliminarMovimiento(request);
            if (result >= 0)
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = true, Mensaje = new Mensaje() { Texto = "Movimiento eliminado exitosamente" } };
            }
            else
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = false, Mensaje = new Mensaje() { Texto = "Movimiento no se pudo eliminar" } };
            }
        }
    }
}

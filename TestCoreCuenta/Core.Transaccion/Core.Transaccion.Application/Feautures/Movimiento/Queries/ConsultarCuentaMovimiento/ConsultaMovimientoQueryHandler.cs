using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Application.Shared;
using Core.Transaccion.Domain.Entities.Cuenta;
using MediatR;

namespace Core.Transaccion.Application.Feautures.Movimiento.Queries.ConsultarCuentaMovimiento
{
    public class ConsultaMovimientoQueryHandler : IRequestHandler<ConsultaMovimientoQuery, MetaDatosResult<List<CuentaMovimiento>>>
    {
        ITransaccionUnitOfWork _unitOfWork;

        public ConsultaMovimientoQueryHandler(ITransaccionUnitOfWork libraryUnitOfWork)
        {
            _unitOfWork = libraryUnitOfWork;
        }

        /// <summary>
        /// Consultar Movimientos cuenta
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Core.Transaccion.Application.Shared.MetaDatosResult<List<CuentaMovimiento>>> Handle(ConsultaMovimientoQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MovimientoRepository.ConsultarMovimientosPorFecha(request.FechaInicio,request.FechaFin);
            
            if (result!=null && result.Any())
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<List<CuentaMovimiento>> () { Estado = true,Result=result} ;
            }
            else
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<List<CuentaMovimiento>> () { Estado = true, Mensaje = new Mensaje() { Texto = "No hay registros para mostrar" } };
            }
        }
    }
}

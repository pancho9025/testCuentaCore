using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Application.Shared;
using MediatR;

namespace Core.Transaccion.Application.Feautures.Movimiento.Command.CrearMovimiento
{
    internal class CrearMovimientoCommandHandler : IRequestHandler<CrearMovimientoCommand, Core.Transaccion.Application.Shared.MetaDatosResult<int>>
    {
        ITransaccionUnitOfWork _unitOfWork;

        public CrearMovimientoCommandHandler(ITransaccionUnitOfWork libraryUnitOfWork)
        {
            _unitOfWork = libraryUnitOfWork;
        }

        /// <summary>
        /// Crear Movimiento
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Core.Transaccion.Application.Shared.MetaDatosResult<int>> Handle(CrearMovimientoCommand request, CancellationToken cancellationToken)
        {
            decimal saldoActual= _unitOfWork.MovimientoRepository.ObtenerSaldoCliente(request.ClienteId,request.CuentaId);
            if (request.Valor == 0)
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = false, Mensaje = new Mensaje() { Texto = "El Valor es requerido" } };
            }
            if (request.Valor < 0)
                request.TipoMovimiento = "RETIRO";
            else
                request.TipoMovimiento = "DEPOSITO";
            
            if (request.Valor < 0 && saldoActual < request.Valor*(-1))
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>()
                {
                    Estado = false,
                    Mensaje = new Mensaje() { Texto = "Saldo no disponible" }
                };
            }
            request.Saldo=saldoActual+ request.Valor;
            request.Fecha=DateTime.Now;
            var result = await _unitOfWork.MovimientoRepository.AgregarMovimiento(request);
            if (result >= 0)
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = true, Mensaje = new Mensaje() {Codigo = result.ToString(), Texto = "Movimiento creado exitosamente" } };
            }
            else
            {
                return new Core.Transaccion.Application.Shared.MetaDatosResult<int>() { Estado = false, Mensaje = new Mensaje() { Texto = "Movimiento no se pudo crear" } };
            }
        }
    }
}

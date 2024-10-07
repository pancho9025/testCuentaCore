using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Infrastructure.Context;
using Core.Transaccion.Domain.Entities.Cuenta;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Core.Transaccion.Infrastructure.Repositories.Movimiento
{
    public class MovimientoRepository : IMovimientoRepository
    {
        public readonly CoreCuentaContext _context;

        public MovimientoRepository(CoreCuentaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Actualizar movimiento
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<int> ActualizarMovimiento(Core.Transaccion.Domain.Entities.Cuenta.Movimiento movimiento)
        {
            try
            {
                var result = -1;
                var existeMovimiento = await _context.Movimientos.FindAsync(movimiento.MovimientoId);
                if (existeMovimiento != null)
                {
                    existeMovimiento.ClienteId = movimiento.ClienteId;
                    existeMovimiento.CuentaId = movimiento.CuentaId;
                    existeMovimiento.Fecha = movimiento.Fecha;
                    existeMovimiento.TipoMovimiento = movimiento.TipoMovimiento;
                    existeMovimiento.Valor = movimiento.Valor;
                    existeMovimiento.Saldo = movimiento.Saldo;
                    _context.Movimientos.Update(existeMovimiento);
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Agregar movimiento
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<int> AgregarMovimiento(Core.Transaccion.Domain.Entities.Cuenta.Movimiento movimiento)
        {
            try
            {
                await _context.Movimientos.AddAsync(movimiento);
                await _context.SaveChangesAsync();

                return movimiento.MovimientoId;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Eliminar movimiento
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<int> EliminarMovimiento(Core.Transaccion.Domain.Entities.Cuenta.Movimiento movimiento)
        {
            try
            {
                var result = -1;
                var existeMovimiento = await _context.Movimientos.FindAsync(movimiento.MovimientoId);
                if (existeMovimiento != null)
                {
                    _context.Movimientos.Remove(existeMovimiento);
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            catch
            {
                return -1;
            }
        }


        /// <summary>
        /// Consultar movimientos por rangos de fecha
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public async Task<List<Domain.Entities.Cuenta.CuentaMovimiento>> ConsultarMovimientosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var fechaInicioIn = new SqlParameter("@fechaInicio", fechaInicio);
                var fechaFinIn = new SqlParameter("@fechaFin", fechaFin);
                var movimientos = await _context.Set<Domain.Entities.Cuenta.CuentaMovimiento>()
                    .FromSqlRaw("EXEC [cu].[sp_consultar_cuenta_movimiento] @fechaInicio, @fechaFin", fechaInicioIn, fechaFinIn)
                    .ToListAsync();

                return movimientos;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Obtener saldo cliente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <param name="cuentaId"></param>
        /// <returns></returns>
        public decimal ObtenerSaldoCliente(int clienteId, int cuentaId)
        {
            decimal saldo = 0;
                var movimiento =  _context.Movimientos.Where(m => m.ClienteId == clienteId && m.CuentaId == cuentaId).OrderByDescending(m => m.Fecha)?.FirstOrDefault();
            if (movimiento != null)
            {
                saldo = movimiento.Saldo;
            }
            else
            {
                saldo = _context.Cuentas.First(x => x.CuentaId == cuentaId).SaldoInicial;
            }
            return saldo;
        }
    }
}

using Core.Transaccion.Domain.Entities.Cliente;
using Core.Transaccion.Domain.Entities.Cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Contracts.Persintence
{
    public interface IMovimientoRepository
    {
        Task<int> AgregarMovimiento(Movimiento cliente);

        Task<int> ActualizarMovimiento(Movimiento cliente);

        Task<int> EliminarMovimiento(Movimiento cliente);

        decimal ObtenerSaldoCliente(int clienteId,int cuentaId);

        Task<List<CuentaMovimiento>> ConsultarMovimientosPorFecha(DateTime fechaInicio,DateTime fechaFin);
    }
}

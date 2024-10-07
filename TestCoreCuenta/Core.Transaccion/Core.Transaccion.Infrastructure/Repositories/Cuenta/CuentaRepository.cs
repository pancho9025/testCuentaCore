using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Domain.Entities.Cliente;
using Core.Transaccion.Domain.Entities.Cuenta;
using Core.Transaccion.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Infrastructure.Repositories.Cuenta
{
    public class CuentaRepository : ICuentaRepository
    {
        public readonly CoreCuentaContext _context;

        public CuentaRepository(CoreCuentaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Actualizar cuenta
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns></returns>
        public async Task<int> ActualizarCuenta(Domain.Entities.Cuenta.Cuenta cuenta)
        {
            try
            {
                var result = -1;
                var existeCuenta = await _context.Cuentas.FindAsync(cuenta.CuentaId);
                if (existeCuenta != null)
                {
                    existeCuenta.NumeroCuenta = cuenta.NumeroCuenta;
                    existeCuenta.TipoCuenta = cuenta.TipoCuenta;
                    existeCuenta.SaldoInicial = cuenta.SaldoInicial;
                    existeCuenta.Estado = cuenta.Estado;
                    _context.Cuentas.Update(existeCuenta);
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
        /// Agregar Cuenta
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns></returns>
        public async Task<int> AgregarCuenta(Domain.Entities.Cuenta.Cuenta cuenta, int clienteId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Cuentas.AddAsync(cuenta);
                await _context.SaveChangesAsync();
                ClienteCuenta clienteCuenta = new ClienteCuenta() { ClienteId = clienteId, CuentaId = cuenta.CuentaId };
                await _context.Set<ClienteCuenta>().AddAsync(clienteCuenta);
                await _context.SaveChangesAsync();
                transaction.CommitAsync();
                return cuenta.CuentaId;
            }
            catch
            {
                transaction.RollbackAsync();
                return -1;
            }
        }

        /// <summary>
        /// Eliminar Cuenta
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns></returns>
        public async Task<int> EliminarCuenta(Domain.Entities.Cuenta.Cuenta cuenta)
        {
            try
            {
                var result = -1;
                var existeCuenta = await _context.Cuentas.FindAsync(cuenta.CuentaId);
                if (existeCuenta != null)
                {
                    var existeClientesCuenta =  _context.Set<ClienteCuenta>().Where(cu=>cu.CuentaId==cuenta.CuentaId);
                    foreach (var clienteCuenta in existeClientesCuenta) 
                    {
                        _context.Set<ClienteCuenta>().Remove(clienteCuenta);
                    }
                    _context.Cuentas.Remove(existeCuenta);
                     result = await _context.SaveChangesAsync();
                }
                return result;
            }
            catch
            {
                return -1;
            }
        }

    }
}

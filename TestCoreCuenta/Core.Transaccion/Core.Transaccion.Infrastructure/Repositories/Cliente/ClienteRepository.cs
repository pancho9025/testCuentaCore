using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Domain.Entities.Cliente;
using Core.Transaccion.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Infrastructure.Repositories.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly CoreCuentaContext _context;

        public ClienteRepository(CoreCuentaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Actulizar cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<int> ActualizarCliente(Domain.Entities.Cliente.Cliente cliente)
        {
            var result = -1;

            var existeCliente = await _context.Clientes
                .FirstOrDefaultAsync(cl => cl.ClienteId == cliente.ClienteId);

            if (existeCliente != null)
            {
                existeCliente.Nombre = cliente.Nombre;
                existeCliente.Genero = cliente.Genero;
                existeCliente.Edad = cliente.Edad;
                existeCliente.Identificacion = cliente.Identificacion;
                existeCliente.Direccion = cliente.Direccion;
                existeCliente.Telefono = cliente.Telefono;
                existeCliente.Clave = cliente.Clave;
                existeCliente.Estado = cliente.Estado;
                result = await _context.SaveChangesAsync();
            }

            return result;
        }

        /// <summary>
        /// Agergar cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<int> AgregarCliente(Domain.Entities.Cliente.Cliente cliente)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            transaction.CommitAsync();
                return cliente.ClienteId;
            }
            catch{
            transaction.RollbackAsync();
                throw;
            }
        }
        

        /// <summary>
        /// Eliminar un cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<int> EliminarCliente(Domain.Entities.Cliente.Cliente cliente)
        {
            var result = -1;
            var existeCliente = await _context.Clientes
               .FirstOrDefaultAsync(cl => cl.ClienteId == cliente.ClienteId);
            if (existeCliente != null)
            {
                _context.Clientes.Remove(existeCliente);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

    }
}

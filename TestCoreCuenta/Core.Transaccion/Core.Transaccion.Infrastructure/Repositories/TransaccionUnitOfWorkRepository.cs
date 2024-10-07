using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Infrastructure.Context;
using Core.Transaccion.Infrastructure.Repositories.Cliente;
using Core.Transaccion.Infrastructure.Repositories.Cuenta;
using Core.Transaccion.Infrastructure.Repositories.Movimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Infrastructure.Repositories
{
    public class TransaccionUnitOfWorkRepository : ITransaccionUnitOfWork
    {
        private CoreCuentaContext _context { get; set; }

        public TransaccionUnitOfWorkRepository(CoreCuentaContext context)
        {
            _context = context;
        }

        private IClienteRepository _clienteRepository { get; set; }

        public IClienteRepository ClienteRepository => _clienteRepository ??= new ClienteRepository(_context);

        private ICuentaRepository _cuentaRepository { get; set; }

        public ICuentaRepository CuentaRepository => _cuentaRepository ??= new CuentaRepository(_context);

        private IMovimientoRepository _movimientoRepository { get; set; }

        public IMovimientoRepository MovimientoRepository => _movimientoRepository ??= new MovimientoRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

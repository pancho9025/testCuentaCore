using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Contracts.Persintence
{
    public interface ITransaccionUnitOfWork : IDisposable
    {
        IClienteRepository    ClienteRepository { get; }   
        ICuentaRepository     CuentaRepository   { get; }
        IMovimientoRepository MovimientoRepository { get; }
    }
}

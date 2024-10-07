using Core.Transaccion.Domain.Entities.Cliente;
using Core.Transaccion.Domain.Entities.Cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Contracts.Persintence
{
    public interface ICuentaRepository
    {
        Task<int> AgregarCuenta(Cuenta cuenta, int clienteId);

        Task<int> ActualizarCuenta(Cuenta cuenta);

        Task<int> EliminarCuenta(Cuenta cuenta);
    }
}

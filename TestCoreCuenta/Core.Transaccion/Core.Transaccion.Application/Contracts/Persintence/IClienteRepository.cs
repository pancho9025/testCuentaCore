using Core.Transaccion.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Contracts.Persintence
{
    public interface IClienteRepository
    {
        
        Task<int> AgregarCliente(Cliente cliente);

        Task<int> ActualizarCliente(Cliente cliente);

        Task<int> EliminarCliente(Cliente cliente);
    }
}

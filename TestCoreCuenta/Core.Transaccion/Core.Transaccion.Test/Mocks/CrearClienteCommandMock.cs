using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Application.Feautures.Cliente.Command.CrearCliente;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Test.Mocks
{
    public class CrearClienteCommandMock
    {
        public Mock<ITransaccionUnitOfWork> UnitOfWorkMock()
        {
            var mockUnitOfWork = new Mock<ITransaccionUnitOfWork>();
            mockUnitOfWork.Setup(cr => cr.ClienteRepository.AgregarCliente(It.IsAny<CrearClienteCommand>()))
                .ReturnsAsync(1);

            return mockUnitOfWork;
        }
    }
}

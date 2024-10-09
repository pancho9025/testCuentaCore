using Core.Transaccion.Application.Feautures.Cliente.Command.CrearCliente;
using Core.Transaccion.Test.Mocks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Test.Tests
{
    [TestClass]
    public class CrearClienteCommandHandlerTest
    {
        private readonly CrearClienteCommandMock _crearClienteCommandMock;
        public CrearClienteCommandHandlerTest()
        {
            _crearClienteCommandMock = new CrearClienteCommandMock();
        }

        [TestMethod]
        public async Task CrearClienteCommandHandler_Success()
        {
            var crearClienteCommandMock = _crearClienteCommandMock.UnitOfWorkMock();
            var crearClienteCommandHandler = new CrearClienteCommandHandler(crearClienteCommandMock.Object);
            var crearClienteCommand = new CrearClienteCommand {
                                      Clave="admin12345",
                                      Estado=true,
                                      Nombre="Nataly Loor",
                                      Genero="F",
                                      Edad=30,
                                      Identificacion="1324565544",
                                      Direccion="Los electricos",
                                      Telefono="0978765654"
            };
            var result = await crearClienteCommandHandler.Handle(crearClienteCommand, CancellationToken.None);

            Assert.IsNotNull(result);
            result.Estado.Should().BeTrue();
            result.Mensaje.Texto.Should().Be("Cliente creado exitosamente");
            crearClienteCommandMock.Verify(uow => uow.ClienteRepository.AgregarCliente(It.IsAny<CrearClienteCommand>()), Times.Once);
        }

    }
}

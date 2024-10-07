using Core.Transaccion.Application.Feautures.Cliente.Command.ActualizarCliente;
using Core.Transaccion.Application.Feautures.Cliente.Command.CrearCliente;
using Core.Transaccion.Application.Feautures.Cliente.Command.EliminarCliente;
using Core.Transaccion.PersonaCliente.Rest.Model.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.Transaccion.PersonaCliente.Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("clientes")]
        public async Task<IActionResult> CrearCliente([FromBody] ClienteRequest cliente)
        {
            var crearClienteCommand = new CrearClienteCommand
            {
                Nombre = cliente.Nombre,
                Genero = cliente.Genero,
                Edad = cliente.Edad,
                Identificacion = cliente.Identificacion,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Estado = true,
                Clave = cliente.Clave
            };


            var result = await _mediator.Send(crearClienteCommand);
            if (result.Estado)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result); // Devolver mensajes de error
            }
        }

        [HttpPut]
        [Route("clientes")]
        public async Task<IActionResult>ActualizarCliente([FromBody] ClienteRequest cliente)
        {
            var actualizarClienteCommand = new ActualizarClienteCommand
            {
                ClienteId=cliente.ClienteId,
                Nombre = cliente.Nombre,
                Genero = cliente.Genero,
                Edad = cliente.Edad,
                Identificacion = cliente.Identificacion,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Estado = true,
                Clave = cliente.Clave
            };


            var result = await _mediator.Send(actualizarClienteCommand);
            if (result.Estado)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route("clientes")]
        public async Task<IActionResult>EliminarCliente([FromBody] ClienteRequest cliente)
        {
            var eliminarClienteCommand = new EliminarClienteCommand
            {
                ClienteId = cliente.ClienteId                
            };
            var result = await _mediator.Send(eliminarClienteCommand);
            if (result.Estado)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result); 
            }
        }       
    }
}

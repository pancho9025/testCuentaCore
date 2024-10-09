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
        private readonly HttpClient _httpClient;

        public ClienteController(IMediator mediator, HttpClient httpClient)
        {
            _mediator = mediator;
            _httpClient= httpClient;
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
                //var cuentaRequest = new
                //{
                //    ClienteId = Convert.ToInt32(result.Mensaje.Codigo),
                //    NumeroCuenta = 345678987,
                //    TipoCuenta = "Ahorros",
                //    SaldoInicial = 200,
                //    Estado = true
                //};

                //var cuentaJson = JsonConvert.SerializeObject(cuentaRequest);
                //var content = new StringContent(cuentaJson, Encoding.UTF8, "application/json");
                //var response = await _httpClient.PostAsync("https://localhost:7005/cuenta/cuentas", content);
                //if (response.IsSuccessStatusCode)
                //{
                //    return Ok(result);
                //}
                //else
                //{
                //    // Manejo de errores al crear la cuenta
                //    return BadRequest("Cliente creado, pero no se pudo crear la cuenta.");
                //}
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

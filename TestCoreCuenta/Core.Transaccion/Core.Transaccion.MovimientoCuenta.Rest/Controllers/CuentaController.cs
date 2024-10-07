using Core.Transaccion.Application.Feautures.Cliente.Command.EliminarCliente;
using Core.Transaccion.Application.Feautures.Cuenta.Command.ActualizarCuenta;
using Core.Transaccion.Application.Feautures.Cuenta.Command.CrearCuenta;
using Core.Transaccion.Application.Feautures.Cuenta.Command.EliminarCuenta;
using Core.Transaccion.Domain.Entities.Cliente;
using Core.Transaccion.MovimientoCuenta.Rest.Model.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.Transaccion.MovimientoCuenta.Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CuentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("cuentas")]
        public async Task< IActionResult >CrearCuenta([FromBody] CuentaRequest cuenta)
        {
            var crearCuentaCommand = new CrearCuentaCommand(clienteId:cuenta.ClienteId)
            {
                NumeroCuenta = cuenta.NumeroCuenta,
                TipoCuenta = cuenta.TipoCuenta,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = true
            };


            var result = await _mediator.Send(crearCuentaCommand);
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
        [Route("cuentas")]
        public async Task <IActionResult> ActualizarCuenta([FromBody] CuentaRequest cuenta)
        {
            var actualizarCuentaCommand = new ActualizarCuentaCommand
            {
                CuentaId= cuenta.CuentaId,
                NumeroCuenta = cuenta.NumeroCuenta,
                TipoCuenta = cuenta.TipoCuenta,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = true
            };
            var result = await _mediator.Send(actualizarCuentaCommand);
            if (result.Estado)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result); // Devolver mensajes de error
            }
        }

        [HttpDelete]
        [Route("cuentas")]
        public async Task <IActionResult> EliminarCuenta([FromBody] CuentaRequest cuenta)
        {
            var eliminarCuentaCommand = new EliminarCuentaCommand
            {
                CuentaId = cuenta.CuentaId
            };
            var result = await _mediator.Send(eliminarCuentaCommand);
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

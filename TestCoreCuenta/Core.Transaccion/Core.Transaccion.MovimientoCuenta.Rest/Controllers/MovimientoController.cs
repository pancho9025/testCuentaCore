using Core.Transaccion.Application.Feautures.Movimiento.Command.ActualizarMovimiento;
using Core.Transaccion.Application.Feautures.Movimiento.Command.CrearMovimiento;
using Core.Transaccion.Application.Feautures.Movimiento.Command.EliminarMovimiento;
using Core.Transaccion.Application.Feautures.Movimiento.Queries.ConsultarCuentaMovimiento;
using Core.Transaccion.MovimientoCuenta.Rest.Model.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Core.Transaccion.MovimientoMovimiento.Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimientoController(IMediator mediator)
        {
            _mediator = mediator;
        }

      
        [HttpPost]
        [Route("movimientos")]
        public async Task<IActionResult> CrearMovimiento([FromBody] MovimientoRequest movimiento)
        {
            var crearMovimientoCommand = new CrearMovimientoCommand
            {
                ClienteId = movimiento.ClienteId,
                CuentaId = movimiento.CuentaId,
                Fecha = movimiento.Fecha,
                TipoMovimiento = movimiento.TipoMovimiento,
                Valor= movimiento.Valor,
                Saldo = movimiento.Saldo
            };
            var result = await _mediator.Send(crearMovimientoCommand);
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
        [Route("movimientos")]
        public async Task<IActionResult >ActualizarMovimiento([FromBody] MovimientoRequest movimiento)
        {
            var actualizarMovimientoCommand = new ActualizarMovimientoCommand
            {
                MovimientoId= movimiento.MovimientoId,   
                ClienteId = movimiento.ClienteId,
                CuentaId = movimiento.CuentaId,
                Fecha = movimiento.Fecha,
                TipoMovimiento = movimiento.TipoMovimiento,
                Valor = movimiento.Valor,
                Saldo = movimiento.Saldo
            };
            var result = await _mediator.Send(actualizarMovimientoCommand);
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
        [Route("movimientos")]
        public async Task<IActionResult> EliminarMovimiento([FromBody] MovimientoRequest movimiento)
        {
            var eliminarMovimientoCommand = new EliminarMovimientoCommand
            {
                MovimientoId = movimiento.MovimientoId
            };
            var result = await _mediator.Send(eliminarMovimientoCommand);
            if (result.Estado)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("reportes")]
        public  async Task<IActionResult> ConsultarMovimientos([FromQuery] string fechaInicio, string fechaFin)
        {
            var consultaMovimientosQuery = new ConsultaMovimientoQuery(Convert.ToDateTime(fechaInicio),Convert.ToDateTime(fechaFin)){ };
            
            var result = await _mediator.Send(consultaMovimientosQuery);
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

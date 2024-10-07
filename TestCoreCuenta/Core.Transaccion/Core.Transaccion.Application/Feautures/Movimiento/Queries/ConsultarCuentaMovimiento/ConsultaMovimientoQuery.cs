using Core.Transaccion.Application.Shared;
using Core.Transaccion.Domain.Entities.Cuenta;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Feautures.Movimiento.Queries.ConsultarCuentaMovimiento
{
    public class ConsultaMovimientoQuery : IRequest<MetaDatosResult<List<CuentaMovimiento>>>
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public ConsultaMovimientoQuery(DateTime fechaInicio, DateTime fechaFin)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;    
        }

    }
}

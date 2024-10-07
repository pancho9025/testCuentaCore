using Core.Transaccion.Domain.Entities.Cuenta;

namespace Core.Transaccion.MovimientoCuenta.Rest.Model.Request
{
    public class CuentaRequest
    {
        public int CuentaId { get; set; }
        public int NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int ClienteId { get; set; }
    }
}

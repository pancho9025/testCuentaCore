namespace Core.Transaccion.MovimientoCuenta.Rest.Model.Request
{
    public class MovimientoRequest
    {
        public int MovimientoId { get; set; }
        public int ClienteId { get; set; }
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
    }
}

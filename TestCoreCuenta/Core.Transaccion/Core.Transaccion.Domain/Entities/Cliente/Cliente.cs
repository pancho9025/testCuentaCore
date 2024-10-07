using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Domain.Entities.Cliente
{
    public class Cliente : Persona
    {        
        public int ClienteId { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }
    }
}

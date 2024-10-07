using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Shared
{
    [DataContract]
    public class Mensaje
    {
        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Texto { get; set; }

        public static Mensaje Create(Error error)
        {
            return new Mensaje
            {
                Codigo = error.Codigo,
                Texto = error.Mensaje
            };
        }
    }
}

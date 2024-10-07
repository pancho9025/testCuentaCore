using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transaccion.Application.Shared
{
    [DataContract]
    public class MetaDatosResult <T>
    {
        [DataMember]
        public bool Estado { get; set; }

        [DataMember]
        public Mensaje Mensaje { get; set; }

        [DataMember]
        public T Result { get; set; }
    }
}

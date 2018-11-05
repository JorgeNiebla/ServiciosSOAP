using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
	[DataContract]
	public class PedidoModelInput
    {
        [DataMember]
        public List<Producto> Productos { get; set; }
    }

    [DataContract]
    public class Producto
    {
        [DataMember]
        public string NombreProducto { get; set; }

        [DataMember]
        public decimal PrecioUnitario { get; set; }

        [DataMember]
        public int Cantidad { get; set; }
    }
}

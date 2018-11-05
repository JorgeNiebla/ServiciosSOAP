using Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SOAPWebServices
{
	public class Services : IServices
	{
        const int Iva = 16;

        public string EnviarMensaje(string mensaje)
		{
			return mensaje;
		}

		public PedidoModelResponse CalcularPedido(PedidoModelInput pedido)
		{
            var subtotal = pedido.Productos.Sum(p => p.Cantidad * p.PrecioUnitario);
            var impuestos = subtotal * Iva / 100;

            return new PedidoModelResponse
			{
				Impuestos = impuestos,
                SubTotal = subtotal,
                Total = subtotal + impuestos
			};
		}
	}
}

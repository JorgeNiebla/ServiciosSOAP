using Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Client
{
	public class Program
	{
		public static void Main(string[] args)
		{
            var transportBinding = new HttpTransportBindingElement();
            var textEncodingBinding = new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, System.Text.Encoding.UTF8);
            var binding = new CustomBinding(textEncodingBinding, transportBinding);

            var endpoint = new EndpointAddress(new Uri(string.Format("http://{0}:5000/Services.svc", Environment.MachineName)));
			var channelFactory = new ChannelFactory<IServices>(binding, endpoint);
			var serviceClient = channelFactory.CreateChannel();
			var result = serviceClient.EnviarMensaje("hey");
			Console.WriteLine("Ping method result: {0}", result);

			var input = new PedidoModelInput
			{
				Productos = new List<Producto>()
                {
                    {new Producto(){ NombreProducto = "Coca Cola", Cantidad = 10, PrecioUnitario = 12.7m } },
                    {new Producto(){ NombreProducto = "Pepsi", Cantidad = 5, PrecioUnitario = 12 } }
                }
			};

            var resultado = serviceClient.CalcularPedido(input);

            Console.WriteLine($"Calculo del pedido, Subtotal: {resultado.SubTotal}, Impuestos: {resultado.Impuestos}, Total: {resultado.Total}");

			Console.ReadKey();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Webservices.nbgz.me;

namespace ClienteWSDL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var transportBinding = new HttpTransportBindingElement();
            var textEncodingBinding = new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, System.Text.Encoding.UTF8);
            var binding = new CustomBinding(textEncodingBinding, transportBinding);
            var endpoint = new EndpointAddress(new Uri("http://webservices.nbgz.me/Services.svc"));

            var x = new ServicesClient(binding, endpoint);

            var request = new CalcularPedidoRequest()
            {
                Body = new CalcularPedidoRequestBody()
                {
                    inputModel = new PedidoModelInput
                    {
                        Productos = new List<Producto>()
                        {
                            {new Producto(){ NombreProducto = "Coca Cola", Cantidad = 10, PrecioUnitario = 12.7m } },
                            {new Producto(){ NombreProducto = "Pepsi", Cantidad = 5, PrecioUnitario = 12 } }
                        }.ToArray()
                    }
                }
            };
            var channelFactory = new ChannelFactory<IServices>(binding, endpoint);
            var serviceClient = channelFactory.CreateChannel();

            var result = serviceClient.CalcularPedidoAsync(request).Result;
        }
    }
}

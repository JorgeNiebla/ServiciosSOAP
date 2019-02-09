using CalculadoraWS;
using System;
using System.ServiceModel;

namespace ClienteWSDL
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap12);

            var result = client.AddAsync(2, 7).Result;
        }
    }
}

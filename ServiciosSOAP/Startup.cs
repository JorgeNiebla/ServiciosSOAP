using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Models;
using SoapCore;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SOAPWebServices
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.TryAddSingleton<IServices, Services>();
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole();
			loggerFactory.AddDebug();

            var transportBinding = new HttpTransportBindingElement();
            var textEncodingBinding = new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, System.Text.Encoding.UTF8);
            var binding = new CustomBinding(transportBinding, textEncodingBinding);

            app.UseSoapEndpoint<IServices>("/Services.svc", binding, SoapSerializer.DataContractSerializer);
			app.UseSoapEndpoint<IServices>("/Services.asmx", binding, SoapSerializer.XmlSerializer);

			app.UseMvc();
		}
	}
}

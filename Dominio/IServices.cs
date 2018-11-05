using System.ServiceModel;
using System.Threading.Tasks;

namespace Models
{
	[ServiceContract]
	public interface IServices
	{
		[OperationContract]
		string EnviarMensaje(string mensaje);

		[OperationContract]
		PedidoModelResponse CalcularPedido(PedidoModelInput inputModel);
	}
}

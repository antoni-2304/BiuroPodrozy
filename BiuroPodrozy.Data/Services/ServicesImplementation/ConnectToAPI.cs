using BiuroPodrozy.Data.Services.IServices;

namespace BiuroPodrozy.Data.Services.ServicesImplementation
{
	public class ConnectToAPI : IConnectToAPI
	{
		public ReferenceAPI Connect()
		{
			var httpHandler = new HttpClientHandler();
#if DEBUG
			httpHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
			httpHandler.ServerCertificateCustomValidationCallback =
			(httpRequestMessage, cert, cetChain, policyErrors) => true;
#endif
			var httpclient = new HttpClient(httpHandler);
			return new ReferenceAPI("https://localhost:7232", httpclient);

		}

	}
}

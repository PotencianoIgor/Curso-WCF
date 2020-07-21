using SysMecanica;
using System;
using System.ServiceModel;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ProdutoService));
            Uri uri = new Uri("http://localhost:8080/produtos");
            host.AddServiceEndpoint(typeof(IProdutoService), new BasicHttpBinding(), uri);
            try
            {
                host.Open();
                DetalharInformacoes(host);
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                host.Abort();
                Console.WriteLine(ex.Message);

                Console.ReadLine();
            }
        }

        public static void DetalharInformacoes(ServiceHost serviceHost)
        {
            try
            {
                Console.WriteLine("{0} Serviço Online", serviceHost.Description.ServiceType);

                foreach (var item in serviceHost.Description.Endpoints)
                {
                    Console.WriteLine(item.Address);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System.ServiceModel;
using System.ServiceModel.Web;

namespace SysMecanica
{
    [ServiceContract]
    public interface IProdutoService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Add?json={json}")]
        bool Add(string json);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Buscar?codigo={codigo}")]
        Produto Buscar(string codigo);
    }
}

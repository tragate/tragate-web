using Microsoft.AspNetCore.Http;

namespace Tragate.UI.BuildingBlocks.ApiClient
{
    public interface IRestClient
    {
        T Get<T>(string uri);

        T Post<T>(string uri, object item);

        T PostMultipartContent<T>(string uri, IFormFile file);

        T Put<T>(string uri, object item);

        T Delete<T>(string uri);
        
        T Patch<T>(string uri, object item);
        T Patch<T>(string uri);
    }
}
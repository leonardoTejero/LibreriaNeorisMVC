using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Utils.RestServices.Interface
{
    public interface IRestService
    {
        Task<T> PostRestServiceAsync<T>(string url, string controller,
          string method, object parameters, IDictionary<string, string> headers);

        Task<T> GetRestServiceAsync<T>(string url, string controller, string method,
            IDictionary<string, string> parameters, IDictionary<string, string> headers);

        Task<T> PutRestServiceAsync<T>(string url, string controller,
         string method, object parameters, IDictionary<string, string> headers);

        Task<T> DeleteRestServiceAsync<T>(string url, string controller, string method,
            IDictionary<string, int> parameters, IDictionary<string, string> headers);
        //Task<T> DeleteRestServiceAsync<T>(string urlBase, string controller, string method,
        //    Dictionary<string, int> parameters, Dictionary<string, string> headers);
    }
}

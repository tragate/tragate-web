using Tragate.UI.Models.Response.Parameter;

namespace Tragate.UI.Services
{
    public interface IParameterService {
        ParameterResponse GetParametersByTypeId (string type, int statusId);
    }
}
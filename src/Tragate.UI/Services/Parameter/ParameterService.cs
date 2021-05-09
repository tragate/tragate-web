using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Response.Parameter;

namespace Tragate.UI.Services {
    public class ParameterService : IParameterService {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public ParameterService (IRestClient restClient,
            IOptionsSnapshot<ConfigSettings> settings) {
            _restClient = restClient;
            _settings = settings.Value;
        }

        public ParameterResponse GetParametersByTypeId (string type, int statusId) {
            return _restClient.Get<ParameterResponse> (string.Format ($"{_settings.ApiUrl}/{API.Parameter.GetParameters}", type, statusId));
        }
    }
}
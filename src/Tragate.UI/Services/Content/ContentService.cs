using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Response.Content;

namespace Tragate.UI.Services
{
    public class ContentService : IContentService {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public ContentService (IRestClient restClient,
            IOptionsSnapshot<ConfigSettings> settings) {
            _restClient = restClient;
            _settings = settings.Value;
        }

        public ContentResponse GetContentBySlug (string slug, int statusId) {
            return _restClient.Get<ContentResponse> (string.Format ($"{_settings.ApiUrl}/{API.Content.GetContentBySlug}", slug, statusId));
        }
    }
}
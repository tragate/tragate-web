using System.Text;
using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Common.Enums;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Response.Location;

namespace Tragate.UI.Services {
    public class LocationService : ILocationService {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public LocationService (IRestClient restClient,
            IOptionsSnapshot<ConfigSettings> settings) {
            _restClient = restClient;
            _settings = settings.Value;
        }

        public LocationResponse GetLocationByParentId (int? parentId, int statusId) {
            StringBuilder sb = new StringBuilder ();
            sb.Append ("?statusId=").Append ((int) StatusType.Active);
            if (parentId.HasValue)
                sb.Append ("&parentId=").Append (parentId);

            return _restClient.Get<LocationResponse> (string.Format ($"{_settings.ApiUrl}/{API.Location.GetLocations}", sb.ToString ()));
        }
    }
}
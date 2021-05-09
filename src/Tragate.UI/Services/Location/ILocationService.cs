using Tragate.UI.Models.Response.Location;

namespace Tragate.UI.Services
{
    public interface ILocationService {
        LocationResponse GetLocationByParentId (int? parentId, int statusId);
    }
}
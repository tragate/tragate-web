using Tragate.UI.Models.Response.Content;

namespace Tragate.UI.Services {
    public interface IContentService {
        ContentResponse GetContentBySlug (string slug, int statusId);
    }
}
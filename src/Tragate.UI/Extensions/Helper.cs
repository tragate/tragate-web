using Ganss.XSS;

namespace Tragate.UI.Extensions
{
    public static class Helper
    {
        public static string GetHtmlSanitizedText(this string value){
            if (!string.IsNullOrEmpty(value)){
                var sanitizer = new HtmlSanitizer();
                sanitizer.AllowedTags.Add("iframe");
                sanitizer.AllowedAttributes.Add("frameborder");
                sanitizer.AllowedAttributes.Add("allow");
                sanitizer.AllowedAttributes.Add("accelerometer");
                sanitizer.AllowedAttributes.Add("autoplay");
                sanitizer.AllowedAttributes.Add("encrypted-media");
                sanitizer.AllowedAttributes.Add("gyroscope");
                sanitizer.AllowedAttributes.Add("gyroscope");
                sanitizer.AllowedAttributes.Add("picture-in-picture");
                sanitizer.AllowedAttributes.Add("allowfullscreen");
                var sanitized = sanitizer.Sanitize(value);

                return sanitized;
            }

            return null;
        }
    }
}
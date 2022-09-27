using Abp.Extensions;

namespace Framework.Authentication
{
    public class MicrosoftExternalLoginProviderSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public bool IsValid()
        {
            return !ClientId.IsNullOrWhiteSpace() && !ClientSecret.IsNullOrWhiteSpace();
        }
    }
}

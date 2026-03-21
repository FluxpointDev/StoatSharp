using Newtonsoft.Json;

namespace StoatSharp;
public class OnboardStatus
{
    [JsonProperty("onboarding")]
    public bool IsOnboardingRequired { get; set; }
}

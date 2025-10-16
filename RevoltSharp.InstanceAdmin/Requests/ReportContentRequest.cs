using Optionals;
using StoatSharp.Rest;

namespace StoatSharp.Requests;
internal class ReportContentRequest : IStoatRequest
{
    public SafetyReportedContentJson content { get; set; } = null!;
    public Optional<string> additional_context { get; set; }
}

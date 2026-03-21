using Optionals;
using StoatSharp.Rest;
using System;

namespace StoatSharp.Requests;
internal class AdminReportModifyRequest : IStoatRequest
{
    public AdminReportModifyStatusRequest? status;

    public Optional<string> notes;
}
internal class AdminReportModifyStatusRequest
{
    public string? status;
    public Optional<string> rejection_reason;
    public Optional<DateTime> closed_at;
}
namespace StoatSharp;
internal class AdminConditions
{
    internal static void CheckIsPrivileged(StoatClient client, string request)
    {
        if (!client.CurrentUser.IsPrivileged)
            throw new StoatRestException($"The current user/bot account is not privileged to use the admin endpoints for the {request} request.", 400, StoatErrorType.NotPrivileged);
    }

    internal static void ReportIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id))
            throw new StoatArgumentException($"Report id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Report id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    internal static void ReportReasonLength(string reason, string request)
    {
        if (string.IsNullOrEmpty(reason))
            throw new StoatArgumentException($"Report reason can't be empty for the {request} request.");

    }

    internal static void StrikeIdLength(string id, string request)
    {
        if (string.IsNullOrEmpty(id))
            throw new StoatArgumentException($"Strike id can't be empty for the {request} request.");

        if (id.Length > Const.All_MaxIdLength)
            throw new StoatArgumentException($"Strike id length can't be more than {Const.All_MaxIdLength} characters for the {request} request.");
    }

    internal static void StrikeReasonLength(string reason, string request)
    {
        if (string.IsNullOrEmpty(reason))
            throw new StoatArgumentException($"Strike reason can't be empty for the {request} request.");

    }
}

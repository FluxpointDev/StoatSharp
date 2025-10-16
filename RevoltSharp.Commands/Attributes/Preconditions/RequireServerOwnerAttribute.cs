using System;
using System.Threading.Tasks;

namespace StoatSharp.Commands;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class RequireServerOwnerAttribute : PreconditionAttribute
{
    /// <inheritdoc />
    public override Task<PreconditionResult> CheckPermissionsAsync(CommandContext context, CommandInfo command, IServiceProvider services)
    {
        if (context.Server == null)
            return Task.FromResult(PreconditionResult.FromError("You need to run this command in a Stoat server."));

        if (context.User.Id == context.Server.OwnerId)
            return Task.FromResult(PreconditionResult.FromSuccess());

        return Task.FromResult(PreconditionResult.FromError("Command can only be run by the server owner."));
    }
}
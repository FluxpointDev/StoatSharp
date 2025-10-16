using System;
using System.Threading.Tasks;

namespace StoatSharp.Commands;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class RequireServerAttribute : PreconditionAttribute
{
    /// <inheritdoc />
    public override Task<PreconditionResult> CheckPermissionsAsync(CommandContext context, CommandInfo command, IServiceProvider services)
    {
        if (context.Server == null)
            return Task.FromResult(PreconditionResult.FromError("You need to run this command in a Stoat server."));

        return Task.FromResult(PreconditionResult.FromSuccess());
    }
}
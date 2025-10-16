using StoatSharp.Commands.Builders;

namespace StoatSharp.Commands;


internal interface IModuleBase
{
    void SetContext(CommandContext context);

    void BeforeExecute(CommandInfo command);

    void AfterExecute(CommandInfo command);

    void OnModuleBuilding(CommandService commandService, ModuleBuilder builder);
}

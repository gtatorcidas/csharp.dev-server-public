using System.Reflection;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.Utilities;
using SampSharp.Entities.SAMP.Commands;
using SampSharp.Entities.SAMP.Commands.Parsers;

namespace Torcidas.Application.Services.Overrides
{
    public class AppPlayerCommandService : CommandServiceBase, IPlayerCommandService
    {
        private readonly IEntityManager _entityManager;

        /// <inheritdoc />
        public AppPlayerCommandService(IEntityManager entityManager) : base(entityManager, 1)
        {
            _entityManager = entityManager;
        }

        /// <inheritdoc />
        protected override bool TryCollectParameters(ParameterInfo[] parameters, int prefixParameters, out CommandParameterInfo[] result)
        {
            if (!base.TryCollectParameters(parameters, prefixParameters, out result))
                return false;

            // Ensure player is first parameter
            var type = parameters[0]
                .ParameterType;
            return type == typeof(EntityId) || typeof(Component).IsAssignableFrom(type);
        }

        /// <inheritdoc />
        public bool Invoke(IServiceProvider services, EntityId player, string inputText)
        {
            if (!player.IsOfType(SampEntities.PlayerType))
                throw new InvalidEntityArgumentException(nameof(player), SampEntities.PlayerType);

            var result = Invoke(services, new object[] { player }, inputText);

            if (result.Response != InvokeResponse.InvalidArguments)
                return result.Response == InvokeResponse.Success;

            _entityManager.GetComponent<Player>(player)
                ?.SendClientMessage(result.UsageMessage);
            return true;
        }

        /// <inheritdoc />
        protected override bool ValidateInputText(ref string inputText)
        {
            if (!base.ValidateInputText(ref inputText))
                return false;

            // Player commands must start with a slash.
            if (!inputText.StartsWith("/") || inputText.Length <= 1)
                return false;

            inputText = inputText.Substring(1);

            return true;
        }

        /// <inheritdoc />
        protected override IEnumerable<(MethodInfo method, ICommandMethodInfo commandInfo)> ScanMethods(AssemblyScanner scanner)
        {
            return scanner.ScanMethods<PlayerCommandAttribute>()
                .Select(r => (r.method, r.attribute as ICommandMethodInfo));
        }

        private static string CommandText(CommandInfo command)
        {
            if (command.Parameters.Length == 0)
            {
                return $"{Color.Gray}[USO CORRETO]:{{FFFFFF}} /{command.Name}";
            }

            return $"{Color.Gray}[USO CORRETO]:{{FFFFFF}} /{command.Name} " + string.Join(" ", command.Parameters.Select(arg => arg.IsRequired
                ? $"[{arg.Name}]"
                : $"<{arg.Name}>"));
        }

        /// <inheritdoc />
        protected override string GetUsageMessage(CommandInfo[] commands)
        {
            return commands.Length == 1
                ? CommandText(commands[0])
                : $"{Color.Gray}[USO CORRETO]:{{FFFFFF}}        : {string.Join(" -or- ", commands.Select(CommandText))}";
        }


        protected override ICommandParameterParser CreateParameterParser(ParameterInfo[] parameters, int index)
        {
            var parameter = parameters[index];

            if (parameter.ParameterType == typeof(int))
                return new IntParser();

            if (parameter.ParameterType == typeof(string))
                return index == parameters.Length - 1
                    ? new StringParser()
                    : new WordParser();

            if (parameter.ParameterType == typeof(float))
                return new FloatParser();

            if (parameter.ParameterType == typeof(double))
                return new DoubleParser();

            if (parameter.ParameterType == typeof(Player))
                return new AppPlayerParser();

            if (parameter.ParameterType == typeof(Vehicle))
                return new EntityParser(SampEntities.VehicleType);

            return parameter.ParameterType.IsEnum
                ? new EnumParser(parameter.ParameterType)
                : null;
        }
    }
}

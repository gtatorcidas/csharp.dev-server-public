using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands.Parsers;
using Microsoft.Extensions.DependencyInjection;

namespace Torcidas.Application.Services.Overrides
{
    public class AppPlayerParser: ICommandParameterParser
    {
        private readonly WordParser _wordParser = new();

        /// <inheritdoc />
        public bool TryParse(IServiceProvider services, ref string inputText, out object result)
        {
            if (!_wordParser.TryParse(services, ref inputText, out var subResult) || !(subResult is string word))
            {
                result = null;
                return false;
            }

            var entityManager = services.GetRequiredService<IEntityManager>();
            if (int.TryParse(word, out var intWord))
            {
                var entity = SampEntities.GetPlayerId(intWord);

                if (entityManager.Exists(entity))
                {
                    result = entity;
                    return true;
                }
            }

            var players = entityManager.GetComponents<Player>();
            EntityId bestCandidate = null;

            foreach (Player player in players)
            {
                if (player.Name.Equals(word, StringComparison.OrdinalIgnoreCase))
                {
                    result = player.Entity;
                    return true;
                }

                if (player.Name.ToLower()
                    .StartsWith(word.ToLower()))
                {
                    if (bestCandidate == null)
                        bestCandidate = player.Entity;
                    else if (player.Entity.Handle < bestCandidate.Handle)
                        bestCandidate = player.Entity;
                }
            }

            result = bestCandidate;
            return true;
        }
    }
}

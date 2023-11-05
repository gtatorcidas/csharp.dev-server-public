using SampSharp.Entities.SAMP;
using Torcidas.Core.Components;
using Torcidas.Core.Enums;
using Torcidas.Core.Interfaces.Services;

namespace Torcidas.Application.Services
{
    public class ServerConfigService : IServerConfigService
    {
        public void CheckPlayerGameClient(Player player)
        {
            string clientID = player.Gpci.ToString();

            player.AddComponent<ConfigComponent>().Platform = clientID switch
            {
                "5638413348335738345A4536524D4A524539334B" => EClientPlatform.SAMP_TAILANDIA,
                "ED40ED0E8089CC44C08EE9580F4C8C44EE8EE990" => EClientPlatform.SAMP_LAUNCHER,
                _ => EClientPlatform.PC,
            };
        }
    }
}

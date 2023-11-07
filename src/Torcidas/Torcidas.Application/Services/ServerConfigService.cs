using SampSharp.Entities.SAMP;

using Torcidas.Core.Enums;
using Torcidas.Core.Components;
using Torcidas.Application.Services.Interfaces;

namespace Torcidas.Application.Services
{
    public class ServerConfigService : IServerConfigService
    {
        public void OnPlayerConnectHandler(Player player)
        {
            string clientID = player.Gpci.ToString();

            player.AddComponent<ServerConfigComponent>().Platform = clientID switch
            {
                "5638413348335738345A4536524D4A524539334B" => EClientPlatform.SAMP_TAILANDIA,
                "ED40ED0E8089CC44C08EE9580F4C8C44EE8EE990" => EClientPlatform.SAMP_LAUNCHER,
                _ => EClientPlatform.PC,
            };
        }
    }
}

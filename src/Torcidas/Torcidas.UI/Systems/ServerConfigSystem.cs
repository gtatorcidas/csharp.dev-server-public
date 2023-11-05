using System;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using Torcidas.Core.Interfaces.Services;

namespace Torcidas.UI.Systems
{
    public class ServerConfigSystem : ISystem
    {

        private readonly IServerConfigService _serverConfigService;

        public ServerConfigSystem(IServerConfigService serverConfigService)
        {
            _serverConfigService = serverConfigService;
        }

        [Event]
        public void OnPlayerConnect(Player player) => _serverConfigService.CheckPlayerGameClient(player);

        

    }
}

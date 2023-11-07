using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using Torcidas.Core.Components;
using Torcidas.Application.Services.Interfaces;

namespace Torcidas.UI.Systems
{
    public class FpsSystem : ISystem
    {

        private readonly IFpsService _fpsService;

        public FpsSystem(IFpsService fpsService)
        {
            _fpsService = fpsService;
        }

        [Event]
        public void OnPlayerSpawn(Player player) => _fpsService.OnPlayerSpawnHandler(player);

        [Event]
        public void OnPlayerUpdate(ServerConfigComponent serverConfigComponent) => _fpsService.OnPlayerUpdateHandler(serverConfigComponent);
 
    }
}

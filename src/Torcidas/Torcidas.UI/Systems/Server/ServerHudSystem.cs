using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using Torcidas.Application.Services.Interfaces;

namespace Torcidas.UI.Systems.Server
{
    public class ServerHudSystem: ISystem
    {
        #region Properties

        private readonly IServerHudService _serverHudService;

        #endregion

        #region Constructor

        public ServerHudSystem(IServerHudService serverHudService)
        {
            _serverHudService = serverHudService;
        }

        #endregion
        
        [Event]
        public void OnPlayerConnect(Player player) => _serverHudService.OnPlayerConnectHandler(player);
        
        [Event]
        public void OnPlayerSpawn(Player player) => _serverHudService.OnPlayerSpawnHandler(player);
        
        
    }
}
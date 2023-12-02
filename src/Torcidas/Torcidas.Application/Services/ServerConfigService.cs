using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using Torcidas.Domain.Enums;
using Torcidas.Core.Components;
using Torcidas.Application.Services.Interfaces;

namespace Torcidas.Application.Services
{
    public class ServerConfigService : IServerConfigService
    {
        #region Properties

        private readonly IEntityManager _entityManager;
        private readonly IUserService _userService;
        private readonly IServerService _serverService;
        private readonly ITimerService _timerService;
        private readonly IServerHudService _serverHudService;

        #endregion

        #region Constructors
        public ServerConfigService(IEntityManager entityManager, IUserService userService, 
            IServerService serverService, ITimerService timerService, IServerHudService serverHudService)
        {
            _entityManager = entityManager;
            _userService = userService;
            _serverService = serverService;
            _timerService = timerService;
            _serverHudService = serverHudService;
        }
        #endregion

        #region Public Methods
        public void OnPlayerConnectHandler(Player player)
        {
            player.ToggleSpectating(true);

            if (player.IsNpc) return;

            if (string.IsNullOrEmpty(player.Name) ||        
                string.IsNullOrEmpty(player.Ip)) player.Kick();

            var user = _userService.GetUserByUserName(player.Name);

            
            Vector3 spawnPosition;
            int skinId;
            int soundId;
            
            if (user is not null)
            {
                skinId = 1;
                soundId = 1057;
                spawnPosition = new Vector3(1123.91, -2036.79, 69.886);
                var component = player.AddComponent<UserComponent>(user);
                component.IsLogged = true;
            }
            else
            {
                skinId = 0;
                soundId = 1085;
                spawnPosition = new Vector3(1037.96, -1338.38, 13.727);
            }
            
            TimerReference? timer = null;

            timer = _timerService.Start((_) =>
            {
                player.PlaySound(soundId);
                player.ToggleSpectating(false);
                player.ToggleControllable(false);

                player.SetSpawnInfo(player.Entity, skinId, spawnPosition , 0);

                player.Spawn();

                _timerService.Stop(timer);

            }, TimeSpan.FromSeconds(2));

            var clientId = player.Gpci;

            player.AddComponent<ServerConfigComponent>().Platform = clientId switch
            {
                "5638413348335738345A4536524D4A524539334B" => ClientPlatformEnum.SampTailandia,
                "ED40ED0E8089CC44C08EE9580F4C8C44EE8EE990" => ClientPlatformEnum.SampLauncher,
                _ => ClientPlatformEnum.PersonalComputer,
            };

        }

        public void OneThousandMsTickerHandler()
        {
            var playersList = _entityManager.GetComponents<Player>();
            
            var usersList = playersList
                .Select(x => x.GetComponent<UserComponent>())
                .Where(x => x?.GetUser() != null).ToList();

            foreach (var userComponent in usersList.Where(userComponent => userComponent.IsLogged))
            {
                _serverHudService.UpdateHudTickerHandler(userComponent, playersList.Length);
            }
        }

        public void OnGameModeInitHandler()
        {
            _serverService.UsePlayerPedAnims();
        }

        #endregion

    }
}

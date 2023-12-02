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
        private readonly IServerHudService _serverHudService;

        #endregion

        #region Constructors
        public ServerConfigService(IEntityManager entityManager, IUserService userService, 
            IServerService serverService, IServerHudService serverHudService)
        {
            _entityManager = entityManager;
            _userService = userService;
            _serverService = serverService;
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

            if (user is not null)
            {
                player.AddComponent<UserComponent>(user);

                player.PlaySound(1057);

                player.ToggleSpectating(false);

                player.GetComponent<UserComponent>().IsLogged = true;

                player.SetSpawnInfo(0, 1, new Vector3(1123.91, -2036.79, 69.886), 0);

                player.Spawn();

            }
            else
            {
                player.PlaySound(1085);

                player.ToggleSpectating(false);

                player.Spawn();
            }

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
                .Where(x => x.GetUser() is { } userDto).ToList();

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

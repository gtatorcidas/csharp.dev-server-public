using SampSharp.Entities.SAMP;

using Torcidas.Core.Components;
using Torcidas.Application.Services.Interfaces;

namespace Torcidas.Application.Services
{
    public class ServerHudService: IServerHudService
    {
        
        #region Properties

        private readonly IWorldService _worldService;
        private readonly IServerService _serverService;

        #endregion

        #region Constructor

        public ServerHudService(IWorldService worldService, IServerService serverService)
        {
            _worldService = worldService;
            _serverService = serverService;
        }

        #endregion

        #region Public Methods
        
        private void SetupServerHudHandler(Player player)
        {
            var component = player.AddComponent<ServerHudComponent>();
            
            var serverYear = DateTime.Now.Year - 2009;

            var now = DateTime.Now;

            component.SetupBoxTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(-13.555583, 465.271087), "box"));

            component.SetupPlayerLevelTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(500.939392, 1.746677), "Level 0"));
            
            component.SetupDateTimeTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(503, 419), $"{now:dd/MM/yyyy HH:mm:ss}"));   
                        
            component.SetupWebsiteTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(505, 391), "www.gtatorcidas.net"));

            component.SetupEquipBrandTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(215.666748, 437.893341), $"~w~]]] ~r~Equipe GT - {serverYear} Anos ~w~]]]"));
            
            component.SetupBlankTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(482, 385), "-"));

            component.SetupBlankTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(483, 383), "-"), -16776961);
            
            component.SetupDynamicAnnouncementTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(208.666748, 438.888824), "Quer denunciar um jogador? use '/rpt 'id' motivo'"));

            component.SetupPaydayTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(31.777769, 437.893341), "Proximo payday em: 19:05"));

            component.SetupBlankTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(482, 422), "-"));
            
            component.SetupYearsOldTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(509, 380), $"]]]   {serverYear} ANOS   ]]]"));
            
            component.SetupBlankTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(483, 424), "-"), -16776961);
            
            component.SetupServerNameTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(500, 400), "~R~G~W~TA ~r~T~w~orcidas"));
            
            component.SetupPlayersCountTextDraw(_worldService.CreatePlayerTextDraw(player, new Vector2(557, 430), $"Players: 0/{_serverService.MaxPlayers}"));

        }

        public void OnPlayerConnectHandler(Player player)
        {
            SetupServerHudHandler(player);
        }

        public void OnPlayerSpawnHandler(Player player)
        {
           var component = player.GetComponent<ServerHudComponent>();

           // TODO: Check If Is The First Spawn?
           component.ShowServerHudTextDraws();
        }

        public void UpdateHudTickerHandler(UserComponent userComponent, int onlinePlayers)
        {
            var serverHudComponent = userComponent.GetComponent<ServerHudComponent>();

            serverHudComponent.UpdatePlayerCountTextDrawTicker(onlinePlayers, _serverService.MaxPlayers);
            serverHudComponent.UpdateDateTimeTextDrawTicker();
        }

        #endregion

    }
    

}
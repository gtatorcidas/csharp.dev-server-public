using SampSharp.Entities.SAMP;

using Torcidas.Domain.Enums;
using Torcidas.Core.Components;
using Torcidas.Application.Services.Interfaces;

namespace Torcidas.Application.Services
{
    public class FpsService: IFpsService
    {
        #region Properties
        private readonly IWorldService _worldService;
        #endregion

        #region Constructors
        public FpsService(IWorldService worldService) { 
        
            _worldService = worldService;
        }

        #endregion

        #region Public Methods
        public void OnPlayerSpawnHandler(Player player)
        {
            var component = player.GetComponent<FpsComponent>();

            if (component != null) return;

            player.AddComponent<FpsComponent>();

            var positionOfTextDraw = new Vector2(40, 315);

            player.GetComponent<FpsComponent>().SetupFpsTextDraw(_worldService.CreatePlayerTextDraw(player.Entity, positionOfTextDraw, ""));

        }

        public void OnPlayerUpdateHandler(ServerConfigComponent serverConfigComponent)
        {
            var player = serverConfigComponent.GetComponent<Player>();

            var configComponent = player.GetComponent<ServerConfigComponent>();

            if (configComponent.Platform == ClientPlatformEnum.PersonalComputer) OnPlayerFpsUpdateHandler(player);

            if (configComponent.Platform != ClientPlatformEnum.PersonalComputer)
            {
                var fpsComponent = player.GetComponent<FpsComponent>();

                if (fpsComponent != null)
                {
                    fpsComponent.FpsTextDraw.Destroy();
                    fpsComponent.Destroy();
                }

            }
        }

        #endregion

        #region Private Methods
        private void OnPlayerFpsUpdateHandler(Player player)
        {

            var component = player.GetComponent<FpsComponent>();

            if (component == null) return;

            if (!component.Timer.IsRunning)
            {
                component.Timer.Start();
            }
            else
            {
                if (component.Timer.ElapsedMilliseconds < 1000) return;

                component.Timer.Restart();

                var fps = GetPlayerFps(player);

                if (fps > 0) component.FpsTextDraw.Text = $"FPS:{fps}";
            }

        }

        private int GetPlayerFps(Player player)
        {

            var component = player.GetComponent<FpsComponent>();


            var playerDrunkLevel = player.DrunkLevel;

            if (playerDrunkLevel < 100)
            {
                player.DrunkLevel = 2000;
            }
            else
            {
                if (component.LastDrunkLevel == playerDrunkLevel) return component.Fps;

                var newFps = component.LastDrunkLevel - playerDrunkLevel;

                component.Fps = newFps > 0 && newFps < 256 ? newFps : component.Fps;

                component.LastDrunkLevel = playerDrunkLevel;

                return component.Fps - 1;
            }

            return component.Fps;
        }

        #endregion
    }
}

using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using Torcidas.Core.Components;
using Torcidas.Core.Enums;
using Torcidas.Core.Interfaces.Services;

namespace Torcidas.Core.Systems
{
    public class FpsSystem : ISystem
    {

        private readonly IFpsService _fpsService;

        public FpsSystem(IFpsService fpsService)
        {
            _fpsService = fpsService;
        }


        [Event]
        public void OnPlayerSpawn(Player player, IWorldService worldService)
        {
            var component = player.GetComponent<FpsComponent>();

            if (component != null) return;

            player.AddComponent<FpsComponent>();
            var positionOfTextDraw = new Vector2(40, 315);
            player.GetComponent<FpsComponent>().SetupFpsTextDraw(worldService.CreatePlayerTextDraw(player.Entity, positionOfTextDraw, ""));

        }

        [Event]
        public void OnPlayerUpdate(ConfigComponent config)
        {
            var player = config.GetComponent<Player>();
            var configComponent = player.GetComponent<ConfigComponent>();
            if (configComponent.Platform == EClientPlatform.PC) _fpsService.OnPlayerFpsUpdate(player);

            if (configComponent.Platform != EClientPlatform.PC)
            {
                var fpsComponent = player.GetComponent<FpsComponent>();

                if (fpsComponent != null)
                {
                    fpsComponent.RemoveFpsTextDraw();
                    fpsComponent.Destroy();
                }

            }

        }

     

 
    }
}

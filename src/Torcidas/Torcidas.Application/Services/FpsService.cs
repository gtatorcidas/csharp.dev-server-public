using SampSharp.Entities.SAMP;
using Torcidas.Core.Components;
using Torcidas.Core.Interfaces.Services;

namespace Torcidas.Application.Services
{
    public class FpsService: IFpsService
    {

        public void OnPlayerFpsUpdate(Player player)
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
    }
}

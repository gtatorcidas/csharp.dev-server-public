using SampSharp.Entities.SAMP;

namespace Torcidas.Application.Services.Interfaces
{
    public interface IServerConfigService
    {
        void OnGameModeInitHandler();
        void OnPlayerConnectHandler(Player player);
        void OneThousandMsTickerHandler();
    }
}

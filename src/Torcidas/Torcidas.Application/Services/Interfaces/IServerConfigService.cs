using SampSharp.Entities.SAMP;

namespace Torcidas.Application.Services.Interfaces
{
    public interface IServerConfigService
    {
        void OnPlayerConnectHandler(Player player);
    }
}

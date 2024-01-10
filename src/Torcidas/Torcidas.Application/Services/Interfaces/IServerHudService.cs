using SampSharp.Entities.SAMP;

using Torcidas.Core.Components.Users;

namespace Torcidas.Application.Services.Interfaces
{
    public interface IServerHudService
    {
        void OnPlayerConnectHandler(Player player);
        void OnPlayerSpawnHandler(Player player);
        void UpdateHudTickerHandler(UserComponent userComponent, int onlinePlayers);

    }
}
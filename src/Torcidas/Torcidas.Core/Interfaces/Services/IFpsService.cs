using SampSharp.Entities.SAMP;

namespace Torcidas.Core.Interfaces.Services
{
    public interface IFpsService
    {

        void OnPlayerFpsUpdate(Player player);

    }
}

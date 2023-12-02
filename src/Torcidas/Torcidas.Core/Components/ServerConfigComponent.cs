using SampSharp.Entities;

using Torcidas.Domain.Enums;

namespace Torcidas.Core.Components
{
    public class ServerConfigComponent : Component
    {
        public ServerConfigComponent() { }

        public ClientPlatformEnum Platform { get; set; }

    }
}

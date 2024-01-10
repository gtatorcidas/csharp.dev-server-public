using SampSharp.Entities;

using Torcidas.Domain.Enums;

namespace Torcidas.Core.Components.Server
{
    public class ServerConfigComponent : Component
    {
        public ServerConfigComponent() { }

        public ClientPlatformEnum Platform { get; set; }

    }
}

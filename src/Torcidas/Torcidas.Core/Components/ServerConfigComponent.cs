using SampSharp.Entities;

using Torcidas.Core.Enums;

namespace Torcidas.Core.Components
{
    public class ServerConfigComponent : Component
    {
        public ServerConfigComponent() { }

        public EClientPlatform Platform { get; set; }

    }
}

using SampSharp.Entities;
using Torcidas.Core.Enums;

namespace Torcidas.Core.Components
{


    public class ConfigComponent : Component
    {

        public ConfigComponent() { }

        public EClientPlatform Platform { get; set; }

    }
}

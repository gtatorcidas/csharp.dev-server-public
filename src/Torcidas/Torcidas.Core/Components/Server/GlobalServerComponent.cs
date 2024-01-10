using SampSharp.Entities;

namespace Torcidas.Core.Components.Server
{
    public class GlobalServerComponent : Component
    {
        public bool AnyGlobalPropertyHere { get; set; } = false;

        public GlobalServerComponent() 
        {
        }
    }
}

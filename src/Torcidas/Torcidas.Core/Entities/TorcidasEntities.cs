using SampSharp.Entities;

namespace Torcidas.Core.Entities
{
    public static class TorcidasEntities
    {

        [EntityType]
        public static readonly Guid GlobalServerObjectType = new("00277F50-6F07-4A51-88BB-314616AA2DA0");
        
        public static EntityId GetGlobalServerObject(int id)
        {
            return new EntityId(GlobalServerObjectType, id);
        }
    }
}

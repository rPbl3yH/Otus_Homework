using System;
using Leopotam.EcsLite;

namespace LeoEcsHomeTask
{
    public struct PackerEntityUtils
    {
        public static (int, int) UnpackEntities(EcsWorld world, EcsPackedEntity firstPacked, EcsPackedEntity secondPacked)
        {
            if (firstPacked.Unpack(world, out int firstEntity) && secondPacked.Unpack(world, out int secondEntity))
            {
                return (firstEntity, secondEntity);
            }
            else
            {
                throw new Exception("Unpacking doesn't success");
            }
            
        }
    }
}
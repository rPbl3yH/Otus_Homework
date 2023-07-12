using System;
using Leopotam.EcsLite;
using Unity.VisualScripting;
using UnityEngine;

namespace LeoEcsHomeTask.Views
{
    public class EcsMonoObject : MonoBehaviour
    {
        public EcsPackedEntity PackedEntity;

        protected EcsWorld World;
        
        public void Init(EcsWorld world)
        {
            World = world;
        }

        public void PackEntity(int entity)
        {
            PackedEntity = World.PackEntity(entity);
        }
    }
}
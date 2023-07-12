using System;
using UnityEngine;

namespace LeoEcs.Systems
{
    [Serializable]
    public class UnitData
    {
        public string Path;
    }

    [Serializable]
    public class BulletData
    {
        public string Path;
        public float Speed;
        public int Damage;
    }
    
    [Serializable]
    public class SharedData
    {
        public Transform SpawnPoint;
        public int SpawnDistance;

        public int SpawnCount;

        public int Health;

        public int Speed;
        public Color Color;
        public bool IsRed;
    }

    [Serializable]
    public class SharedBlueData : SharedData
    {
        
    }

    [Serializable]
    public class SharedRedData : SharedData
    {
        
    }
}
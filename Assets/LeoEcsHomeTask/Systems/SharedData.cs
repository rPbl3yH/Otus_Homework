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
    public class SharedData
    {
        public int BorderX;
        public int BorderZ;

        public int SpawnCount;

        public int Health;
        public int Damage;

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
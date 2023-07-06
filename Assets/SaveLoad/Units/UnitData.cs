using System;
using Homeworks.SaveLoad;
using UnityEngine;

namespace SaveLoad.Units
{
    [Serializable]
    public class UnitData
    {
        public float[] Position = new float[3];
        public int Damage;
        public int Speed;
        public int HitPoints;
    }
}
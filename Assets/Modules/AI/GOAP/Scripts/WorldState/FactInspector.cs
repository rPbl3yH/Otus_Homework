using UnityEngine;

namespace AI.GOAP
{
    public abstract class FactInspector : MonoBehaviour
    {
        public abstract void OnUpdate(WorldState worldState);
    }
}
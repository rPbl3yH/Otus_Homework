using UnityEngine;

namespace ShootEmUp
{
    public sealed class TeamComponent : MonoBehaviour
    {
        public bool IsPlayer => _isPlayer;

        [SerializeField]
        private bool _isPlayer;
    }
}

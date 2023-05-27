using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBounds : MonoBehaviour
    {
        [SerializeField]
        private Transform _leftBorder;

        [SerializeField]
        private Transform _rightBorder;

        [SerializeField]
        private Transform _downBorder;

        [SerializeField]
        private Transform _topBorder;
        
        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;
            return positionX > _leftBorder.position.x
                   && positionX < _rightBorder.position.x
                   && positionY > _downBorder.position.y
                   && positionY < _topBorder.position.y;
        }
    }
}
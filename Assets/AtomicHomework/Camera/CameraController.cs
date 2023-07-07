using UnityEngine;

namespace AtomicHomework.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _target;
    
        private void Update()
        {
            transform.position = _target.position;
        }
    }
}

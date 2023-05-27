using UnityEngine;

namespace ShootEmUp
{
    public sealed class FireInput : MonoBehaviour {
        
        [SerializeField]
        private CharacterController _characterController;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _characterController._fireRequired = true;
            }
        }
    }
}
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class FireInput : MonoBehaviour {
        
        private CharacterController _characterController;

        [Inject]
        public void Construct(CharacterController characterController) {
            _characterController = characterController;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _characterController._fireRequired = true;
            }
        }
    }
}
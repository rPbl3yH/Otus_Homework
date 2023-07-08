using System;
using AtomicHomework.Hero;
using UnityEngine;

namespace AtomicHomework.Input
{
    public class FireInputController : MonoBehaviour
    {
        [SerializeField] private HeroDocument _hero;
        
        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                _hero.Fire.OnFire?.Invoke();
            }
        }
    }
}
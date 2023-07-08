using System;
using AtomicHomework.Hero;
using UnityEngine;

namespace AtomicHomework.Input
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private InputSystem _input;
        [SerializeField] private HeroDocument _document;

        private void Awake()
        {
            _input.OnDirectionChanged += OnDirectionChanged;
        }

        private void OnDestroy()
        {
            _input.OnDirectionChanged -= OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector3 direction)
        {
            _document.Move.Engine.Move(direction);
        }
    }
}
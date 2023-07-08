using System;
using AtomicHomework.Entities.Components;
using AtomicHomework.Hero.Entity;
using UnityEngine;

namespace AtomicHomework.Input
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private InputSystem _input;
        [SerializeField] private HeroEntity _heroEntity;

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
            if(_heroEntity.TryGet(out IMoveComponent component))
            {
                component.Move(direction);
            }
        }
    }
}
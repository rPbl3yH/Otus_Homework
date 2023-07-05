using Entities;
using Lessons.Character.Components;
using Lessons.Character.Model;
using UnityEngine;

namespace Lessons.Character
{
    [DefaultExecutionOrder(-100)]
    public sealed class CharacterEntity : MonoEntityBase
    {
        private void Awake()
         {
             var characterModel = GetComponent<CharacterModel>();
             Add(new MoveInDirectionComponent(characterModel.core.movement.movementDirection));
         }
    }
}
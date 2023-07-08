using Entities;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class HeroEntity : MonoEntityBase
    {
        [SerializeField] private HeroModel _model;
        private void Awake()
        {
            
        }
    }
}
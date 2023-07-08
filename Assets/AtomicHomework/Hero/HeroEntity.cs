using Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace AtomicHomework.Hero
{
    public class HeroEntity : MonoEntityBase
    {
        [FormerlySerializedAs("_model")] [SerializeField] private HeroDocument _document;
        private void Awake()
        {
            
        }
    }
}
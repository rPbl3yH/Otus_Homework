using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class HeroDocument : DeclarativeModel
    {
        public Transform Transform;
        
        [Section] 
        [SerializeField]
        public Life Life;
        
        [Section] 
        [SerializeField]
        public Move Move;
        
        [Section] 
        [SerializeField]
        public Rotate Rotate;
    }
}

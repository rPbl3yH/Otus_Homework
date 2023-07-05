using Declarative;
using UnityEngine;

namespace Lessons.Gameplay.Atomic1
{
    public sealed class HeroModel : DeclarativeModel
    {
        [Section]
        [SerializeField]
        public HeroModel_Core core = new();

        [Section]
        [SerializeField]
        public HeroModel_View view = new();
    }
}
using AtomicHomework.Hero;
using Declarative;

namespace AtomicHomework.Atomic.Enemy.Document
{
    public class EnemyDocument : DeclarativeModel
    {
        [Section] 
        public Life Life;

        [Section]
        public Death Death;
    }
}
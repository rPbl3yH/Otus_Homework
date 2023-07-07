namespace Lessons.Gameplay.Atomic1
{
    public interface IAtomicAction
    {
        void Invoke();
    }

    public interface IAtomicAction<in T>
    {
        void Invoke(T args);
    }
}
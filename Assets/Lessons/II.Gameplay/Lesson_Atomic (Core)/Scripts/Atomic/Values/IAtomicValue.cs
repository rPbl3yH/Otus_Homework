namespace Lessons.Gameplay.Atomic1
{
    public interface IAtomicValue<out T>
    {
        T Value { get; }
    }
}
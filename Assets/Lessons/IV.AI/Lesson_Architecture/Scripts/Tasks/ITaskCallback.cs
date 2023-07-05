namespace Lessons.AI.Lesson_Architecture
{
    public interface ITaskCallback
    {
        void OnComplete(Task task, bool success);
    }
}
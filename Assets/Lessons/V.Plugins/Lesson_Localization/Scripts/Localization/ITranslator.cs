using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    public interface ITranslator<out T>
    {
        T GetTranlation(string key, SystemLanguage language);
    }
}
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    public interface ILanguageListener
    {
        void OnLanguageChanged(SystemLanguage language);
    }
}
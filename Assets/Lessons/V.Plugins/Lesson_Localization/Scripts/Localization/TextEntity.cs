using System;

namespace Lessons.Plugins.Lesson_Localization
{
    [Serializable]
    public struct TextEntity
    {
        public string key;

        public LocalizedString[] translations;
    }
}
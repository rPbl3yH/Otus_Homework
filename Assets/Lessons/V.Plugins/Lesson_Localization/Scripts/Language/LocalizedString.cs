using System;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    [Serializable]
    public struct LocalizedString
    {
        public SystemLanguage language;

        public string value;
    }
}
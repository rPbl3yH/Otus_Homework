using System;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    [Serializable]
    public struct LocalizedInt
    {
        public SystemLanguage language;

        public int value;
    }
}
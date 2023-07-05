using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    public static class Extensions
    {
        public static bool TryGetOption(this LocalizedString[] options, SystemLanguage language, out string result)
        {
            foreach (var option in options)
            {
                if (option.language == language)
                {
                    result = option.value;
                    return true;
                }
            }
            
            result = default;
            return false;
        }
    }
}
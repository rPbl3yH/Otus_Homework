using System;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    [Serializable]
    public sealed class TextFontSizeLanguageListener : ILanguageListener
    {
        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField]
        private LocalizedInt[] options;
    
        void ILanguageListener.OnLanguageChanged(SystemLanguage language)
        {
            var value = this.options.FirstOrDefault(it => it.language == language).value;
            if (value != 0)
            {
                this.text.fontSize = value;                
            }
        }
    }
}
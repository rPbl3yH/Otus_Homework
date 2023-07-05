using System;
using TMPro;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    [Serializable]
    public sealed class TextLanguageListener : ILanguageListener
    {
        [SerializeField]
        private TextMeshProUGUI text;

        [TranslationKey]
        [SerializeField]
        private string key;

        void ILanguageListener.OnLanguageChanged(SystemLanguage language)
        {
            this.text.text = LocalizationManager.GetText(this.key, language);
        }
    }
}
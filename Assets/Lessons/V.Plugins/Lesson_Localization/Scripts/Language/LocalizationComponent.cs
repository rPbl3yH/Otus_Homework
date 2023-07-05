using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    public sealed class LocalizationComponent : MonoBehaviour
    {
        [SerializeReference]
        private ILanguageListener[] listeners;
    
        private void OnEnable()
        {
            this.UpdateLanguage(LanguageManager.Language);
            LanguageManager.OnLanguageChanged += this.UpdateLanguage;
        }

        private void OnDisable()
        {
            LanguageManager.OnLanguageChanged -= this.UpdateLanguage;            
        }

        private void UpdateLanguage(SystemLanguage language)
        {
            foreach (var listener in this.listeners)
            {
                listener.OnLanguageChanged(language);
            }
        }
    }
}
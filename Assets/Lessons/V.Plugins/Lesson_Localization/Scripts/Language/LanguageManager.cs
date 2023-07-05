using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    public sealed class LanguageManager : MonoBehaviour
    {
        public static event Action<SystemLanguage> OnLanguageChanged;

        public static SystemLanguage Language
        {
            get { return GetLanguage(); }
            set { SetLanguage(value); }
        }

        private static LanguageManager instance;

        [ShowInInspector, OnValueChanged("SetLanguageInEditor")]
        private SystemLanguage language;

        private void Awake()
        {
            if (instance != null)
            {
                throw new Exception("Language Manager is already exists!");
            }

            instance = this;
            
            var initialLanguage = Application.systemLanguage;
            language = initialLanguage;
            OnLanguageChanged?.Invoke(initialLanguage);
        }

        private void OnDestroy()
        {
            instance = null;
        }

        private static void SetLanguage(SystemLanguage value)
        {
            if (instance != null)
            {
                instance.language = value;
                OnLanguageChanged?.Invoke(value);
            }
        }
        
        private static SystemLanguage GetLanguage()
        {
            if (instance != null)
            {
                return instance.language;
            }

            return default;
        }

#if UNITY_EDITOR
        private void SetLanguageInEditor(SystemLanguage value)
        {
            Debug.Log($"Language changed {value}");
            this.language = value;
            OnLanguageChanged?.Invoke(value);
        }
#endif
    }
}
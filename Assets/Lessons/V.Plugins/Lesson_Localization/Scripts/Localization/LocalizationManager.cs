using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    public sealed class LocalizationManager : MonoBehaviour
    {
        private static LocalizationManager instance;

        [SerializeField]
        private TextDictionary textConfig;

        private ITranslator<string> textTranslator;

        private ITranslator<Sprite> spriteTranslator;

        private ITranslator<AudioClip> audioTranslator;

        private void Awake()
        {
            if (instance != null)
            {
                throw new Exception("Localization Manager is already exists!");
            }
            
            instance = this;
            this.textTranslator = new TextTranslator(this.textConfig.entities);
        }

        private void OnDestroy()
        {
            instance = null;
        }

        [Button]
        public static string GetText(string key, SystemLanguage language)
        {
            if (instance != null)
            {
                return instance.textTranslator.GetTranlation(key, language);                
            }

            return key;
        }

        public static Sprite GetSprite(string key, SystemLanguage language)
        {
            throw new NotImplementedException();
        }

        public static AudioClip GetAudio(string key, SystemLanguage language)
        {
            throw new NotImplementedException();            
        }
    }
}
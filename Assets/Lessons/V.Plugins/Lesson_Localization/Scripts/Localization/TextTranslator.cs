using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    public sealed class TextTranslator : ITranslator<string>
    {
        private readonly Dictionary<string, LocalizedString[]> entities;

        public TextTranslator(TextEntity[] entities)
        {
            this.entities = new Dictionary<string, LocalizedString[]>();
            foreach (var entity in entities)
            {
                this.entities[entity.key] = entity.translations;
            }
        }

        public string GetTranlation(string key, SystemLanguage language)
        {
            if (!this.entities.TryGetValue(key, out var translations))
            {
                return key;
            }

            if (!translations.TryGetOption(language, out var result))
            {
                return key;
            }

            return result;
        }
    }
}
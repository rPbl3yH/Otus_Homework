using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    [CreateAssetMenu(
        fileName = "Text Dictionary",
        menuName = "Lessons/New Text Dictionary"
    )]
    public sealed class TextDictionary : ScriptableObject
    {
        [TextArea]
        [SerializeField]
        public string uri;
    
        [SerializeField]
        public TextEntity[] entities;
    }
}
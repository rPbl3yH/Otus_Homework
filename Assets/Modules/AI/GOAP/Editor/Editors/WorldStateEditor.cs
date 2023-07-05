#if UNITY_EDITOR

using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace AI.GOAP.UnityEditor
{
    [CustomEditor(typeof(WorldState), editorForChildClasses: true)]
    public sealed class WorldStateEditor : OdinEditor
    {
        private bool foldout = true;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (EditorApplication.isPlaying)
            {
                this.DrawFacts();
            }
        }

        private void DrawFacts()
        {
            GUI.enabled = false;
            EditorGUILayout.Space(16);

            this.foldout = EditorGUILayout.Foldout(this.foldout, "Facts");
            if (this.foldout)
            {
                EditorGUI.indentLevel++;

                var worldState = (WorldState) this.serializedObject.targetObject;
                foreach (var (id, value) in worldState)
                {
                    EditorGUILayout.Toggle(id, value);
                }

                EditorGUI.indentLevel--;
            }

            GUI.enabled = true;
        }
    }
}
#endif
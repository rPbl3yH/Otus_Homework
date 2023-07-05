#if UNITY_EDITOR
using System.Linq;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace AI.GOAP.UnityEditor
{
    [CustomEditor(typeof(GoalOrientedAgent))]
    public sealed class GoalOrientedAgentEditor : OdinEditor
    {
        private GoalOrientedAgent planner;

        protected override void OnEnable()
        {
            base.OnEnable();
            this.planner = (GoalOrientedAgent) this.target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (EditorApplication.isPlaying)
            {
                this.DrawPlaymode();
            }
        }

        private void DrawPlaymode()
        {
            GUI.enabled = false;
            this.DrawGoals();
            this.DrawActions();
            GUI.enabled = true;
            this.DrawButtons();
        }

        private void DrawGoals()
        {
            EditorGUILayout.Space(4.0f);
            EditorGUILayout.LabelField("Active Goals");
            var goals = this.planner.AllGoals
                .OrderByDescending(it => it.IsValid() ? it.EvaluatePriority() : -1);

            foreach (var goal in goals)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.ObjectField(goal as Goal, typeof(Goal), false);
                var isValid = goal.IsValid();
                if (isValid)
                {
                    EditorGUILayout.TextField("Priority: " + goal.EvaluatePriority());
                }
                else
                {
                    EditorGUILayout.TextField("Inactive");
                }

                EditorGUILayout.EndHorizontal();
            }
        }

        private void DrawActions()
        {
            EditorGUILayout.Space(4.0f);
            EditorGUILayout.LabelField("Active Actions");
            var actions = this.planner.AllActions
                .OrderByDescending(it => it.IsValid() ? it.EvaluateCost() : -1);

            foreach (var action in actions)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.ObjectField(action as Actor, typeof(Actor), false);
                var isValid = action.IsValid();
                if (isValid)
                {
                    EditorGUILayout.TextField("Cost: " + action.EvaluateCost());
                }
                else
                {
                    EditorGUILayout.TextField("Inactive");
                }

                EditorGUILayout.EndHorizontal();
            }
        }

        private void DrawButtons()
        {
            EditorGUILayout.Space(8.0f);
            if (GUILayout.Button("Play"))
            {
                this.planner.Play();
            }

            if (GUILayout.Button("Replay"))
            {
                this.planner.Replay();
            }

            if (GUILayout.Button("Cancel"))
            {
                this.planner.Cancel();
            }
        }
    }
}
#endif
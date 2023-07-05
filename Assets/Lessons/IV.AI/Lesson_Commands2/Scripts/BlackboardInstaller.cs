using AI.Blackboards;
using Entities;
using UnityEngine;
using Blackboard = Lessons.AI.Architecture2.Blackboard;

namespace Lessons.AI.Lesson_Commands2
{
    public sealed class BlackboardInstaller : MonoBehaviour
     {
         [SerializeField]
         private Blackboard blackboard;

         [Space]
         [BlackboardKey]
         [SerializeField]
         private string unitKey;

         [SerializeField]
         private MonoEntity unitEntity;
         
         private void Awake()
         {
             this.blackboard.AddVariable(this.unitKey, this.unitEntity);
         }
     }
}
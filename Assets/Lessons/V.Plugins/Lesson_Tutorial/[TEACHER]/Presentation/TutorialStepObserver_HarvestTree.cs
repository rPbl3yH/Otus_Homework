// using GameElements;
// using Sirenix.Utilities;
// // ReSharper disable UnusedType.Global
// // ReSharper disable UnusedMember.Global
//
// namespace Lessons.PRESENTATION.TUTORIAL
// {
//     
//     
//     

using Game.Tutorial.Gameplay;
using GameSystem;
using Sirenix.Utilities;
using UnityEngine;

namespace Presentation
{
    public sealed class TutorialProvider_HarvestTrees : MonoBehaviour
    {
        public GameObject targetTree;

        public GameObject[] otherTress;
    }

    public class TutorialStepObserver_HarvestTree : TutorialStepController
    {
        [GameInject]
        private TutorialProvider_HarvestTrees treesProvider;

        protected override void OnStart()
        {
            this.treesProvider.targetTree.SetActive(true);
            this.treesProvider.otherTress.ForEach(it => it.SetActive(false));
        }

        protected override void OnStop()
        {
            this.treesProvider.otherTress.ForEach(it => it.SetActive(true));
        }
    }
}

//     
//     
//     
//     
// }
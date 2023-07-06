using System;
using Game.App;
using UnityEngine;

namespace SaveLoad.SaveSystem.Mediators
{
    public class LoadingTask_MediatorsInstaller : ILoadingTask
    {
        public void Do(Action<LoadingResult> callback)
        {
            var mediatorInstaller = GameObject.FindObjectOfType<MediatorInstaller>();
            mediatorInstaller.Install();
            callback.Invoke(LoadingResult.Success());
        }
    }
}
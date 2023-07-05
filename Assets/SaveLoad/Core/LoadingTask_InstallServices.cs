using System;
using Game.App;
using Services;
using UnityEngine;

namespace SaveLoad.Core
{
    public class LoadingTask_InstallServices : ILoadingTask
    {
        public void Do(Action<LoadingResult> callback)
        {
            var serviceInstaller = GameObject.FindObjectOfType<ServiceInstaller>();
            serviceInstaller.Install();
            callback.Invoke(LoadingResult.Success());
        }
    }
}



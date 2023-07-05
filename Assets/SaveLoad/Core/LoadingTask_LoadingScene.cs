using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Game.App;
using UnityEngine.SceneManagement;

namespace SaveLoad.GameManagment
{
    public class LoadingTask_LoadingScene : ILoadingTask
    {
        public void Do(Action<LoadingResult> callback)
        {
            var task = SceneManager.LoadSceneAsync(1);

            if (task.isDone)
            {
                callback.Invoke(LoadingResult.Success());
            }
            else
            {
                callback.Invoke(LoadingResult.Fail("Scene is not loaded"));
            }
        }
    }
}
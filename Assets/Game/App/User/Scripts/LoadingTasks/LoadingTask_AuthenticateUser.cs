using System;
using Game.UI;
using Services;

namespace Game.App
{
    public sealed class LoadingTask_AuthenticateUser : ILoadingTask
    {
        private readonly UserAuthenticator userAuth;

        [ServiceInject]
        public LoadingTask_AuthenticateUser(UserAuthenticator userAuth)
        {
            this.userAuth = userAuth;
        }

        async void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            await this.userAuth.Authenticate();
            LoadingScreen.ReportProgress(0.2f);
            callback.Invoke(LoadingResult.Success());
        }
    }
}
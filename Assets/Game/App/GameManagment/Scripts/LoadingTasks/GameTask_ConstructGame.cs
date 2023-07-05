using System;
using Services;

namespace Game.App
{
    public class GameTask_ConstructGame : ILoadingTask
    {
        private readonly GameFacade gameFacade;

        [ServiceInject]
        public GameTask_ConstructGame(GameFacade gameFacade)
        {
            this.gameFacade = gameFacade;
        }

        void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            this.gameFacade.ConstructGame();
            callback?.Invoke(LoadingResult.Success());
        }
    }
}
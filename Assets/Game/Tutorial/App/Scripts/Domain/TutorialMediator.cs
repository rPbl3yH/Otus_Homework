using Game.App;
using Newtonsoft.Json;
using Services;

namespace Game.Tutorial.App
{
    public class TutorialMediator : IGameMediator
    {
        [ServiceInject]
        protected TutorialManager tutorialManager;

        public virtual void SetupData(GameRepository repository)
        {
            if (repository.TryGetData(nameof(TutorialData), out var json))
            {
                var data = JsonConvert.DeserializeObject<TutorialData>(json);
                this.tutorialManager.Initialize(data.isCompleted, data.stepIndex);
            }
            else
            {
                this.tutorialManager.Initialize();
            }
        }

        void IGameMediator.SaveData(GameRepository repository)
        {
            var json = JsonConvert.SerializeObject(new TutorialData
            {
                isCompleted = this.tutorialManager.IsCompleted,
                stepIndex = this.tutorialManager.CurrentIndex
            });
            
            repository.SetData(nameof(TutorialData), json);
        }
    }
}
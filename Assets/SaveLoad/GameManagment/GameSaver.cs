using Game.App;
using Services;
using UnityEngine;

namespace SaveLoad.SaveSystem
{
    public class GameSaver
    {
        private const int DelayForSave = 3;

        private ApplicationManager _manager;
        private GameRepository _repository;
        private IGameMediator[] _mediators;
        
        private float _timer;
        
        [ServiceInject]
        public void Construct(ApplicationManager applicationManager, GameRepository repository, IGameMediator[] mediators)
        {
            _manager = applicationManager;
            _repository = repository;
            _mediators = mediators;
            _manager.OnUpdate += OnUpdate;
            Debug.Log("Init");
        }

        private void OnUpdate(float deltaTime)
        {
            _timer -= deltaTime;

            if (_timer <= 0)
            {
                Save();
                _timer = DelayForSave;
            }
        }

        private void Save()
        {
            foreach (var mediator in _mediators)
            {
                mediator.SaveData(_repository);
            }
            
            Debug.Log("Save");
            _repository.SaveState();    
        }
    }
}
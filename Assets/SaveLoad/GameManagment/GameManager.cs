using Services;
using UnityEngine;

namespace SaveLoad.GameManagment
{
    public class GameManager 
    {
        private GameContext _gameContext;

        public GameManager()
        {
            Debug.Log("Initialize game manager ");
        }

        [ServiceInject]
        public void Construct(GameContext gameContext)
        {
            Debug.Log("Init with game context");
            gameContext.InitGame();
        }
    }
}
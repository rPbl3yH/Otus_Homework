using Services;
using UnityEngine;

namespace SaveLoad.GameManagment
{
    public class GameContext 
    {
        public GameContext()
        {
            Debug.Log("Init game context");
            
        }
        
        public void InitGame()
        {
                   
        }

        public T GetService<T>()
        {
            return ServiceLocator.GetService<T>();
        }
    }
}
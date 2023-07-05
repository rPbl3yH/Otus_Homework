using System;
using UnityEngine;

namespace SaveLoad.Scripts.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            
        }
    }

    public class GameRepository
    {
        
    }

    public interface IGameRepository
    {
        void SaveData();
        void LoadData();

    }
}

using System.Collections.Generic;
using Services;
using UnityEngine;

namespace SaveLoad.SaveSystem.Mediators
{
    public class MediatorInstaller : MonoBehaviour
    {
        public void Install()
        {
            ServiceLocator.AddService(new ResourcesMediator()); 
        }
    }
}

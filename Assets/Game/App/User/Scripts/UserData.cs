using System;
using UnityEngine;

namespace Game.App
{
    [Serializable]
    public struct UserData
    {
        [SerializeField]
        public string id;

        [SerializeField]
        public string password;
    }
}
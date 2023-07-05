using System.Collections.Generic;
using Services;
using UnityEngine;

namespace Game.App
{
    [CreateAssetMenu(
        fileName = "BackendServicePack",
        menuName = "App/New BackendServicePack"
    )]
    public sealed class BackendServerPack : ServicePackBase
    {
        [SerializeField]
        private string url = "http://localhost";

        [SerializeField]
        private int port = 3000;

        public override IEnumerable<object> ProvideServices()
        {
            yield return new BackendServer(this.url, this.port);
        }
    }
}
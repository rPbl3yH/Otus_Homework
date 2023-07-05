using System.Collections.Generic;
using Services;
using UnityEngine;

namespace Game.App
{
    [CreateAssetMenu(
        fileName = "UserServicePack",
        menuName = "App/New UserServicePack"
    )]
    public sealed class UserServicePack : ServicePackBase
    {
        public override IEnumerable<object> ProvideServices()
        {
            yield return new UserAuthenticator();
        }
    }
}
using System.Threading.Tasks;
using Asyncoroutine;
using Services;
using static UnityEngine.Networking.UnityWebRequest.Result;
// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable UnusedParameter.Local

namespace Game.App
{
    public sealed class GameClient
    {
        public bool IsAuthorized()
        {
            return this.UserId != null && this.Token != null;
        }

        public string UserId { private get; set; }

        public string Token { private get; set; }

        private BackendServer server;

        [ServiceInject]
        public void Construct(BackendServer server)
        {
            this.server = server;
        }

        public async Task<(bool, string)> DownloadState()
        {
            if (!this.IsAuthorized())
            {
                return (false, null);
            }

            var route = $"load_player?userId={this.UserId}&token={this.Token}";
            using (var request = this.server.Get(route))
            {
                await request.SendWebRequest();

                if (request.result is ConnectionError or ProtocolError)
                {
                    return (false, null);
                }

                var playerState = request.downloadHandler.text;
                if (playerState == "null")
                {
                    return (false, null);
                }
                
                return (true, playerState);
            }
        }

        public async Task<bool> UploadState(string playerState)
        {
            if (!this.IsAuthorized())
            {
                return false;
            }

            var route = $"save_player?userId={this.UserId}&token={this.Token}";
            using (var request = this.server.Put(route, playerState))
            {
                await request.SendWebRequest();
                return request.result == Success;
            }
        }
    }
}
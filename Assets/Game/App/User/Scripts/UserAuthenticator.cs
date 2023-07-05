using System.Threading.Tasks;
using Asyncoroutine;
using Newtonsoft.Json;
using Services;
using UnityEngine;
using static UnityEngine.Networking.UnityWebRequest.Result;

// ReSharper disable NotAccessedField.Local

namespace Game.App
{
    public sealed class UserAuthenticator
    {
        private const string USER_KEY = "UserData";

        private BackendServer server;

        private GameClient client;

        [ServiceInject]
        public void Construct(BackendServer server, GameClient client)
        {
            this.server = server;
            this.client = client;
        }

        public Task<bool> Authenticate()
        {
            if (ES3.KeyExists(USER_KEY))
            {
                var user = ES3.Load<UserData>(USER_KEY);
                return this.SignIn(user.id, user.password);
            }

            return this.SignUp();
        }

        private async Task<bool> SignIn(string userId, string password)
        {
            var bodyJson = JsonConvert.SerializeObject(new SignInRequest
            {
                userId = userId,
                password = password
            });

            using (var request = this.server.Post("signIn", bodyJson))
            {
                await request.SendWebRequest();

                if (request.result is ConnectionError or ProtocolError)
                {
                    return false;
                }
                
                var responseJson = request.downloadHandler.text;
                if (responseJson == null)
                {
                    return false;
                }
                
                var response = JsonConvert.DeserializeObject<SignInResponse>(responseJson);
                
                this.client.UserId = userId;
                this.client.Token = response.token;
                
                return true;
            }
        }

        private async Task<bool> SignUp()
        {
            var deviceId = SystemInfo.deviceUniqueIdentifier;

            using (var request = this.server.Get($"signUp/?deviceId={deviceId}"))
            {
                await request.SendWebRequest();
                
                if (request.result is ConnectionError or ProtocolError)
                {
                    return false;
                }

                var responseJson = request.downloadHandler.text;
                if (responseJson == null)
                {
                    return false;
                }

                var response = JsonConvert.DeserializeObject<SignUpResponse>(responseJson);

                var userId = response.userId;
                var password = response.password;
                var token = response.token;

                this.client.UserId = userId;
                this.client.Token = token;

                ES3.Save(USER_KEY, new UserData
                {
                    id = userId,
                    password = password
                });

                return true;
            }
        }

        private struct SignInRequest
        {
            public string userId;
            public string password;
        }

        private struct SignInResponse
        {
            public string token;
        }

        private struct SignUpResponse
        {
            public string userId;
            public string password;
            public string token;
        }
    }
}
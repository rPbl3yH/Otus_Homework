//SRP:

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

//Цель практики отрефакторить код в группах:
//Потом студенты показывают, что у них получилось )))

//Пример №1: SRP
// public class SpawnAndClickSystem : MonoBehaviour {
//     
//     [SerializeField] private GameObject prefab;
//     [SerializeField] private Transform spawnPoint;
//     [SerializeField] private float spawnRadius;
//
//     public GameObject SpawnObject() {
//         var spawnPosition = this.spawnPoint.position + Random.onUnitSphere * this.spawnRadius;
//         return Instantiate(this.prefab, spawnPosition, Quaternion.identity);
//     }
//
//     public bool ClickObject(out GameObject unit) {
//         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         if (Physics.Raycast(ray, out var hit)) {
//             unit = hit.transform.gameObject;
//             return true;
//         }
//
//         unit = default;
//         return false;
//     }
// }

//Пример №2: ISP
// public interface IOrk
// {
//     int HitPoints { get; }
//     void Move(Vector3 direction);
//     void DealDamage(GameObject target);
//     void TakeDamage(int damage);
// }

//Пример №3: 
//OCP:
// public sealed class BulletPool {
//     
//     private readonly Queue<Bullet> _bullets;
//
//     public BulletPool(Bullet pref, int size) {
//         _bullets = new Queue<Bullet>(size);
//         for (var i = 0; i < size; i++) {
//             this._bullets.Enqueue(GameObject.Instantiate(pref));
//         }
//     }
//
//     public Bullet Get() {
//         return _bullets.Dequeue();
//     }
//
//     public void Release(Bullet item) {
//         return _bullets.Enqueue(item);
//     }
// }

// public sealed class EnemyPool {
//     
//     private readonly Queue<Enemy> enemies;
//
//     public EnemyPool(Enemy prefab, int size) {
//         this.enemies = new Queue<Enemy>(size);
//         for (var i = 0; i < size; i++) {
//             this.enemies.Enqueue(GameObject.Instantiate(prefab));
//         }
//     }
//
//     public Enemy PullEnemy() {
//         return this.enemies.Dequeue();
//     }
//
//     public void ReleaseEnemy(Enemy item)
//     {
//         return this.enemies.Enqueue(item);
//     }
// }

//Пример №4: SRP
// public class PlayerMonoBeh : MonoBehaviour {
//     
//     public int Hp;
//     public int Speed;
//
//     public void MovePlayerInDirection(Vector3 dir) {
//         this.transform.position += dir * this.Speed;
//     }
//
//     public void DealDamage(int damag) {
//         this.Hp -= damag;
//     }
//
//     public void Save() {
//         PlayerPrefs.SetInt("hitPoints", this.Hp);
//         PlayerPrefs.SetInt("speed", this.Speed);
//     }
//
//     public void LoadFromPrefs() {
//         this.Hp = PlayerPrefs.GetInt("hitPoints");
//         this.Speed = PlayerPrefs.GetInt("speed");
//     }
// }


//Пример №5: DIP
// public sealed class QuestSystem {
//     
//     public event Action<UnityQuest> OnQuestStarted;
//     public event Action<UnityQuest> OnQuestCompleted;
//
//     private UnityQuest quest;
//     private QuestGenerator generator;
//     
//     public void StartNewQuest() {
//         UnityQuest quest = this.generator.GenerateQuest();
//
//         this.quest = quest;
//         this.quest.OnCompleted += this.OnCompleteQuest;
//
//         this.quest.Start();
//         this.OnQuestStarted?.Invoke(quest);
//     }
//
//     private void OnCompleteQuest(UnityQuest quest) {
//         this.quest.OnCompleted -= this.OnCompleteQuest;
//         this.OnQuestCompleted?.Invoke(quest);
//     }
// }

//Пример №6: OCP
// public sealed class GameSaver
// {
//     private Hero hero;
//     private Enemies enemies;
//     private Quests quests;
//     private Inventory inventory;
//
//     private HttpClient client;
//
//     public async void Save()
//     {
//         var sb = new StringBuilder()
//             .Append(JsonUtility.ToJson(this.hero))
//             .Append(JsonUtility.ToJson(this.enemies))
//             .Append(JsonUtility.ToJson(this.quests))
//             .Append(JsonUtility.ToJson(this.inventory));
//
//         await this.client.RequestPut("https://www.otus.ru/unity-pro/game-data", sb.ToString());
//     }
// }

//Пример №7:
//Тут все ок)
// public sealed class CameraFollower : MonoBehaviour,
//     IGameStartListener,
//     IGameFinishListener
// {
//     [SerializeField]
//     private Vector3 offset;
//     
//     private IHero hero;
//     private Transform cameraTransform;
//
//     private void Awake()
//     {
//         this.enabled = false;
//     }
//
//     private void LateUpdate()
//     {
//         this.cameraTransform.position = this.hero.position + this.offset;
//     }
//
//     [Inject]
//     public void Construct(IHero hero, Camera camera)
//     {
//         this.hero = hero;
//         this.cameraTransform = camera.transform;
//     }
//
//     void IGameStartElement.StartGame()
//     {
//         this.enabled = true;
//     }
//
//     void IGameFinishElement.FinishGame()
//     {
//         this.enabled = false;
//     }
// }





















//
// public class AIController
// {
//     private UnityObject
// }
//
// public class GameClock
// {
//     private UnityTimer timer;
// }


//
// public class ProductPurchaser
// {
//     public void PurchaseProduct(ScriptableProduct scriptableProduct)
//     {
//         scriptableProduct.name;
//         scriptableProduct.scriptableProduct.price
//     }
// }
//
// public sealed class Client
// {
//     private TcpServer server;
//
//     public Client(TcpServer server)
//     {
//         this.server = server;
//         this.server.SetIP("127.0.0.1");
//         this.server.SetPort(8000);
//     }
//
//     public async Task SignIn(string login, string password)
//     {
//         var data = $"{login} {password}";
//         var response = await this.server.Send(data);
//         if (response == "Success")
//         {
//         }
//     }
// }
//
//
// public sealed class GameSaveSystem
// {
//     private readonly object client;
//
//     public async Task<string> SaveGame()
//     {
//         var 
//
//         if (client is HttpClient httpClient)
//         {
//             return httpClient.Request(data);
//         }
//
//         if (client is TcpClient tcpClient)
//         {
//             return tcpClient.Send(data);
//         }
//
//         if (client is SshClient sshClient)
//         {
//             return sshClient.Push(data);
//         }
//
//         throw new Exception("Undefined client!");
//     }
// }
//
// public class HttpClient
// {
// }
//
// public class TcpClient
// {
// }
//
// public class SshClient
// {
// }
//
//
// //Пример №4: SRP
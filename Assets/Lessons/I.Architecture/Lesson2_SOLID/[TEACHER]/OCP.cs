// ///Нарушение принципа OCP.
//
//
//
//     public sealed class UnitSelection {
//         
//         private List<object> selectedUnits;
//
//         public void Attack(GameObject target) {
//             foreach (var unit in selectedUnits) {
//                 if (unit is Archer archer) archer.Shoot(target);
//                 if (unit is Knight knight) knight.Fight(target);
//                 if (unit is Mage mage) mage.Spell(target);
//             }
//         }
//
//         public void Move(Vector3 position) {
//             foreach (var unit in selectedUnits) {
//                 if (unit is Archer archer) archer.Run(position);
//                 if (unit is Knight knight) knight.Move(position);
//                 if (unit is Mage mage) mage.Teleport(position);
//             }
//         }
//     }
//
//
//
// using System.Collections.Generic;
// using UnityEngine;
//
// ///ПРАВИЛЬНОЕ ИСПОЛЬЗОВАНИЕ
// ///
//
//
//     public interface ISelectedUnit {
//         
//         void Move(Vector3 position);
//         void Attack(GameObject target);
//     }
//
//     public sealed class UnitSelection {
//         
//         private List<ISelectedUnit> selectedUnits;
//
//         public void Move(Vector3 position) {
//             foreach (var unit in selectedUnits) {
//                 unit.Move(position);
//             }
//         }
//
//         public void Attack(GameObject target) {
//             foreach (var unit in selectedUnits) {
//                 unit.Attack(target);
//             }
//         }
//     }
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
// //     ///OCP пример с абстрактным классом из проекта:
// //     /// Один раз написали базовую логику и протестировали
// //     public abstract class Upgrade
// //     {
// //         public int Level { get; private set; } = 1;
// //
// //         public int MaxLevel => this.config.maxLevel;
// //
// //         public int Price { get; }
// //
// //         private readonly UpgradeConfig config;
// //
// //         protected Upgrade(UpgradeConfig config)
// //         {
// //             this.config = config;
// //         }
// //
// //         public void LevelUp()
// //         {
// //             if (this.Level >= this.MaxLevel)
// //             {
// //                 throw new Exception($"Can not increment level for upgrade {this.config.id}!");
// //             }
// //
// //             var nextLevel = this.Level + 1;
// //             this.Level = nextLevel;
// //             this.OnLevelUp(nextLevel); //Шаблонный метод!
// //         }
// //
// //         protected abstract void OnLevelUp(int level);
// //     }
// //
// //     //Нам не придется каждый раз ползать в Upgrades Manager
// //     // public sealed class UpgradesManager
// //     // {
// //     //     public void LevelUpUpgrade(Upgrade upgrade)
// //     //     {
// //     //         if (upgrade.Level < upgrade.MaxLevel)
// //     //         {
// //     //             this.SpendMoney(upgrade.Price);
// //     //             upgrade.LevelUp();
// //     //         }
// //     //     }
// //     // }
// //
// //
// //     // /// Затем пишем логику для каждого типа апгрейда
// //     // public sealed class DamageUpgrade : Upgrade
// //     // {
// //     //     public DamageUpgrade(UpgradeConfig config) : base(config)
// //     //     {
// //     //     }
// //     //
// //     //     protected override void OnLevelUp(int level)
// //     //     {
// //     //         //Логика прокачки урона
// //     //     }
// //     // }
// //     // //
// //     // public sealed class HitPointsUpgrade : Upgrade
// //     // {
// //     //     public HitPointsUpgrade(UpgradeConfig config) : base(config)
// //     //     {
// //     //     }
// //     //
// //     //     protected override void OnLevelUp(int level)
// //     //     {
// //     //         //Логика прокачки здоровья
// //     //     }
// //     // }
// //
// //     // ///OCP пример с интерфейсами:
// //     // ///Один раз написали общую логику загрузки приложения, и нам не придется каждый раз ползать и дописывать код в ApplicationLoader
// //     // public sealed class ApplicationLoader
// //     // {
// //     //     private ILoadingTask[] tasks;
// //     //
// //     //     public async void LoadApplication()
// //     //     {
// //     //         foreach (var task in this.tasks)
// //     //         {
// //     //             await task.Do();
// //     //         }
// //     //     }
// //     // }
// //     //
// //     // public interface ILoadingTask
// //     // {
// //     //     Task Do();
// //     // }
// //
// //     // ///Затем реализуем каждый компонент по отдельности
// //     // public sealed class LoadingTask_LoadPlayerData : ILoadingTask
// //     // {
// //     //     public Task Do()
// //     //     {
// //     //         //Load player data
// //     //     }
// //     // }
// //     
// //     // public sealed class LoadingTask_LoadGameScene : ILoadingTask
// //     // {
// //     //     public Task Do()
// //     //     {
// //     //         //Load Game Scene
// //     //     }
// //     // }
// // }
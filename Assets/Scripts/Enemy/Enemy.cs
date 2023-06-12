using ShootEmUp;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HitPointsComponent HitPointsComponent => _hitPointsComponent;
    public MoveComponent MoveComponent => _moveComponent;
    public WeaponComponent WeaponComponent => _weaponComponent;
    public TeamComponent TeamComponent => _teamComponent;
    public EnemyAttackAgent EnemyAttackAgent => _enemyAttackAgent;
    public EnemyMoveAgent EnemyMoveAgent => _enemyMoveAgent;

    [SerializeField] private HitPointsComponent _hitPointsComponent;
    [SerializeField] private MoveComponent _moveComponent;
    [SerializeField] private WeaponComponent _weaponComponent;
    [SerializeField] private TeamComponent _teamComponent;
    [SerializeField] private EnemyAttackAgent _enemyAttackAgent;
    [SerializeField] private EnemyMoveAgent _enemyMoveAgent;
}

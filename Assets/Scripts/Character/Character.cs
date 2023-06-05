using ShootEmUp;
using UnityEngine;

public class Character : MonoBehaviour
{
    public HitPointsComponent HitPointsComponent => _hitPointsComponent;
    public MoveComponent MoveComponent => _moveComponent;
    public WeaponComponent WeaponComponent => _weaponComponent;
    public TeamComponent TeamComponent => _teamComponent;

    [SerializeField] private HitPointsComponent _hitPointsComponent;
    [SerializeField] private MoveComponent _moveComponent;
    [SerializeField] private WeaponComponent _weaponComponent;
    [SerializeField] private TeamComponent _teamComponent;
}

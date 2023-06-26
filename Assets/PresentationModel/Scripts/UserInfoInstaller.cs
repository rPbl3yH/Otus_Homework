using Lessons.Architecture.PM;
using UnityEngine;
using Zenject;

public class UserInfoInstaller : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string _destription;
    [SerializeField] private Sprite _icon;
    private UserInfo _userInfo;

    [Inject]
    public void Construct(UserInfo userInfo) {
        _userInfo = userInfo;
        _userInfo.ChangeName(_name);
        _userInfo.ChangeDescription(_destription);
        _userInfo.ChangeIcon(_icon);
    }
}

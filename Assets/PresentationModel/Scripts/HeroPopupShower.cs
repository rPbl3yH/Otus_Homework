using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

public class HeroPopupShower : MonoBehaviour
{
    [SerializeField] private HeroPopup _popup;

    [SerializeField] private PlayerLevel _playerLevel;
    [SerializeField] private UserInfo _userInfo;
    [SerializeField] private CharacterInfo _characterInfo;

    [Inject]
    public void Construct(PlayerLevel playerLevel, UserInfo userInfo, CharacterInfo characterInfo)
    {
        _playerLevel = playerLevel;
        _userInfo = userInfo;
        _characterInfo = characterInfo;
    }
    
    [ShowInInspector]
    public void ShowPopup()
    {
        var userPM = new UserInfoPresentationModel(_userInfo);
        var heroStatsPM = new HeroStatsPresentation(_characterInfo);
        var progressPM = new ProgressPresentationModel(_playerLevel);
        _popup.Show(userPM, heroStatsPM, progressPM);
    }
    
    [ShowInInspector]
    public void HidePopup()
    {
        _popup.Hide();
    }
}

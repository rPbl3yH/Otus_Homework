using Lessons.Architecture.PM;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterInfo _characterInfo;
    [SerializeField] private UserInfo _userInfo;
    [SerializeField] private PlayerLevel _playerLevel;
    [SerializeField] private HeroPopup _heroPopup;
    [SerializeField] private CharacterStatsInstaller _characterStatsInstaller;
    [SerializeField] private UserInfoInstaller _userInfoInstaller;

    public void Awake()
    {
        _characterInfo = new CharacterInfo();
        _userInfo = new UserInfo();
        _playerLevel = new PlayerLevel();

        _userInfoInstaller.Construct(_userInfo);
        _characterStatsInstaller.Construct(_characterInfo);

        var userPM = new UserInfoPresentationModel(_userInfo);
        var heroStatsPM = new HeroStatsPresentation(_characterInfo);
        var progressPM = new ProgressPresentationModel(_playerLevel);
        _heroPopup.Show(userPM, heroStatsPM, progressPM);
    }
}
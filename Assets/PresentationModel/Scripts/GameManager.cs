using Lessons.Architecture.PM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Lessons.Architecture.PM.CharacterInfo _characterInfo;
    [SerializeField] private UserInfo _userInfo;
    [SerializeField] private PlayerLevel _playerLevel;
    [SerializeField] private HeroPopup _heroPopup;
    [SerializeField] private CharacterStatsInstaller _characterStatsInstaller;
    
    private IPresentationModel _presentationModel;

    public void Awake() {
        _characterInfo = new Lessons.Architecture.PM.CharacterInfo();
        _userInfo = new UserInfo();
        _playerLevel = new PlayerLevel();

        _characterStatsInstaller.Construct(_characterInfo);
         _presentationModel = new PresentationModel(_characterInfo, _playerLevel, _userInfo);
        _heroPopup.Show(_presentationModel);
    }
}

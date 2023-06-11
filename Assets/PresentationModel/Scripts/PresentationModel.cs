using Lessons.Architecture.PM;
using System;
using UnityEngine;

public class PresentationModel : IPresentationModel
{

    private Lessons.Architecture.PM.CharacterInfo _characterInfo;
    private PlayerLevel _playerLevel;
    private UserInfo _userInfo;

    public event Action OnStateChanged;

    public PresentationModel(Lessons.Architecture.PM.CharacterInfo characterInfo, PlayerLevel playerLevel, UserInfo userInfo) {
        _characterInfo = characterInfo;
        _playerLevel = playerLevel;
        _userInfo = userInfo;

        _userInfo.OnIconChanged += OnIconChanged;
        _userInfo.OnNameChanged += OnNameChanged;
        _userInfo.OnDescriptionChanged += OnDescriptionChanged;
    }

    private void OnDescriptionChanged(string description) {
        ChangeState();
    }

    private void ChangeState() {
        OnStateChanged?.Invoke();
    }

    private void OnNameChanged(string name) {
        ChangeState();
    }

    private void OnIconChanged(Sprite sprite) {
        ChangeState();
    }

    bool IPresentationModel.GetButtonInteractable() {
        return true;
    }

    string IPresentationModel.GetDamage() {
        return string.Empty;
        return _characterInfo.GetStat("Damage").ToString();
    }

    string IPresentationModel.GetDescription() {
        return _userInfo.Description;
    }

    string IPresentationModel.GetDexterity() {
        return string.Empty;
        return _characterInfo.GetStat("Dexterity").ToString();
    }

    float IPresentationModel.GetFillAmount() {
        return _playerLevel.CurrentExperience / (float)_playerLevel.RequiredExperience;
    }

    Sprite IPresentationModel.GetIcon() {
        return _userInfo.Icon;
    }

    string IPresentationModel.GetIntelligence() {
        return string.Empty;
        return _characterInfo.GetStat("Intelligence").ToString();
    }

    string IPresentationModel.GetLevelText() {
        return "Level: " + _playerLevel.CurrentLevel.ToString();
    }

    string IPresentationModel.GetLevelUpText() {
        return "Level up";
    }

    string IPresentationModel.GetName() {
        return _userInfo.Name;
    }

    string IPresentationModel.GetProgressBarText() {
        return $"XP: {_playerLevel.CurrentExperience}/{_playerLevel.RequiredExperience}";
    }

    string IPresentationModel.GetRegeneration() {
        return string.Empty;

        return _characterInfo.GetStat("Regeneration").ToString();
    }

    string IPresentationModel.GetSpeed() {
        return string.Empty;

        return _characterInfo.GetStat("MoveSpeed").ToString();
    }

    string IPresentationModel.GetStamina() {
        return string.Empty;

        return _characterInfo.GetStat("Staminf").ToString();
    }

    void IPresentationModel.OnCloseClick() {
        Debug.Log("close click");        
    }

    void IPresentationModel.OnLevelUpClick() {
        Debug.Log("level up click");
    }
}

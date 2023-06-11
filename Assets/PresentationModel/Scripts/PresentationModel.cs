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
        var stats = characterInfo.GetStats();

        foreach ( var item in stats) {
            item.OnValueChanged += OnStatValueChanged;
        }
    }

    private void OnStatValueChanged(int value) {
        ChangeState();
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


    string IPresentationModel.GetDescription() {
        return _userInfo.Description;
    }

    float IPresentationModel.GetFillAmount() {
        return _playerLevel.CurrentExperience / (float)_playerLevel.RequiredExperience;
    }

    Sprite IPresentationModel.GetIcon() {
        return _userInfo.Icon;
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
    
    string IPresentationModel.GetDamage() {
        return GetStatText(CharacterStatKeys.Damage);
    }

    string IPresentationModel.GetDexterity() {
        return GetStatText(CharacterStatKeys.Dexterity);
    }

    string IPresentationModel.GetIntelligence() {
        return GetStatText(CharacterStatKeys.Intelligence);
    }

    string IPresentationModel.GetRegeneration() {
        return GetStatText(CharacterStatKeys.Regeneration);
    }

    string IPresentationModel.GetSpeed() {
        return GetStatText(CharacterStatKeys.MoveSpeed);
    }

    string IPresentationModel.GetStamina() {
        return GetStatText(CharacterStatKeys.Stamina);
    }

    void IPresentationModel.OnCloseClick() {
        Debug.Log("close click");        
    }

    void IPresentationModel.OnLevelUpClick() {
        Debug.Log("level up click");
    }

    string GetStatText(string key) {
        var name = _characterInfo.GetStat(key).Name;
        var value = _characterInfo.GetStat(key).Value;
        return $"{name}: {value}";
    }
}

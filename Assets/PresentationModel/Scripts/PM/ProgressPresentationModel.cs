using System;
using Lessons.Architecture.PM;

public class ProgressPresentationModel : IProgressPresentationModel
{
    private readonly PlayerLevel _playerLevel;

    public ProgressPresentationModel(PlayerLevel playerLevel)
    {
        _playerLevel = playerLevel;
        _playerLevel.OnExperienceChanged += OnExperienceChange;
        _playerLevel.OnLevelUp += OnLevelChange;
    }

    public event Action OnStateChanged;

    public string GetLevelText()
    {
        return $"Level {_playerLevel.CurrentLevel}";
    }

    public string GetLevelUpText()
    {
        return "Level up";
    }

    public float GetFillAmount()
    {
        return _playerLevel.CurrentExperience / (float)_playerLevel.RequiredExperience;
    }

    public string GetProgressBarText()
    {
        return $"XP: {_playerLevel.CurrentExperience} / {_playerLevel.RequiredExperience}";
    }

    public bool GetButtonInteractable()
    {
        return _playerLevel.CanLevelUp();
    }

    public void OnLevelUpClick()
    {
        _playerLevel.LevelUp();
    }

    private void OnLevelChange()
    {
        OnStateChanged?.Invoke();
    }

    private void OnExperienceChange(int value)
    {
        OnStateChanged?.Invoke();
    }
}
using System;
using Lessons.Architecture.PM;

public class ProgressPresentationModel : IProgressPresentationModel
{
    private readonly PlayerLevel _playerLevel;

    public event Action OnStateChanged;

    public ProgressPresentationModel(PlayerLevel playerLevel)
    {
        _playerLevel = playerLevel;
        _playerLevel.OnExperienceChanged += OnExperienceChange;
        _playerLevel.OnLevelUp += OnLevelChange;
    }

    private void OnLevelChange()
    {
        OnStateChanged?.Invoke();
    }

    private void OnExperienceChange(int value)
    {
        OnStateChanged?.Invoke();
    }

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
        return $"{_playerLevel.CurrentExperience} / {_playerLevel.RequiredExperience}";
    }

    public bool GetButtonInteractable()
    {
        return _playerLevel.CanLevelUp();
    }

    public void OnLevelUpClick()
    {
        _playerLevel.LevelUp();
    }
}
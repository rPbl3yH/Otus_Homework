using System;
using Lessons.Architecture.PM;

public class ProgressPresentationModel : IProgressPresentationModel
{
    private PlayerLevel _playerLevel;

    public event Action OnExperienceChanged;
    public event Action OnLevelUp;

    public ProgressPresentationModel(PlayerLevel playerLevel)
    {
        _playerLevel = playerLevel;
        _playerLevel.OnExperienceChanged += OnExperienceChange;
        _playerLevel.OnLevelUp += OnLevelChange;
    }

    private void OnLevelChange()
    {
        OnLevelUp?.Invoke();
    }

    private void OnExperienceChange(int value)
    {
        OnExperienceChanged?.Invoke();
    }

    public string GetLevelText()
    {
        return $"Level {_playerLevel.CurrentLevel}";
    }

    public float GetFillAmount()
    {
        return _playerLevel.CurrentExperience / (float)_playerLevel.RequiredExperience;
    }

    public string GetProgressBarText()
    {
        return $"{_playerLevel.CurrentExperience} / {_playerLevel.RequiredExperience}";
    }
}
using System;

public interface IProgressPresentationModel
{
    event Action OnExperienceChanged;
    event Action OnLevelUp;
    string GetLevelText();

    float GetFillAmount();

    string GetProgressBarText();
}
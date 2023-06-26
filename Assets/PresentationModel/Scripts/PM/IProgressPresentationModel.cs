using System;

public interface IProgressPresentationModel
{
    event Action OnStateChanged;
    string GetLevelText();
    string GetLevelUpText();

    float GetFillAmount();

    string GetProgressBarText();
    bool GetButtonInteractable();

    void OnLevelUpClick();

}
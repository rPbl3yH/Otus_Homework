using Lessons.Architecture.PM;
using System;
using UnityEngine;

public interface IStatPresentationModel
{
    string GetStatText();
}

public interface IHeroStatsPresentationModel
{
    event Action<CharacterStat> OnStatAdded;
    event Action<CharacterStat> OnStatRemoved;
    CharacterStat[] GetStats();
}

public interface IPresentationModel
{
    event Action OnStateChanged;
    Sprite GetIcon();

    string GetName();

    string GetDescription();

    string GetLevelText();

    float GetFillAmount();

    string GetProgressBarText();


    string GetLevelUpText();

    bool GetButtonInteractable();

    void OnLevelUpClick();

    void OnCloseClick();
}

using System;
using UnityEngine;

public interface IUserInfoPresentationModel
{
    event Action OnStateChanged;
    Sprite GetIcon();

    string GetName();

    string GetDescription();
}
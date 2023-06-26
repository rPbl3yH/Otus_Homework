using System;
using Lessons.Architecture.PM;
using UnityEngine;

public class UserInfoPresentationModel : IUserInfoPresentationModel
{
    private readonly UserInfo _userInfo;

    public UserInfoPresentationModel(UserInfo userInfo)
    {
        _userInfo = userInfo;
        _userInfo.OnIconChanged += OnIconChanged;
        _userInfo.OnNameChanged += OnNameChanged;
        _userInfo.OnDescriptionChanged += OnDescriptionChanged;
    }

    public event Action OnStateChanged;

    string IUserInfoPresentationModel.GetDescription()
    {
        return _userInfo.Description;
    }

    Sprite IUserInfoPresentationModel.GetIcon()
    {
        return _userInfo.Icon;
    }

    string IUserInfoPresentationModel.GetName()
    {
        return _userInfo.Name;
    }

    private void UpdateState()
    {
        OnStateChanged?.Invoke();
    }

    private void OnDescriptionChanged(string description)
    {
        UpdateState();
    }

    private void OnNameChanged(string name)
    {
        UpdateState();
    }

    private void OnIconChanged(Sprite sprite)
    {
        UpdateState();
    }
}